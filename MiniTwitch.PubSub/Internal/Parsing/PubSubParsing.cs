using System.Runtime.CompilerServices;
using System.Text.Json;
using MiniTwitch.Common.Extensions;
using MiniTwitch.PubSub.Enums;
using MiniTwitch.PubSub.Internal.Enums;
using MiniTwitch.PubSub.Internal.Models;
using MiniTwitch.PubSub.Models;

namespace MiniTwitch.PubSub.Internal.Parsing;

internal static class PubSubParsing
{
    public static MessageType ParseType(ReadOnlySpan<byte> span)
    {
        const byte quotationMark = (byte)'"';
        int qCount = 0;
        int start = 0;
        while (qCount < 3)
        {
            start = span[start..].IndexOf(quotationMark) + start + 1;
            qCount++;
        }

        int end = span[start..].IndexOf(quotationMark) + start;
        MessageType type = (MessageType)span[start..end].Sum();
        return type;
    }

    public static (MessageTopic, long) ParseTopic(ReadOnlySpan<byte> span)
    {
        const byte quotationMark = (byte)'"';
        const byte dot = (byte)'.';
        const byte zero = (byte)'0';
        int qCount = 0;
        int start = 0;
        while (qCount < 9)
        {
            start = span[start..].IndexOf(quotationMark) + start + 1;
            qCount++;
        }

        ReadOnlySpan<byte> upperBound = stackalloc byte[] { dot, quotationMark };
        int end = span[start..].IndexOfAny(upperBound) + start;
        MessageTopic topic = (MessageTopic)span[start..end].Sum();
        long arg = 0;
        end++;
        int end2 = span[end..].IndexOfAny(upperBound) + end;
        foreach (byte b in span[end..end2])
        {
            arg *= 10;
            arg += b - zero;
        }

        return (topic, arg);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<byte> ReadMessage(this ReadOnlySpan<byte> span, bool escaped = true)
    {
        const byte quotationMark = (byte)'"';
        int qCount = 0;
        int start = 0;
        while (qCount < 13)
        {
            start = span[start..].IndexOf(quotationMark) + start + 1;
            qCount++;
        }

        int end = span[start..].LastIndexOf(quotationMark) + start;
        return span[start..end];
    }

    public static T ReadJsonMessage<T>(this ReadOnlySpan<byte> span, bool escaped = true, JsonSerializerOptions? options = null) where T : struct
    {
        ReadOnlySpan<byte> message = span.ReadMessage(escaped);
        Span<byte> unescaped = stackalloc byte[message.Length];
        int endIndex = message.CopyUnescaped(unescaped);
        return JsonSerializer.Deserialize<T>(unescaped[..endIndex], options);
    }

    public static (T1?, T2?) TwitchIsRetarded<T1, T2>(this ReadOnlySpan<byte> span, bool escaped = true, JsonSerializerOptions? options = null)
        where T1 : struct
        where T2 : struct
    {
        ReadOnlySpan<byte> message = span.ReadMessage(escaped);
        Span<byte> unescaped = stackalloc byte[message.Length];
        int endIndex = message.CopyUnescaped(unescaped);
        try
        {
            T1 value1 = JsonSerializer.Deserialize<T1>(unescaped[..endIndex], options);
            return (value1, default);
        }
        catch (Exception)
        {
            T2 value2 = JsonSerializer.Deserialize<T2>(unescaped[..endIndex], options);
            return (default, value2);
        }
    }

    public static ListenResponse ParseResponse(ReadOnlySpan<byte> span)
    {
        var response = JsonSerializer.Deserialize<ResponsePayload>(span);
        return new ListenResponse()
        {
            TopicKey = response.Nonce,
            Error = Enum.TryParse(response.Error, true, out ResponseError error) ? error : ResponseError.Success,
        };
    }
}
