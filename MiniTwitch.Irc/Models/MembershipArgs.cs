using MiniTwitch.Irc.Interfaces;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents information about a membership event
/// </summary>
public readonly struct MembershipArgs
{
    /// <inheritdoc cref="IMembershipUser"/>
    public IMembershipUser User { get; init; }
    /// <summary>
    /// The channel where the event occurred
    /// </summary>
    public IGazatuChannel Channel { get; init; }
}
