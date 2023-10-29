namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information regarding a received timeout
/// </summary>
public interface ITimeOutData
{
    /// <summary>
    /// ID of the channel you received the timeout in
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// Time when the timeout expires
    /// </summary>
    DateTime ExpiresAt { get; }
    /// <summary>
    /// Time when the timeout expires in milliseconds
    /// </summary>
    long ExpiresInMs { get; }
    /// <summary>
    /// Reason for the received timeout
    /// <para>Null if no reason is provided</para>
    /// </summary>
    string? Reason { get; }
    /// <summary>
    /// ID of the timed-out user (you)
    /// </summary>
    long TargetId { get; }
}
