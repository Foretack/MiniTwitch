using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models;

public readonly record struct BitsBadgeUnlockPayload(
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("user_name")] string Username,
        [property: JsonPropertyName("channel_id")] long ChannelId,
        [property: JsonPropertyName("channel_name")] string ChannelName,
        [property: JsonPropertyName("badge_tier")] int BadgeTier,
        [property: JsonPropertyName("chat_message")] string ChatMessage,
        [property: JsonPropertyName("time")] DateTime Time
);
