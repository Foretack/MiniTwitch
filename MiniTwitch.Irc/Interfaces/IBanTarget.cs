using MiniTwitch.Common.Interaction;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a user ban
/// </summary>
public interface IBanTarget : IHelixUserTarget
{
    /// <summary>
    /// Username of the user receiving the ban
    /// </summary>
    string Name { get; }
    /// <summary>
    /// ID of the user receiving the ban
    /// </summary>
    new long Id { get; }
}
