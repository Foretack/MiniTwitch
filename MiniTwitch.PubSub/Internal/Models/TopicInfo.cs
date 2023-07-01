using System.Buffers;
using MiniTwitch.Common.Extensions;
using MiniTwitch.PubSub.Internal.Enums;

namespace MiniTwitch.PubSub.Internal.Models;

internal readonly struct TopicInfo : IDisposable
{
    public readonly MessageTopic Topic { get; init; }
    public readonly long[] Ids { get; init; }

    public long this[int index] => Ids[index];

    public TopicInfo(ReadOnlySpan<byte> span)
    {
        const byte quotationMark = (byte)'"';
        const byte dot = (byte)'.';
        const byte zero = (byte)'0';

        Ids = ArrayPool<long>.Shared.Rent(2);
        int qCount = 0;
        int start = 0;
        while (qCount < 9)
        {
            start = span[start..].IndexOf(quotationMark) + start + 1;
            qCount++;
        }

        ReadOnlySpan<byte> separators = stackalloc byte[] { dot, quotationMark };
        int end = span[start..].IndexOfAny(separators) + start;
        int topicEnd = span[end..].IndexOf(quotationMark) + end;
        this.Topic = (MessageTopic)span[start..end].Sum();
        int end2;
        for (int i = 0; end != topicEnd; i++)
        {
            end2 = span[++end..].IndexOfAny(separators) + end;
            if (end2 == end - 1)
                end2 = span.Length;

            foreach (byte b in span[end..end2])
            {
                Ids[i] *= 10L;
                Ids[i] += b - zero;
            }

            end = end2;
        }
    }

    public void Dispose()
    {
        ArrayPool<long>.Shared.Return(Ids, true);
    }
}
