using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a suspicious chat user
/// </summary>
public interface ILowTrustChatMessage
{
    /// <summary>
    /// Information about the suspected user
    /// </summary>
    LowTrustUser.LowTrustUserData LowTrustUserInfo { get; }
    /// <summary>
    /// Content information about the message the user sent
    /// </summary>
    LowTrustUser.MessageContentData MessageContent { get; }
    /// <summary>
    /// ID of the message sent
    /// </summary>
    string MessageId { get; }
    /// <summary>
    /// Timestamp of when the message was sent
    /// </summary>
    DateTime SentAt { get; }
}
