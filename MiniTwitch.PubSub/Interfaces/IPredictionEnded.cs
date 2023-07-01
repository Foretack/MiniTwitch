using MiniTwitch.PubSub.Models.Payloads;

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
    ChannelPredictions.User CreatedBy { get; }
    DateTime? EndedAt { get; }
    ChannelPredictions.User? EndedBy { get; }
    DateTime? LockedAt { get; }
    IReadOnlyList<ChannelPredictions.Outcome> Outcomes { get; }
    int PredictionWindowSeconds { get; }
    string Title { get; }
    string WinningOutcomeId { get; }
}
