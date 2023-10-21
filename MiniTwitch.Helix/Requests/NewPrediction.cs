using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct NewPrediction
{
    [JsonConverter(typeof(LongToString))]
    public required long BroadcasterId { get; init; }
    public required string Title { get; init; }
    public required IEnumerable<Outcome> Outcomes { get; init; }
    [JsonConverter(typeof(TimeSpanToSeconds))]
    public required TimeSpan PredictionWindow { get; init; }

    public class Outcome
    {
        public required string Title { get; init; }
    }
}
