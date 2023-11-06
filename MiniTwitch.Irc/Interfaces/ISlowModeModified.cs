using MiniTwitch.Common.Interaction;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a new slow mode state
/// </summary>
public interface ISlowModeModified : IHelixChannelTarget
{
    /// <summary>
    /// The amount of time a user needs to wait between messages
    /// </summary>
    TimeSpan SlowModeDuration { get; }
    /// <summary>
    /// Username of the channel where the event occurred
    /// </summary>
    string Name { get; }
    /// <summary>
    /// ID of the channel where the event occurred
    /// </summary>
    new long Id { get; }
    /// <summary>
    /// <see langword="true"/> if slow mode is activated; <see langword="false"/> if deactivated
    /// </summary>
    bool SlowModeEnabled { get; }
}
