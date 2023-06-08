using MiniTwitch.PubSub.Models;

namespace MiniTwitch.PubSub.Interfaces;

public interface IPredictionWindowClosed
{
    string Id { get; }
    long ChannelId { get; }
    DateTime CreatedAt { get; }
    ChannelPredictionsPayload.User CreatedBy { get; }
    DateTime? LockedAt { get; }
    IReadOnlyList<ChannelPredictionsPayload.Outcome> Outcomes { get; }
    int PredictionWindowSeconds { get; }
    string Title { get; }
}
