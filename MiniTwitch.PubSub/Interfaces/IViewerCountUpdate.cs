namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents viewer count information for an online stream
/// </summary>
public interface IViewerCountUpdate
{
    /// <summary>
    /// Server-side unix timestamp of when this data was sent
    /// </summary>
    double ServerTime { get; }
    /// <summary>
    /// The amount of viewers currently watching the stream
    /// </summary>
    int Viewers { get; }
}
