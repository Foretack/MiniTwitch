namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a stream's game changing
/// </summary>
public interface IGameChange
{
    /// <summary>
    /// Name of the channel where this event occurred
    /// </summary>
    string Channel { get; }
    /// <summary>
    /// ID of the channel where this event occured
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// Name of the old stream game
    /// </summary>
    string OldGame { get; }
    /// <summary>
    /// Name of the new stream game
    /// </summary>
    string NewGame { get; }
    /// <summary>
    /// ID of the old stream game
    /// </summary>
    long OldGameId { get; }
    /// <summary>
    /// ID of the new stream game
    /// </summary>
    long NewGameId { get; }
}
