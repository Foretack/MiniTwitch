using MiniTwitch.PubSub.Models;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// 
/// </summary>
// This is the 2nd payload, distinguished by Outcomes.TopPredictors.Result.PointsWon being not null/default
public interface IPredictionEnded
{
    string Id { get; }
    long ChannelId { get; }
    DateTime CreatedAt { get; }
    ChannelPredictionsPayload.User CreatedBy { get; }
    DateTime? EndedAt { get; }
    ChannelPredictionsPayload.User? EndedBy { get; }
    DateTime? LockedAt { get; }
    IReadOnlyList<ChannelPredictionsPayload.Outcome> Outcomes { get; }
    int PredictionWindowSeconds { get; }
    string Title { get; }
    string WinningOutcomeId { get; }
}
