using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

/// Not exposed directly 
public readonly struct PinnedChatUpdates
{
    /// Not exposed directly 
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// Not exposed directly 
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly struct PayloadData : IPinnedMessage, IUnpinnedMessage
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("pinned_by")]
        public UserInfo PinnedBy { get; init; }

        [JsonPropertyName("unpinned_by")]
        public UserInfo UnpinnedBy { get; init; }

        [JsonPropertyName("message")]
        public MessageData Message { get; init; }

        [JsonPropertyName("reason")]
        public string Reason { get; init; }
    }

    public readonly struct UserInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }
    }

    public readonly struct MessageData : IPinnedMessageData, IPinnedMessageDataUpdate
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("ends_at")]
        public long EndsAt { get; init; }

        [JsonPropertyName("sender")]
        public MessageSenderInfo Sender { get; init; }

        [JsonPropertyName("content")]
        public MessageContent Content { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("starts_at")]
        public long StartsAt { get; init; }

        [JsonPropertyName("sent_at")]
        public long SentAt { get; init; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; init; }
    }

    public readonly struct MessageSenderInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }

        [JsonPropertyName("chat_color")]
        public string ColorCode { get; init; }
    }

    public readonly struct MessageContent
    {
        [JsonPropertyName("text")]
        public string Text { get; init; }
    }
}