namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Interface for IRC messages with the "tmi-sent-ts" tag
/// </summary>
public interface IUnixTimestamped
{
    /// <summary>
    /// Milliseconds Unix timestamp of when the message was sent
    /// </summary>
    long TmiSentTs { get; }
    /// <summary>
    /// Gets TmiSentTs as <see cref="DateTimeOffset"/>
    /// </summary>
    DateTimeOffset SentTimestamp { get; }
}
