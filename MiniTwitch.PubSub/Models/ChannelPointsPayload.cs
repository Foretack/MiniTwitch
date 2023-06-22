using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models;

public readonly record struct ChannelPointsPayload(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("data")] ChannelPointsData Data
);

public readonly record struct ChannelPointsData(
        [property: JsonPropertyName("timestamp")] string Timestamp,
        [property: JsonPropertyName("redemption")] Redemption Redemption
    );

public readonly record struct DefaultImage(
    [property: JsonPropertyName("url_1x")] string Url1x,
    [property: JsonPropertyName("url_2x")] string Url2x,
    [property: JsonPropertyName("url_4x")] string Url4x
);

public readonly record struct Image(
    [property: JsonPropertyName("url_1x")] string Url1x,
    [property: JsonPropertyName("url_2x")] string Url2x,
    [property: JsonPropertyName("url_4x")] string Url4x
);

public readonly record struct MaxPerStreamSetting(
    [property: JsonPropertyName("is_enabled")] bool IsEnabled,
    [property: JsonPropertyName("max_per_stream")] int MaxPerStream
);

public readonly record struct Redemption(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("user")] User User,
    [property: JsonPropertyName("channel_id")] string ChannelId,
    [property: JsonPropertyName("redeemed_at")] string RedeemedAt,
    [property: JsonPropertyName("reward")] Reward Reward,
    [property: JsonPropertyName("user_input")] string? UserInput,
    [property: JsonPropertyName("status")] string Status
);

public readonly record struct Reward(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("channel_id")] long ChannelId,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("prompt")] string Prompt,
    [property: JsonPropertyName("cost")] long Cost,
    [property: JsonPropertyName("is_user_input_required")] bool IsUserInputRequired,
    [property: JsonPropertyName("is_sub_only")] bool IsSubOnly,
    [property: JsonPropertyName("image")] Image Image,
    [property: JsonPropertyName("default_image")] DefaultImage DefaultImage,
    [property: JsonPropertyName("background_color")] string BackgroundColor,
    [property: JsonPropertyName("is_enabled")] bool IsEnabled,
    [property: JsonPropertyName("is_paused")] bool IsPaused,
    [property: JsonPropertyName("is_in_stock")] bool IsInStock,
    [property: JsonPropertyName("max_per_stream")] MaxPerStreamSetting MaxPerStream,
    [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool ShouldRedemptionsSkipRequestQueue
);

public readonly record struct User(
    [property: JsonPropertyName("id")] long Id,
    [property: JsonPropertyName("login")] string Name,
    [property: JsonPropertyName("display_name")] string DisplayName
);