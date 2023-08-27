using MiniTwitch.PubSub.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a prediction that just started
/// </summary>
public interface IPredictionStarted
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
    /// </summary>
    int PredictionWindowSeconds { get; }
    /// <summary>
    /// Title of the prediction
    /// </summary>
    string Title { get; }
}
