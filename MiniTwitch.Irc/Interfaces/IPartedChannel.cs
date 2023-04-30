namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a parted channel
/// </summary>
public interface IPartedChannel
{
    /// <summary>
    /// The parted channel's username
    /// </summary>
    string Name { get; }
}
