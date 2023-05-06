using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct CreatePredictionBody
{
    [JsonIgnore]
    public required long BroadcasterId
    {
        get => long.Parse(_broadcasterId);
        init => _broadcasterId = value.ToString();
    }
    [JsonInclude, JsonPropertyName("broadcaster_id")]
    private readonly string _broadcasterId;
    [JsonPropertyName("title")]
    public required string Title { get; init; }
    [JsonPropertyName("outcomes")]
    public required IEnumerable<Outcome> Outcomes { get; init; }
    [JsonPropertyName("prediction_window")]
    public required int PredictionWindow { get; init; }

    public class Outcome
    {
        [JsonPropertyName("title")]
        public required string Title { get; init; }
    }
}
