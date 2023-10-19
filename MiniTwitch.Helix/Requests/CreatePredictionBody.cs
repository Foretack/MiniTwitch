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
    public required string Title { get; init; }
    public required IEnumerable<Outcome> Outcomes { get; init; }
    public required int PredictionWindow { get; init; }

    public class Outcome
    {
        public required string Title { get; init; }
    }
}
