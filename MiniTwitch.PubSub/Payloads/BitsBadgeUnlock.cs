using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Payloads;

/// <summary>
/// Portrays information about an announced bits badge unlock
/// </summary>
public readonly struct BitsBadgeUnlock
{
    /// <summary>
    /// ID of the user that unlocked the new badge
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }
    /// <summary>
    /// Name of the user that unlocked the new badge
    /// </summary>
    [JsonPropertyName("user_name")]
    public string Username { get; init; }
    /// <summary>
    /// ID of the channel where this event took place
    /// </summary>
    [JsonPropertyName("channel_id")]
    public long ChannelId { get; init; }
    /// <summary>
    /// Name of the channem where this event took place
    /// </summary>
    [JsonPropertyName("channel_name")]
    public string ChannelName { get; init; }
    /// <summary>
    /// Value of Bits badge tier that was earned (1000, 10000, etc.)
    /// </summary>
    [JsonPropertyName("badge_tier")]
    public int BadgeTier { get; init; }
    /// <summary>
    /// [Optional] Custom message included with share
    /// </summary>
    [JsonPropertyName("chat_message")]
    public string ChatMessage { get; init; }
    /// <summary>
    /// Time when the new Bits badge was earned
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime Time { get; init; }
}

