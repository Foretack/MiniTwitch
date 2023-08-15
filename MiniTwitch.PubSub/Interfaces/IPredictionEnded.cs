using System.Diagnostics.CodeAnalysis;
using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a prediction that ended when an outcome was chosen
/// </summary>
public interface IPredictionEnded
{
    /// <summary>
    /// ID of the prediction
    /// </summary>
    string Id { get; }
    /// <summary>
    /// ID of the prediction's channel
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// Time when the prediction was created
    /// </summary>
    DateTime CreatedAt { get; }
    /// <summary>
    /// Information about the user that created the prediction
    /// </summary>
    ChannelPredictions.User CreatedBy { get; }
    /// <summary>
    /// Time when the prediction ended
    /// <para>This property is not null in this interface</para>
    /// </summary>
    [NotNull]
    DateTime? EndedAt { get; }
    /// <summary>
    /// Information about the user that ended the prediction
    /// <para>This property is not null in this interface</para>
    /// </summary>
    [NotNull]
    ChannelPredictions.User? EndedBy { get; }
    /// <summary>
    /// Time when the prediction was locked
    /// <para>This property is not null in this interface</para>
    /// </summary>
    [MemberNotNullWhen(true)]
    DateTime? LockedAt { get; }
    /// <summary>
    /// Information about the user that locked the prediction
    /// <para>This property is null if the prediction was not locked manually</para>
    /// </summary>
    ChannelPredictions.User? LockedBy { get; }
    /// <summary>
    /// The possible outcomes for the prediction
    /// </summary>
    IReadOnlyList<ChannelPredictions.Outcome> Outcomes { get; }
    /// <summary>
    /// Title of the prediction
    /// </summary>
    string Title { get; }
    /// <summary>
    /// ID of the outcome in <see cref="Outcomes"/> that won
    /// </summary>
    string WinningOutcomeId { get; }
}
