using MiniTwitch.Common.Interaction;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a new unique-messages-only mode state
/// </summary>
public interface IR9KModified : IHelixChannelTarget
{
    /// <summary>
    /// Name of the channel where the event occurred
    /// </summary>
    string Name { get; }
    /// <summary>
    /// ID of the channel where the event occurred
    /// </summary>
    new long Id { get; }
    /// <summary>
    /// <see langword="true"/> if unique mode is activated; <see langword="false"/> if deactivated
    /// </summary>
    bool UniqueModeEnabled { get; }
}