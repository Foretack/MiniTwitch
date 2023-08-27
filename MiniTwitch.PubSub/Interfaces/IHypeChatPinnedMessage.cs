using MiniTwitch.PubSub.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a Hype Chat pinned message event
/// </summary>
public interface IHypeChatPinnedMessage
{
    /// <summary>
    /// ID of this event
    /// <para>Note: This is not the message's ID</para>
    /// </summary>
    string Id { get; }
    /// <summary>
    /// Represents the user that sent the Hype Chat message
    /// </summary>
    PinnedChatUpdates.UserInfo PinnedBy { get; }
}

/// <summary>
/// Represents information about the Hype Chat message that was pinned
/// </summary>
public interface IHypeChatPinnedMessageData
{
    /// <summary>
    /// ID of the message
    /// </summary>
    string Id { get; }
    /// <summary>
    /// The user that sent the message
    /// </summary>
    PinnedChatUpdates.MessageSenderInfo Sender { get; }
    /// <summary>
    /// Content of the message
    /// </summary>
    PinnedChatUpdates.MessageContent Content { get; }
    /// <summary>
    /// Timestamp of when the message was pinned
    /// </summary>
    long StartsAt { get; }
    /// <summary>
    /// Timestamp of when the message is automatically unpinned
    /// </summary>
    long EndsAt { get; }
    /// <summary>
    /// Timestamp of when the message was sent
    /// </summary>
    long SentAt { get; }
    /// <summary>
    /// Represents information about Hype Chat data
    /// </summary>
    PinnedChatUpdates.PaidMessageMetadata? Metadata { get; }
}
