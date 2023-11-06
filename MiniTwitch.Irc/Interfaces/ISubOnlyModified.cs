using MiniTwitch.Common.Interaction;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a new sub-only mode state
/// </summary>
public interface ISubOnlyModified : IHelixChannelTarget
{
    /// <summary>
    /// Username of the channel where the event occurred
    /// </summary>
    string Name { get; }
    /// <summary>
    /// ID of the channel where the event occurred
    /// </summary>
    new long Id { get; }
    /// <summary>
    /// <see langword="true"/> if sub-only mode is activated; <see langword="false"/> if deactivated
    /// </summary>
    bool SubOnlyEnabled { get; }
}
