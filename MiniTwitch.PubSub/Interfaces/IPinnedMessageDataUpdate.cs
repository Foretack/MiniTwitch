namespace MiniTwitch.PubSub.Interfaces;

public interface IPinnedMessageDataUpdate
{
    string Id { get; }
    long EndsAt { get; }
    long UpdatedAt { get; }
}
