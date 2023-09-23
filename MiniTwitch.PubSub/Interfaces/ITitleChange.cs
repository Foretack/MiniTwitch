namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information regarding a title change
/// </summary>
public interface ITitleChange
{
    /// <summary>
    /// Name of the channel that changed title
    /// </summary>
    string Channel { get; }
    /// <summary>
    /// ID of the channel that changed title
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// The previous title
    /// </summary>
    string OldTitle { get; }
    /// <summary>
    /// The newly set title
    /// </summary>
    string NewTitle { get; }
}
