using MiniTwitch.Irc.Models;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains shared USERNOTICE tags
/// </summary>
public interface IUsernotice : IUnixTimestamped
{
    /// <summary>
    /// Author of the event
    /// </summary>
    MessageAuthor Author { get; }
    /// <summary>
    /// The channel where the event occurred
    /// </summary>
    IBasicChannel Channel { get; }
    /// <summary>
    /// Unique ID to identify the event's message
    /// </summary>
    string Id { get; }
}
