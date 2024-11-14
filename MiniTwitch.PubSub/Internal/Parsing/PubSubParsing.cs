using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
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
        MessageType type = (MessageType)span[start..end].MSum();
        return type;
    }

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

    public static T ReadJsonMessage<T>(this ReadOnlySpan<byte> span, bool escaped = true, JsonSerializerOptions? options = null, ILogger? logger = null)
        where T : struct
    {
        ReadOnlySpan<byte> message = span.ReadMessage(escaped);
        Span<byte> unescaped = stackalloc byte[message.Length];
        int endIndex = message.CopyUnescaped(unescaped);
        T val;
        try
        {
            val = JsonSerializer.Deserialize<T>(unescaped[..endIndex], options);
        }
        catch (Exception ex)
        {
            string json = Encoding.UTF8.GetString(unescaped[..endIndex]);
            logger?.LogError("Failed to deserialize JSON.\nmessage: ({ExceptionType}) {ExceptionMessage}\n{StackTrace}\nJSON string: {JsonString}\nIf you see this error, " +
                "please open an issue! Include the JSON string and the exception. https://github.com/occluder/MiniTwitch/issues",
                ex.GetType().Name, ex.Message, ex.StackTrace, json);

            return default;
        }

        return val;
    }

    public static object? ReadJsonMessage(this ReadOnlySpan<byte> span, Type outType, bool escaped = true, JsonSerializerOptions? options = null)
    {
        ReadOnlySpan<byte> message = span.ReadMessage(escaped);
        Span<byte> unescaped = stackalloc byte[message.Length];
        int endIndex = message.CopyUnescaped(unescaped);
        object? val;
        try
        {
            val = JsonSerializer.Deserialize(unescaped[..endIndex], outType, options);
        }
        catch (Exception ex)
        {
            string json = Encoding.UTF8.GetString(unescaped[..endIndex]);
            return $"Failed to deserialize JSON.\nmessage: ({ex.GetType().Name}) {ex.Message}\n{ex.StackTrace}\nJSON string: {Encoding.UTF8.GetString(span)}\nIf you see this error, " +
                "please open an issue! Include the JSON string and the exception. https://github.com/occluder/MiniTwitch/issues";
        }

        return val;
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
