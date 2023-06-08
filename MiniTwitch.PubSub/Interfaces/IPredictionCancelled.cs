using MiniTwitch.PubSub.Models;

namespace MiniTwitch.PubSub.Interfaces;

public interface IPredictionCancelled
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
}
