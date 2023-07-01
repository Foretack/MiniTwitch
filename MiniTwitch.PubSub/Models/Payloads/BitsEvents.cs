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

    public readonly record struct BadgeEntitlement(
        [property: JsonPropertyName("new_version")] int NewVersion,
        [property: JsonPropertyName("previous_version")] int PreviousVersion
    );

    public readonly record struct BitsData(
        [property: JsonPropertyName("user_name")] string? Username,
        [property: JsonPropertyName("channel_name")] string ChannelName,
        [property: JsonPropertyName("user_id")] long? UserId,
        [property: JsonPropertyName("channel_id")] long ChannelId,
        [property: JsonPropertyName("time")] DateTime Time,
        [property: JsonPropertyName("chat_message")] string ChatMessage,
        [property: JsonPropertyName("bits_used")] int BitsUsed,
        [property: JsonPropertyName("total_bits_used")] int TotalBitsUsed,
        [property: JsonPropertyName("context")] string Context,
        [property: JsonPropertyName("badge_entitlement")] BadgeEntitlement? BadgeEntitlement
    );
}
