using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct PredictionToEnd
{
    [JsonIgnore]
    public required long BroadcasterId
    {
        get => long.Parse(_broadcasterId);
        init => _broadcasterId = value.ToString();
    }
    [JsonInclude, JsonPropertyName("broadcaster_id")]
    private readonly string _broadcasterId;

    public required string Id { get; init; }
    public required string Status { get; init; }
    public string WinningOutcomeId { get; init; }
}
