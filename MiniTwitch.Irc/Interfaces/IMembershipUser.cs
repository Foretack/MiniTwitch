namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Represents a user in twitch.tv/membership messages
/// </summary>
public interface IMembershipUser
{
    /// <summary>
    /// The user's name
    /// </summary>
    public string Name { get; }
}
