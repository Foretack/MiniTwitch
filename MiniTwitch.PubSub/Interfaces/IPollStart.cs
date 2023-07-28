using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface IPollCreated
{
    string PollId { get; }
    long OwnedBy { get; }
    long CreatedBy { get; }
    string Title { get; }
    DateTime StartedAt { get; }
    long DurationSeconds { get; }
    Poll.PollSettings Settings { get; }
    IReadOnlyList<Poll.Choice> Choices { get; }
    long RemainingDurationMilliseconds { get; }
}
