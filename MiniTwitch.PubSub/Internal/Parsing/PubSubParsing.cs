using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
        Console.WriteLine(span[start..end].Sum());
        Console.WriteLine(Encoding.UTF8.GetString(span[start..end]));
        return type;
    }

    public static MessageTopic ParseTopic(ReadOnlySpan<byte> span)
    {
        const byte quotationMark = (byte)'"';
        const byte dot = (byte)'.';
        int qCount = 0;
        int start = 0;
        while (qCount < 9)
        {
            start = span[start..].IndexOf(quotationMark) + start + 1;
            qCount++;
        }

        int end = span[start..].IndexOfAny(stackalloc byte[] { dot, quotationMark }) + start;
        MessageTopic topic = (MessageTopic)span[start..end].Sum();
        Console.WriteLine(span[start..end].Sum());
        Console.WriteLine(Encoding.UTF8.GetString(span[start..end]));
        return topic;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<byte> ReadMessage(this ReadOnlySpan<byte> span)
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

    public static T ReadJsonMessage<T>(this ReadOnlySpan<byte> span, JsonSerializerOptions? options = null) where T : struct
    {
        // TODO: This is terrible, but I couldn't get Utf8JsonReader to work like Microsoft's example:
        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/use-utf8jsonreader#consume-decoded-json-strings
        ReadOnlySpan<char> chars = Regex.Unescape(Encoding.UTF8.GetString(span.ReadMessage()));
        return JsonSerializer.Deserialize<T>(chars, options);
    }

    public static ListenResponse ParseResponse(ReadOnlySpan<byte> span)
    {
        var response = JsonSerializer.Deserialize<ResponsePayload>(span);
        Console.WriteLine(Encoding.UTF8.GetString(span));
        return new ListenResponse()
        {
            TopicString = response.Nonce,
            Error = Enum.TryParse(response.Error, true, out ResponseError error) ? error : ResponseError.None,
        };
    }
}
