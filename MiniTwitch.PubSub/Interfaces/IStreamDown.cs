namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a stream that just ended
/// </summary>
public interface IStreamDown
{
    /// <summary>
    /// Server-side unix timestamp of when the stream went offline
    /// </summary>
    double ServerTime { get; }
}
