namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information regarding a received un-timeout
/// </summary>
public interface IUntimeOutData
{
    /// <summary>
    /// ID of the channel you received the un-timeout in
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// ID of the un-timed out user (you)
    /// </summary>
    long TargetId { get; }
}
