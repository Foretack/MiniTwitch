using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents updates of a prediction
/// </summary>
public interface IPredictionUpdate
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
    /// The possible outcomes for the prediction
    /// </summary>
    IReadOnlyList<ChannelPredictions.Outcome> Outcomes { get; }
    /// <summary>
    /// The time window for users to predict an outcome
    /// <para>Note: This value does not update to reflect the remaining time</para>
    /// </summary>
    int PredictionWindowSeconds { get; }
    /// <summary>
    /// Title of the prediction
    /// </summary>
    string Title { get; }
}
