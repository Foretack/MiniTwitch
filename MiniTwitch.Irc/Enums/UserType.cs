namespace MiniTwitch.Irc.Enums;

/// <summary>
/// Represents the role of a user
/// </summary>
public enum UserType
{
    /// <summary>
    /// Default value - no roles
    /// </summary>
    None,
    /// <summary>
    /// Local moderator
    /// </summary>
    Mod = 320,
    /// <summary>
    /// Twitch staff
    /// </summary>
    Staff = 532,
    /// <summary>
    /// Global moderator
    /// </summary>
    GlobalModerator = 1598,
    /// <summary>
    /// Twitch admin
    /// </summary>
    Admin = 521
}
