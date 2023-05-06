using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct EndPredictionBody
{
    [JsonIgnore]
    public required long BroadcasterId
    {
        get => long.Parse(_broadcasterId);
        init => _broadcasterId = value.ToString();
    }
    [JsonInclude, JsonPropertyName("broadcaster_id")]
    private readonly string _broadcasterId;

    [JsonPropertyName("id")]
    public required string Id { get; init; }
    [JsonPropertyName("status")]
    public required string Status { get; init; }
    [JsonPropertyName("winning_outcome_id")]
    public string WinningOutcomeId { get; init; }
}
