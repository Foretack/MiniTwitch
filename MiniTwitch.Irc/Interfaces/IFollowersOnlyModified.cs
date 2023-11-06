using MiniTwitch.Common.Interaction;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a new followers-only state
/// </summary>
public interface IFollowersOnlyModified : IHelixChannelTarget
{
    /// <summary>
    /// Minimum amount of time a user needs to be following in order to chat
    /// </summary>
    TimeSpan FollowerModeDuration { get; }
    /// <summary>
    /// Name of the channel where this event occurred
    /// </summary>
    string Name { get; }
    /// <summary>
    /// ID of the channel where this event occurred
    /// </summary>
    new long Id { get; }
    /// <summary>
    /// <see langword="true"/> if followers-only mode is activated; <see langword="false"/> if deactivated
    /// </summary>
    bool FollowerModeEnabled { get; }
}