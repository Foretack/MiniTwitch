using System.Buffers;
using System.Collections;

namespace MiniTwitch.Irc.Internal.Models;

internal readonly struct IrcTags : IDisposable, IEnumerable
{
    public int Count { get; }
    private IrcTag[] Tags { get; }

    public IrcTags(int count)
    {
        this.Count = count;
        this.Tags = ArrayPool<IrcTag>.Shared.Rent(count);
    }

    public void Dispose() => ArrayPool<IrcTag>.Shared.Return(this.Tags, true);

    public void Add(int index, ReadOnlyMemory<byte> Key, ReadOnlyMemory<byte> Value) => this.Tags[index] = new(Key, Value);

    public IEnumerator<IrcTag> GetEnumerator()
    {
        for (int x = 0; x < this.Count; x++)
        {
            yield return this.Tags[x];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
