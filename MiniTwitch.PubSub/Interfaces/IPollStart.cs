using MiniTwitch.PubSub.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a poll that was just created
/// </summary>
public interface IPollCreated
{
    /// <summary>
    /// ID of the poll
    /// </summary>
    string PollId { get; }
    /// <summary>
    /// ID of the poll's channel
    /// </summary>
    long OwnedBy { get; }
    /// <summary>
    /// ID of the user that created the poll
    /// </summary>
    long CreatedBy { get; }
    /// <summary>
    /// The poll's title
    /// </summary>
    string Title { get; }
    /// <summary>
    /// Time when the poll was created
    /// </summary>
    DateTime StartedAt { get; }
    /// <summary>
    /// The voting window for the poll
    /// </summary>
    long DurationSeconds { get; }
    /// <summary>
    /// The voting settings of the poll
    /// </summary>
    Poll.PollSettings Settings { get; }
    /// <summary>
    /// Available voting choices
    /// </summary>
    IReadOnlyList<Poll.Choice> Choices { get; }
}
