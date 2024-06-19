namespace MiniTwitch.Irc.Enums;

/// <summary>
/// Enum that holds possible animations for animated messages
/// </summary>
public enum AnimationId
{
    /// <summary>
    /// Fallback value, do not use this.
    /// </summary>
    UNKNOWN,
    /// <summary>
    /// None; Message is not animated.
    /// </summary>
    None,
    /// <summary>
    /// "simmer"
    /// </summary>
    Simmer,
    /// <summary>
    /// "rainbow-eclipse"
    /// </summary>
    RainbowEclipse,
}
