namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about a user ban
/// </summary>
public interface IBanTarget
{
    /// <summary>
    /// Username of the user receiving the ban
    /// </summary>
    string Name { get; }
    /// <summary>
    /// ID of the user receiving the ban
    /// </summary>
    long Id { get; }
}
