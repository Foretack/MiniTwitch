using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a message that was unpinned
/// </summary>
public interface IModUnpinnedMessage
{
    /// <summary>
    /// ID of the "pinned message" event
    /// </summary>
    string Id { get; }
    /// <summary>
    /// The user than unpinned the message
    /// </summary>
    PinnedChatUpdates.UserInfo UnpinnedBy { get; }
    /// <summary>
    /// Reason for the unpin
    /// </summary>
    string Reason { get; }
}
