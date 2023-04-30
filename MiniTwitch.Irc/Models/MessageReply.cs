namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents data for a message that is being replied to
/// </summary>
public readonly struct MessageReply
{
    /// <summary>
    /// Display name of the original message's author
    /// </summary>
    public string ParentDisplayName { get; init; }
    /// <summary>
    /// Content of the original message
    /// </summary>
    public string ParentMessage { get; init; }
    /// <summary>
    /// Unique ID to identify the original message
    /// </summary>
    public string ParentMessageId { get; init; }
    /// <summary>
    /// Name of the original message's author
    /// </summary>
    public string ParentUsername { get; init; }
    /// <summary>
    /// ID of the original message's author
    /// </summary>
    public long ParentUserId { get; init; }
    /// <summary>
    /// Whether there are reply contents in this message
    /// </summary>
    public bool HasContent { get; init; }

    /// <inheritdoc/>
    public static implicit operator string(MessageReply messageReply) => messageReply.HasContent ? messageReply.ParentMessage : string.Empty;
    /// <inheritdoc/>
    public static implicit operator bool(MessageReply messageReply) => messageReply.HasContent;
}
