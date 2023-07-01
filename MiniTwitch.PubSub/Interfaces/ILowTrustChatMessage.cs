using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface ILowTrustChatMessage
{
    LowTrustUser.LowTrustUserData LowTrustUserInfo { get; }
    LowTrustUser.MessageContentData MessageContent { get; }
    string MessageId { get; }
    DateTime SentAt { get; }
}
