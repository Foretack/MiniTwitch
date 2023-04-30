namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about the author of a deleted message
/// </summary>
public interface IDeletedMessageAuthor
{
    /// <summary>
    /// Username of the deleted message's sender
    /// </summary>
    string Name { get; }
}
