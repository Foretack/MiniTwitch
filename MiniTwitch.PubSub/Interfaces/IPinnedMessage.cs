﻿using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a pinned message event
/// </summary>
public interface IPinnedMessage
{
    /// <summary>
    /// ID of this event
    /// <para>Note: This is not the message's ID</para>
    /// </summary>
    string Id { get; }
    /// <summary>
    /// Represents information about the user that pinned the message
    /// </summary>
    PinnedChatUpdates.UserInfo PinnedBy { get; }
}

/// <summary>
/// Represents information about the message that was pinned
/// </summary>
public interface IPinnedMessageData
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
    /// The type of user that pinned the message.
    /// <para>If the value is not "MOD", then the message is likely a hypechat-pinned message</para>
    /// </summary>
    string Type { get; }
    /// <summary>
    /// Timestamp of when the message was pinned
    /// </summary>
    long StartsAt { get; }
    /// <summary>
    /// Timestamp of when the "pin event" was last updated
    /// </summary>
    long UpdatedAt { get; }
    /// <summary>
    /// Timestamp of when the message is automatically unpinned
    /// </summary>
    long EndsAt { get; }
    /// <summary>
    /// Timestamp of when the message was sent
    /// </summary>
    long SentAt { get; }
}
