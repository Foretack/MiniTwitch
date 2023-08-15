namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information regarding a received ban
/// </summary>
public interface IBanData
{
    /// <summary>
    /// ID of the channel you received the ban in
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// Reason for the received ban
    /// <para>Null if no reason is provided</para>
    /// </summary>
    string? Reason { get; }
    /// <summary>
    /// ID of the banned user (you)
    /// </summary>
    long TargetId { get; }
}
