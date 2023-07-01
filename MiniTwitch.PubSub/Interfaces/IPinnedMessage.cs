using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface IPinnedMessage
{
    string Id { get; }
    PinnedChatUpdates.UserInfo PinnedBy { get; }
}

public interface IPinnedMessageData
{
    string Id { get; }
    PinnedChatUpdates.MessageSenderInfo Sender { get; }
    PinnedChatUpdates.MessageContent Content { get; }
    string Type { get; }
    long StartsAt { get; }
    long UpdatedAt { get; }
    long EndsAt { get; }
    long SentAt { get; }
}
