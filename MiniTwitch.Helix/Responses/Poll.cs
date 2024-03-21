using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Poll : BaseResponse<Poll.Info>
{
    public record Choice(
        string Id,
        string Title,
        int Votes,
        int ChannelPointsVotes
    );

    public record Info(
        string Id,
        long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        string Title,
        IReadOnlyList<Choice> Choices,
        bool ChannelPointsVotingEnabled,
        int ChannelPointsPerVote,
        string Status,
        int Duration,
        DateTime StartedAt,
        DateTime? EndedAt
    );
}