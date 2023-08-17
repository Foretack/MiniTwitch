using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

/// <summary>
/// Information received when a user's message held by AutoMod has been approved or denied
/// </summary>
public readonly struct ModerationNotificationMessage
{
    /// <summary>
    /// Known values: automod_caught_message
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// <summary>
    /// Information about the caught message
    /// </summary>
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly struct PayloadData
    {
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; }
    }

}
