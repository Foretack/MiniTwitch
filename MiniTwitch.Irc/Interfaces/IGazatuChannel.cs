namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Tiny interface containing only the name of a channel
/// <para><see href="https://www.urbandictionary.com/define.php?term=gazatu"/></para>
/// </summary>
public interface IGazatuChannel
{
    /// <summary>
    /// The channel's username
    /// </summary>
    string Name { get; }
}
