using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents updates of a poll
/// </summary>
public interface IPollUpdated
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
    /// The voting settings of the poll
    /// </summary>
    Poll.PollSettings Settings { get; }
    /// <summary>
    /// The poll's choices
    /// </summary>
    IReadOnlyList<Poll.Choice> Choices { get; }
    /// <summary>
    /// Information about the votes
    /// </summary>
    Poll.PollVotes Votes { get; }
    /// <summary>
    /// Total bits/points that have been used
    /// </summary>
    Poll.PollTokens Tokens { get; }
    /// <summary>
    /// The total amount of users that voted
    /// </summary>
    int TotalVoters { get; }
    /// <summary>
    /// The remaining time for voting in the poll
    /// </summary>
    long RemainingDurationMilliseconds { get; }
    /// <summary>
    /// The data type and use of this property is unknown
    /// </summary>
    object? TopContributor { get; }
    /// <summary>
    /// The user that spent the most amount of bits in voting
    /// <para>The data type of this property is unknown</para>
    /// </summary>
    object? TopBitsContributor { get; }
    /// <summary>
    /// The user that spent the most amount of channel points in voting
    /// <para>The data type of this property is unknown</para>
    /// </summary>
    object? TopChannelPointsContributor { get; }
}
