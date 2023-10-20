namespace MiniTwitch.Helix.Requests;

public readonly struct UpdatedCustomReward
{
    public string Title { get; init; }
    public long? Cost { get; init; }
    public string Prompt { get; init; }
    public bool? IsEnabled { get; init; }
    public string BackgroundColor { get; init; }
    public bool? IsUserInputRequired { get; init; }
    public bool? IsMaxPerStreamEnabled { get; init; }
    public int? MaxPerStream { get; init; }
    public bool? IsMaxPerUserPerStreamEnabled { get; init; }
    public int? MaxPerUserPerStream { get; init; }
    public bool? IsGlobalCooldownEnabled { get; init; }
    public int? GlobalCooldownSeconds { get; init; }
    public bool? ShouldRedemptionsSkipRequestQueue { get; init; }
    public bool? IsPaused { get; init; }
}
