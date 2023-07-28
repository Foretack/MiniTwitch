using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface IPollUpdated
{
    string PollId { get; }
    long OwnedBy { get; }
    long CreatedBy { get; }
    string Title { get; }
    DateTime StartedAt { get; }
    long DurationSeconds { get; }
    Poll.PollSettings Settings { get; }
    IReadOnlyList<Poll.Choice> Choices { get; }
    Poll.PollVotes Votes { get; }
    Poll.PollTokens Tokens { get; }
    int TotalVoters { get; }
    long RemainingDurationMilliseconds { get; }
    string? TopContributor { get; }
    string? TopBitsContributor { get; }
    string? TopChannelPointsContributor { get; }
}
