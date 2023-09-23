namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Received data when a commercial break starts
/// </summary>
public interface ICommercialBreak
{
    /// <summary>
    /// UNIX timestamp of when this event occured
    /// </summary>
    double ServerTime { get; }
    /// <summary>
    /// Commercial length in seconds
    /// </summary>
    int Length { get; }
    /// <summary>
    /// Whether the commercial was scheduled or not
    /// </summary>
    bool Scheduled { get; }
}
