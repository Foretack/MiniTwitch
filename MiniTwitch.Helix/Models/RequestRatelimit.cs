namespace MiniTwitch.Helix.Models;

public readonly record struct RequestRatelimit
{
    /// <summary>
    /// Maximum amount of requests that can be made in period
    /// </summary>
    public required int Limit { get; init; }
    /// <summary>
    /// The remaining amount of requests allowed before the bucket refills
    /// </summary>
    public required int Remaining { get; init; }
    /// <summary>
    /// The amount of time before the request bucket refills
    /// </summary>
    public required TimeSpan ResetsIn { get; init; }
}
