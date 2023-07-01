using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct BroadcastSettingsUpdate
{
    [JsonPropertyName("channel")]
    public string Channel { get; init; }
    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; }
    [JsonPropertyName("old_status")]
    public string OldTitle { get; init; }
    [JsonPropertyName("status")]
    public string NewTitle { get; init; }
    [JsonPropertyName("old_game")]
    public string OldGame { get; init; }
    [JsonPropertyName("game")]
    public string NewGame { get; init; }
    [JsonPropertyName("old_game_id")]
    public long OldGameId { get; init; }
    [JsonPropertyName("game_id")]
    public long NewGameId { get; init; }
}
