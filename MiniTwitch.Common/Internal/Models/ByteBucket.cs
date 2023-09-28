using System.Net.WebSockets;

namespace MiniTwitch.Common.Internal.Models;

/// <summary>
/// Helper class for byte buffering
/// </summary>
internal sealed class ByteBucket
{
    // Keep this bad boy big, because it doesn't need to be cleared
    private readonly Memory<byte> _bucket = new(new byte[short.MaxValue]);
    private readonly Memory<byte> _temp;
    private int _reached = 0;

    public ByteBucket(short tempBufferSize = 2048)
    {
        _temp = new Memory<byte>(new byte[tempBufferSize]);
    }

    /// <summary>
    /// Receives bytes from the provided ClientWebSocket source
    /// </summary>
    /// <returns><see langword="true"/> if the bucket should be drained</returns>
    public async ValueTask<bool> FillFrom(ClientWebSocket source, CancellationToken cToken)
    {
        // Receive bytes into _temp
        // This overwrites previous data
        ValueWebSocketReceiveResult result = await source.ReceiveAsync(_temp, cToken);
        // Copy the received bytes into the bucket
        _temp[..result.Count].CopyTo(_bucket[_reached..(result.Count + _reached)]);
        _reached += result.Count;
        return result.EndOfMessage;
    }

    public ReadOnlyMemory<byte> Drain()
    {
        const byte lf = (byte)'\n';
        ReadOnlyMemory<byte> filled = _bucket[.._reached];
        ReadOnlyMemory<byte> result = (filled.Span[^1] == lf) ? filled[..^2] : filled;
        _reached = 0;
        return result;
    }
}
