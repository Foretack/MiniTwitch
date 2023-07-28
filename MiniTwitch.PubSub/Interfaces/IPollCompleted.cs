using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface IPollCompleted
{
    string PollId { get; }
    long OwnedBy { get; }
    long CreatedBy { get; }
    string Title { get; }
    DateTime StartedAt { get; }
    DateTime? EndedAt { get; }
    long? EndedBy { get; }
    long DurationSeconds { get; }
    Poll.PollSettings Settings { get; }
    IReadOnlyList<Poll.Choice> Choices { get; }
    Poll.PollVotes Votes { get; }
    Poll.PollTokens Tokens { get; }
    int TotalVoters { get; }
    string? TopContributor { get; }
    string? TopBitsContributor { get; }
    string? TopChannelPointsContributor { get; }
}
