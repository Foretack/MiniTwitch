using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct PinnedChatUpdates
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly record struct PayloadData(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("pinned_by")] UserInfo PinnedBy = default,
        [property: JsonPropertyName("unpinned_by")] UserInfo UnpinnedBy = default,
        [property: JsonPropertyName("message")] MessageData Message = default,
        [property: JsonPropertyName("reason")] string Reason = ""
    ) : IPinnedMessage, IUnpinnedMessage;

    public readonly record struct UserInfo(
        [property: JsonPropertyName("id")] long Id,
        [property: JsonPropertyName("display_name")] string DisplayName
    );

    public readonly record struct MessageData(
        [property: JsonPropertyName("id")] string Id = "",
        [property: JsonPropertyName("ends_at")] long EndsAt = default,
        [property: JsonPropertyName("sender")] MessageSenderInfo Sender = default,
        [property: JsonPropertyName("content")] MessageContent Content = default,
        [property: JsonPropertyName("type")] string Type = "",
        [property: JsonPropertyName("starts_at")] long StartsAt = default,
        [property: JsonPropertyName("sent_at")] long SentAt = default,
        [property: JsonPropertyName("updated_at")] long UpdatedAt = default
    ) : IPinnedMessageData, IPinnedMessageDataUpdate;

    public readonly record struct MessageSenderInfo(
        [property: JsonPropertyName("id")] long Id,
        [property: JsonPropertyName("display_name")] string DisplayName,
        [property: JsonPropertyName("chat_color")] string ColorCode
    );

    public readonly record struct MessageContent(
        [property: JsonPropertyName("text")] string Text
    );
}