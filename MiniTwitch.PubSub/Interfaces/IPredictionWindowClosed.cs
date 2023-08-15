using System.Diagnostics.CodeAnalysis;
using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a prediction that was automatically locked
/// </summary>
public interface IPredictionWindowClosed
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
    /// Time when the prediction was locked
    /// <para>This property is not null in this interface</para>
    /// </summary>
    [MemberNotNullWhen(true)]
    DateTime? LockedAt { get; }
    /// <summary>
    /// The possible outcomes for the prediction
    /// </summary>
    IReadOnlyList<ChannelPredictions.Outcome> Outcomes { get; }
    /// <summary>
    /// The time window for users to predict an outcome - which is now over
    /// </summary>
    int PredictionWindowSeconds { get; }
    /// <summary>
    /// Title of the prediction
    /// </summary>
    string Title { get; }
}
