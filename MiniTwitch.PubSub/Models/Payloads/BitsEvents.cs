using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct BitsEvents
{
    [JsonPropertyName("data")]
    public BitsData Data { get; init; }
    [JsonPropertyName("version")]
    public string Version { get; init; }
    [JsonPropertyName("message_type")]
    public string MessageType { get; init; }
    [JsonPropertyName("message_id")]
    public string MessageId { get; init; }
    [JsonPropertyName("is_anonymous")]
    public bool IsAnonymous { get; init; }

    public readonly struct BadgeEntitlement
    {
        [JsonPropertyName("new_version")]
        public int NewVersion { get; init; }

        [JsonPropertyName("previous_version")]
        public int PreviousVersion { get; init; }
    }
    public readonly struct BitsData
    {
        [JsonPropertyName("user_name")]
        public string? Username { get; init; }

        [JsonPropertyName("channel_name")]
        public string ChannelName { get; init; }

        [JsonPropertyName("user_id")]
        public long? UserId { get; init; }

        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }

        [JsonPropertyName("time")]
        public DateTime Time { get; init; }

        [JsonPropertyName("chat_message")]
        public string ChatMessage { get; init; }

        [JsonPropertyName("bits_used")]
        public int BitsUsed { get; init; }

        [JsonPropertyName("total_bits_used")]
        public int TotalBitsUsed { get; init; }

        [JsonPropertyName("context")]
        public string Context { get; init; }

        [JsonPropertyName("badge_entitlement")]
        public BadgeEntitlement? BadgeEntitlement { get; init; }
    }

}
