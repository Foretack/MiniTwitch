using MiniTwitch.PubSub.Models;

namespace MiniTwitch.PubSub.Interfaces;

public interface IPredictionStarted
{
    string Id { get; }
    long ChannelId { get; }
    DateTime CreatedAt { get; }
    ChannelPredictionsPayload.User CreatedBy { get; }
    IReadOnlyList<ChannelPredictionsPayload.Outcome> Outcomes { get; }
    int PredictionWindowSeconds { get; }
    string Title { get; }
}
