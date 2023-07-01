using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface IPredictionLocked
{
    string Id { get; }
    long ChannelId { get; }
    DateTime CreatedAt { get; }
    ChannelPredictions.User CreatedBy { get; }
    DateTime? LockedAt { get; }
    ChannelPredictions.User? LockedBy { get; }
    IReadOnlyList<ChannelPredictions.Outcome> Outcomes { get; }
    int PredictionWindowSeconds { get; }
    string Title { get; }
}
