using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct ChannelPoints
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly struct PayloadData
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("redemption")]
        public Redemption Redemption { get; init; }
    }
    public readonly struct Image
    {
        [JsonPropertyName("url_1x")]
        public string Url1x { get; init; }

        [JsonPropertyName("url_2x")]
        public string Url2x { get; init; }

        [JsonPropertyName("url_4x")]
        public string Url4x { get; init; }
    }
    public readonly struct CooldownSetting
    {
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }

        [JsonPropertyName("global_cooldown_seconds")]
        public int GlobalCooldownSeconds { get; init; }
    }
    public readonly struct MaxPerStreamSetting
    {
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }

        [JsonPropertyName("max_per_stream")]
        public int MaxPerStream { get; init; }
    }
    public readonly struct MaxPerUserPerStreamSetting
    {
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }

        [JsonPropertyName("max_per_user_per_stream")]
        public int MaxPerUserPerStream { get; init; }
    }
    public readonly struct Redemption
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("user")]
        public User User { get; init; }

        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }

        [JsonPropertyName("redeemed_at")]
        public string RedeemedAt { get; init; }

        [JsonPropertyName("reward")]
        public Reward Reward { get; init; }

        [JsonPropertyName("user_input")]
        public string UserInput { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; init; }
    }
    public readonly struct Reward
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; init; }

        [JsonPropertyName("cost")]
        public long Cost { get; init; }

        [JsonPropertyName("is_user_input_required")]
        public bool IsUserInputRequired { get; init; }

        [JsonPropertyName("is_sub_only")]
        public bool IsSubOnly { get; init; }

        [JsonPropertyName("image")]
        public Image? Image { get; init; }

        [JsonPropertyName("default_image")]
        public Image DefaultImage { get; init; }

        [JsonPropertyName("background_color")]
        public string BackgroundColor { get; init; }

        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }

        [JsonPropertyName("is_paused")]
        public bool IsPaused { get; init; }

        [JsonPropertyName("is_in_stock")]
        public bool IsInStock { get; init; }

        [JsonPropertyName("max_per_stream")]
        public MaxPerStreamSetting MaxPerStream { get; init; }

        [JsonPropertyName("should_redemptions_skip_request_queue")]
        public bool ShouldRedemptionsSkipRequestQueue { get; init; }

        [JsonPropertyName("template_id")]
        public object? TemplateId { get; init; }

        [JsonPropertyName("updated_for_indicator_at")]
        public DateTime? UpdatedForIndicatorAt { get; init; }

        [JsonPropertyName("max_per_user_per_stream")]
        public MaxPerUserPerStreamSetting MaxPerUserPerStream { get; init; }

        [JsonPropertyName("global_cooldown")]
        public CooldownSetting GlobalCooldown { get; init; }

        [JsonPropertyName("redemptions_redeemed_current_stream")]
        public int? RedemptionsRedeemedCurrentStream { get; init; }

        [JsonPropertyName("cooldown_expires_at")]
        public DateTime? CooldownExpiresAt { get; init; }
    }
    public readonly struct User
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("login")]
        public string Name { get; init; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }
    }

}