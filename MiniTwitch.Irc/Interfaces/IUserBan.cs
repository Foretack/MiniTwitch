namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a user ban
/// </summary>
public interface IUserBan : IUnixTimestamped
{
    /// <summary>
    /// The target user of the ban
    /// </summary>
    IBanTarget Target { get; }
    /// <summary>
    /// The channel where the event occurred
    /// </summary>
    IBasicChannel Channel { get; }
}
