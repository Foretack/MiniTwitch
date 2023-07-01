using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface IUnpinnedMessage
{
    string Id { get; }
    PinnedChatUpdates.UserInfo UnpinnedBy { get; }
    string Reason { get; }
}
