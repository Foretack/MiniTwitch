using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct ChannelPoints
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly record struct PayloadData(
        [property: JsonPropertyName("timestamp")] DateTime Timestamp,
        [property: JsonPropertyName("redemption")] Redemption Redemption
    );

    public readonly record struct Image(
        [property: JsonPropertyName("url_1x")] string Url1x,
        [property: JsonPropertyName("url_2x")] string Url2x,
        [property: JsonPropertyName("url_4x")] string Url4x
    );

    public readonly record struct CooldownSetting(
        [property: JsonPropertyName("is_enabled")] bool IsEnabled,
        [property: JsonPropertyName("global_cooldown_seconds")] int GlobalCooldownSeconds
    );

    public readonly record struct MaxPerStreamSetting(
        [property: JsonPropertyName("is_enabled")] bool IsEnabled,
        [property: JsonPropertyName("max_per_stream")] int MaxPerStream
    );

    public readonly record struct MaxPerUserPerStreamSetting(
        [property: JsonPropertyName("is_enabled")] bool IsEnabled,
        [property: JsonPropertyName("max_per_user_per_stream")] int MaxPerUserPerStream
    );

    public readonly record struct Redemption(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("user")] User User,
        [property: JsonPropertyName("channel_id")] long ChannelId,
        [property: JsonPropertyName("redeemed_at")] string RedeemedAt,
        [property: JsonPropertyName("reward")] Reward Reward,
        [property: JsonPropertyName("user_input")] string UserInput,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("cursor")] string Cursor
    );

    public readonly record struct Reward(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("channel_id")] long ChannelId,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("prompt")] string Prompt,
        [property: JsonPropertyName("cost")] long Cost,
        [property: JsonPropertyName("is_user_input_required")] bool IsUserInputRequired,
        [property: JsonPropertyName("is_sub_only")] bool IsSubOnly,
        [property: JsonPropertyName("image")] Image? Image,
        [property: JsonPropertyName("default_image")] Image DefaultImage,
        [property: JsonPropertyName("background_color")] string BackgroundColor,
        [property: JsonPropertyName("is_enabled")] bool IsEnabled,
        [property: JsonPropertyName("is_paused")] bool IsPaused,
        [property: JsonPropertyName("is_in_stock")] bool IsInStock,
        [property: JsonPropertyName("max_per_stream")] MaxPerStreamSetting MaxPerStream,
        [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool ShouldRedemptionsSkipRequestQueue,
        [property: JsonPropertyName("template_id")] object? TemplateId,
        [property: JsonPropertyName("updated_for_indicator_at")] DateTime? UpdatedForIndicatorAt,
        [property: JsonPropertyName("max_per_user_per_stream")] MaxPerUserPerStreamSetting MaxPerUserPerStream,
        [property: JsonPropertyName("global_cooldown")] CooldownSetting GlobalCooldown,
        [property: JsonPropertyName("redemptions_redeemed_current_stream")] int? RedemptionsRedeemedCurrentStream,
        [property: JsonPropertyName("cooldown_expires_at")] DateTime? CooldownExpiresAt
    );

    public readonly record struct User(
        [property: JsonPropertyName("id")] long Id,
        [property: JsonPropertyName("login")] string Name,
        [property: JsonPropertyName("display_name")] string DisplayName
    );
}