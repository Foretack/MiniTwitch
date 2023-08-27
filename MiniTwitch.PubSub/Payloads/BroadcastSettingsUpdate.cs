using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Payloads;

/// <inheritdoc/>
public readonly struct BroadcastSettingsUpdate : ITitleChange, IGameChange
{
    /// <inheritdoc/>

    [JsonPropertyName("channel")]
    public string Channel { get; init; }
    /// <inheritdoc/>
    [JsonPropertyName("channel_id")]
    public long ChannelId { get; init; }
    /// <inheritdoc/>
    [JsonPropertyName("old_status")]
    public string OldTitle { get; init; }
    /// <inheritdoc/>
    [JsonPropertyName("status")]
    public string NewTitle { get; init; }
    /// <inheritdoc/>
    [JsonPropertyName("old_game")]
    public string OldGame { get; init; }
    /// <inheritdoc/>
    [JsonPropertyName("game")]
    public string NewGame { get; init; }
    /// <inheritdoc/>
    [JsonPropertyName("old_game_id")]
    public long OldGameId { get; init; }
    /// <inheritdoc/>
    [JsonPropertyName("game_id")]
    public long NewGameId { get; init; }
}
