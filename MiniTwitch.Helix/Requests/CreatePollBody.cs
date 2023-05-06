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
    [JsonPropertyName("title")]
    public required string Title { get; init; }
    [JsonPropertyName("choices")]
    public required IEnumerable<Choice> Choices { get; init; }
    [JsonPropertyName("duration")]
    public required int Duration { get; init; }
    [JsonPropertyName("channel_points_voting_enabled")]
    public bool ChannelPointsVotingEnabled { get; init; }
    [JsonPropertyName("channel_points_per_vote")]
    public int ChannelPointsPerVote { get; init; }

    public class Choice
    {
        [JsonPropertyName("title")]
        public required string Title { get; init; }
    }
}
