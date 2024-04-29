using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class NewPoll
{
    [JsonConverter(typeof(LongConverter))]
    public long BroadcasterId { get; }
    public string Title { get; }
    public IEnumerable<Choice> Choices { get; }
    [JsonConverter(typeof(TimeSpanToSeconds))]
    public TimeSpan Duration { get; }
    public bool? ChannelPointsVotingEnabled { get; }
    public int? ChannelPointsPerVote { get; }

    public class Choice
    {
        public string Title { get; }

        public Choice(string title)
        {
            this.Title = title;
        }
    }

    public NewPoll(
        long broadcasterId,
        string title,
        IEnumerable<string> choices,
        TimeSpan duration,
        bool? channelPointsVotingEnabled = null,
        int? channelPointsPerVote = null
    )
    {
        this.BroadcasterId = broadcasterId;
        this.Title = title;
        this.Choices = choices.Select(x => new Choice(x));
        this.Duration = duration;
        this.ChannelPointsVotingEnabled = channelPointsVotingEnabled;
        this.ChannelPointsPerVote = channelPointsPerVote;
    }
}
