namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information regarding a received unban
/// </summary>
public interface IUnbanData
{
    /// <summary>
    /// ID of the channel you received the unban in
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// ID of the unbanned user (you)
    /// </summary>
    long TargetId { get; }
}
