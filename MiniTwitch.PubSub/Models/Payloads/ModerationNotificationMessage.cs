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
    public CaughtMessageData Data { get; init; }
}

/// <summary>
/// Contains information about the caught message
/// </summary>
public readonly struct CaughtMessageData
{
    /// <summary>
    /// ID of the caught message
    /// </summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; init; }
    /// <summary>
    /// Current status of the message, can be “PENDING”, “ALLOWED”, “DENIED”, or “EXPIRED”
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; init; }
}
