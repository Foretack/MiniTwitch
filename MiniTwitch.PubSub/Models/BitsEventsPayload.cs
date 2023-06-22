using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models;

public readonly record struct BitsEventsPayload(
    [property: JsonPropertyName("data")] BitsData Data,
    [property: JsonPropertyName("version")] string Version,
    [property: JsonPropertyName("message_type")] string MessageType,
    [property: JsonPropertyName("message_id")] string MessageId,
    [property: JsonPropertyName("is_anonymous")] bool IsAnonymous
);

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
