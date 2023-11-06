using MiniTwitch.Common.Interaction;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a new emote-only state
/// </summary>
public interface IEmoteOnlyModified : IHelixChannelTarget
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
    /// <see langword="true"/> if emote-only mode is activated; <see langword="false"/> if deactivated
    /// </summary>
    bool EmoteOnlyEnabled { get; }
}
