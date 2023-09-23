using System.Buffers;
using System.Runtime.CompilerServices;

namespace MiniTwitch.Irc.Internal.Models;

internal readonly struct IrcTags : IDisposable
{
    public int Count { get; }
    private IrcTag[] Tags { get; }

    public IrcTags(int count)
    {
        this.Count = count;
        this.Tags = ArrayPool<IrcTag>.Shared.Rent(count);
    }

    public void Dispose() => ArrayPool<IrcTag>.Shared.Return(this.Tags, true);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add(int index, ReadOnlyMemory<byte> Key, ReadOnlyMemory<byte> Value) => this.Tags[index] = new(Key, Value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<IrcTag>.Enumerator GetEnumerator() => this.Tags.AsSpan(0, this.Count).GetEnumerator();
}
