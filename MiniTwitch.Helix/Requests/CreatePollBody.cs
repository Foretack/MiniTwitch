using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct CreatePollBody
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
    public required IEnumerable<Choice> Choices { get; init; }
    public required int Duration { get; init; }
    public bool ChannelPointsVotingEnabled { get; init; }
    public int ChannelPointsPerVote { get; init; }

    public class Choice
    {
        public required string Title { get; init; }
    }
}
