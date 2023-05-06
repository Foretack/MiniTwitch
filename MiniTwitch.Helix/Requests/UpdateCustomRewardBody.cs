using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdateCustomRewardBody : IJsonObject
{
    public string Title { get; init; }
    public long Cost { get; init; }
    public string Prompt { get; init; }
    public bool IsEnabled { get; init; }
    public string BackgroundColor { get; init; }
    public bool IsUserInputRequired { get; init; }
    public (bool IsMaxPerStreamEnabled, int MaxPerStream)? MaxPerStreamSetting { get; init; }
    public (bool IsMaxPerUserPerStreamEnabled, int MaxPerUserPerStream)? MaxPerUserPerStreamSetting { get; init; }
    public (bool IsGlobalCooldownEnabled, int GlobalCooldownSeconds)? GlobalCooldownSetting { get; init; }
    public bool ShouldRedemptionsSkipRequestQueue { get; init; }
    public bool IsPaused { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        title = Title,
        cost = Cost,
        prompt = Prompt,
        is_enabled = IsEnabled,
        background_color = BackgroundColor,
        is_user_input_required = IsUserInputRequired,
        is_max_per_stream_enabled = MaxPerStreamSetting?.IsMaxPerStreamEnabled,
        max_per_stream = MaxPerStreamSetting?.MaxPerStream,
        is_max_per_user_per_stream_enabled = MaxPerUserPerStreamSetting?.IsMaxPerUserPerStreamEnabled,
        max_per_user_per_stream = MaxPerUserPerStreamSetting?.MaxPerUserPerStream,
        is_global_cooldown_enabled = GlobalCooldownSetting?.IsGlobalCooldownEnabled,
        global_cooldown_seconds = GlobalCooldownSetting?.GlobalCooldownSeconds,
        should_redemptions_skip_request_queue = ShouldRedemptionsSkipRequestQueue,
        is_paused = IsPaused,
    };
}
