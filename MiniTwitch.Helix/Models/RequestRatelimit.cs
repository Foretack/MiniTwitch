namespace MiniTwitch.Helix.Models;

public readonly record struct RequestRatelimit
{
    public required int Limit { get; init; }
    public required int Remaining { get; init; }
    public required TimeSpan ResetsIn { get; init; }
}
