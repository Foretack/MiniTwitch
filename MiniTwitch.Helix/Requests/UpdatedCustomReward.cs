namespace MiniTwitch.Helix.Requests;

public class UpdatedCustomReward
{
    public string? Title { get; }
    public long? Cost { get; }
    public string? Prompt { get; }
    public bool? IsEnabled { get; }
    public string? BackgroundColor { get; }
    public bool? IsUserInputRequired { get; }
    public bool? IsMaxPerStreamEnabled { get; }
    public int? MaxPerStream { get; }
    public bool? IsMaxPerUserPerStreamEnabled { get; }
    public int? MaxPerUserPerStream { get; }
    public bool? IsGlobalCooldownEnabled { get; }
    public int? GlobalCooldownSeconds { get; }
    public bool? ShouldRedemptionsSkipRequestQueue { get; }
    public bool? IsPaused { get; }

    public UpdatedCustomReward(
        string? title = null,
        long? cost = null,
        string? prompt = null,
        bool? isEnabled = null,
        string? backgroundColor = null,
        bool? isUserInputRequired = null,
        bool? isMaxPerStreamEnabled = null,
        int? maxPerStream = null,
        bool? isMaxPerUserPerStreamEnabled = null,
        int? maxPerUserPerStream = null,
        bool? isGlobalCooldownEnabled = null,
        int? globalCooldownSeconds = null,
        bool? shouldRedemptionsSkipRequestQueue = null,
        bool? isPaused = null
    )
    {
        this.Title = title;
        this.Cost = cost;
        this.Prompt = prompt;
        this.IsEnabled = isEnabled;
        this.BackgroundColor = backgroundColor;
        this.IsUserInputRequired = isUserInputRequired;
        this.IsMaxPerStreamEnabled = isMaxPerStreamEnabled;
        this.MaxPerStream = maxPerStream;
        this.IsMaxPerUserPerStreamEnabled = isMaxPerUserPerStreamEnabled;
        this.MaxPerUserPerStream = maxPerUserPerStream;
        this.IsGlobalCooldownEnabled = isGlobalCooldownEnabled;
        this.ShouldRedemptionsSkipRequestQueue = shouldRedemptionsSkipRequestQueue;
        this.IsPaused = isPaused;
    }
}
