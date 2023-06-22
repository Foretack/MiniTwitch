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
    /// ID of the first message in the thread of the replied-to message
    /// <para>This value is equal to <see cref="ParentMessageId"/> if the replied-to message is not in a thread</para>
    /// </summary>
    public string ParentThreadMessageId { get; init; }
    /// <summary>
    /// Username of the first message's author in the thread of the replied-to message
    /// <para>This value is equal to <see cref="ParentUsername"/> if the replied-to message is not in a thread</para>
    /// </summary>
    public string ParentThreadUsername { get; init; }
    /// <summary>
    /// Whether there are reply contents in this message
    /// </summary>
    public bool HasContent { get; init; }

    /// <inheritdoc/>
    public static implicit operator string(MessageReply messageReply) => messageReply.HasContent ? messageReply.ParentMessage : string.Empty;
    /// <inheritdoc/>
    public static implicit operator bool(MessageReply messageReply) => messageReply.HasContent;
}
