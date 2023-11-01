using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct NewPoll
{
    [JsonConverter(typeof(LongToString))]
    public required long BroadcasterId { get; init; }
    public required string Title { get; init; }
    public required IEnumerable<Choice> Choices { get; init; }
    [JsonConverter(typeof(TimeSpanToSeconds))]
    public required TimeSpan Duration { get; init; }
    public bool? ChannelPointsVotingEnabled { get; init; }
    public int? ChannelPointsPerVote { get; init; }

    public class Choice
    {
        public required string Title { get; init; }
    }
}
