namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a pinned message that was updated
/// </summary>
public interface IModPinnedMessageDataUpdate
{
    /// <summary>
    /// ID of the message
    /// </summary>
    string Id { get; }
    /// <summary>
    /// Timestamp of when the message is automatically unpinned
    /// </summary>
    long EndsAt { get; }
    /// <summary>
    /// Timestamp of when the "pin event" was last updated
    /// </summary>
    long UpdatedAt { get; }
}
