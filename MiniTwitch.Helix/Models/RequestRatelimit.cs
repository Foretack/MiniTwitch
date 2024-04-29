namespace MiniTwitch.Helix.Models;

public readonly record struct RequestRatelimit
{
    /// <summary>
    /// Maximum amount of requests that can be made in period
    /// </summary>
    public int Limit { get; }
    /// <summary>
    /// The remaining amount of requests allowed before the bucket refills
    /// </summary>
    public int Remaining { get; }
    /// <summary>
    /// The amount of time before the request bucket refills
    /// </summary>
    public TimeSpan ResetsIn { get; }

    internal RequestRatelimit(int limit, int remaining, TimeSpan resetsIn)
    {
        this.Limit = limit;
        this.Remaining = remaining;
        this.ResetsIn = resetsIn;
    }
}
