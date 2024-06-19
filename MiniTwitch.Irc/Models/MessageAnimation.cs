using MiniTwitch.Irc.Enums;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Struct that holds information about message animations
/// </summary>
public readonly struct MessageAnimation
{
    /// <summary>
    /// Whether the message is animated
    /// </summary>
    public bool IsAnimated { get; init; }
    /// <summary>
    /// Message animation
    /// </summary>
    public AnimationId AnimationId { get; init; }
}
