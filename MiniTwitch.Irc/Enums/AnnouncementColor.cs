namespace MiniTwitch.Irc.Enums;

/// <summary>
/// Represents the color of an announcement message
/// </summary>
public enum AnnouncementColor
{
    /// <summary>
    /// Default enum value
    /// </summary>
    Unknown,
    /// <summary>
    /// Slightly lighter <see cref="Orange"/>
    /// </summary>
    Primary = 80 + 82 + 73 + 77 + 65 + 82 + 89,
    /// <summary>
    /// The color blue
    /// </summary>
    Blue = 66 + 76 + 85 + 69,
    /// <summary>
    /// The color green
    /// </summary>
    Green = 71 + 82 + 69 + 69 + 78,
    /// <summary>
    /// The color orange
    /// </summary>
    Orange = 79 + 82 + 65 + 78 + 71 + 69,
    /// <summary>
    /// The color purple
    /// </summary>
    Purple = 80 + 85 + 82 + 80 + 76 + 69
}
