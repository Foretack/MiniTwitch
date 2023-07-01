using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct ModerationNotificationMessage
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly record struct PayloadData(
        [property: JsonPropertyName("message_id")] string MessageId,
        [property: JsonPropertyName("status")] string Status
    );
}
