namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a chat that has been cleared
/// </summary>
public interface IChatClear : IUnixTimestamped
{
    /// <summary>
    /// The channel where the event occurred
    /// </summary>
    IBasicChannel Channel { get; }
}
