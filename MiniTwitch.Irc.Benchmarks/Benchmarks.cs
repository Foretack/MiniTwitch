using System.Text;
using BenchmarkDotNet.Attributes;
using MiniTwitch.Irc.Internal.Models;

namespace MiniTwitch.Irc.Benchmarks;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private byte[][] utf8Lines = null!;
    private readonly IrcClient _client = new(op => op.Anonymous = true);

    [Params(1, 100, 1000)]
    public int LineCount { get; set; }

    [GlobalSetup]
    public void AddData()
    {
        utf8Lines = File.ReadLines("data.txt").Take(LineCount).Select(Encoding.UTF8.GetBytes).ToArray();
    }

    [Benchmark]
    public void Create()
    {
        foreach (var line in utf8Lines)
        {
            _ = new IrcMessage(line);
        }
    }

    [Benchmark]
    public void Create_Parse()
    {
        foreach (var line in utf8Lines)
        {
            var msg = new IrcMessage(line);
            _ = msg.ParseTags();
            _ = msg.GetChannel();
            _ = msg.GetContent();
            _ = msg.GetUsername();
        }
    }

    [Benchmark]
    public void Create_Parse_Map_Send()
    {
        foreach (var line in utf8Lines)
        {
            _client.Parse(line);
        }
    }
}
