using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class NewPrediction
{
    [JsonConverter(typeof(LongConverter))]
    public long BroadcasterId { get; }
    public string Title { get; }
    public IEnumerable<Outcome> Outcomes { get; }
    [JsonConverter(typeof(TimeSpanToSeconds))]
    public TimeSpan PredictionWindow { get; }

    public class Outcome
    {
        public string Title { get; }

        public Outcome(string title)
        {
            this.Title = title;
        }
    }

    public NewPrediction(
        long broadcasterId,
        string title,
        IEnumerable<string> outcomes,
        TimeSpan predictionWindow
    )
    {
        this.BroadcasterId = broadcasterId;
        this.Title = title;
        this.Outcomes = outcomes.Select(x => new Outcome(x));
        this.PredictionWindow = predictionWindow;
    }
}
