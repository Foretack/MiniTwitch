using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Payloads;

/// <summary>
/// Represents a channel's follower
/// </summary>
public readonly record struct Follower
{
    /// <summary>
    /// Display name of the follower
    /// </summary>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; init; }
    /// <summary>
    /// Name of the follower
    /// </summary>
    [JsonPropertyName("username")]
    public string Name { get; init; }
    /// <summary>
    /// ID of the follower
    /// </summary>
    [JsonPropertyName("user_id")]
    public long Id { get; init; }
}
