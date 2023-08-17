using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct BitsBadgeUnlock
{
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    [JsonPropertyName("user_name")]
    public string Username { get; init; }

    [JsonPropertyName("channel_id")]
    public long ChannelId { get; init; }

    [JsonPropertyName("channel_name")]
    public string ChannelName { get; init; }

    [JsonPropertyName("badge_tier")]
    public int BadgeTier { get; init; }

    [JsonPropertyName("chat_message")]
    public string ChatMessage { get; init; }

    [JsonPropertyName("time")]
    public DateTime Time { get; init; }
}

