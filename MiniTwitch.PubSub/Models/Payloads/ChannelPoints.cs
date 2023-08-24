using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

/// <summary>
/// Represents information about a channel point redemption
/// </summary>
public readonly struct ChannelPoints
{
    /// <summary>
    /// The type of event
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// <summary>
    /// Data relating to the channel point redemption
    /// </summary>
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    /// <summary>
    /// Contains information about a redemption
    /// </summary>
    public readonly struct PayloadData
    {
        /// <summary>
        /// Time of redemption
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
        /// <summary>
        /// The redemption
        /// </summary>
        [JsonPropertyName("redemption")]
        public Redemption Redemption { get; init; }
    }
    /// <summary>
    /// Contains links to an image in various sizes
    /// </summary>
    public readonly struct Image
    {
        /// <summary>
        /// The 1x link (32x32)
        /// </summary>
        [JsonPropertyName("url_1x")]
        public string Url1x { get; init; }
        /// <summary>
        /// The 2x link (64x64)
        /// </summary>
        [JsonPropertyName("url_2x")]
        public string Url2x { get; init; }
        /// <summary>
        /// The 3x link (96x96)
        /// </summary>
        [JsonPropertyName("url_4x")]
        public string Url4x { get; init; }
    }
    /// <summary>
    /// The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown
    /// </summary>
    public readonly struct CooldownSetting
    {
        /// <summary>
        /// Whether this setting is enabled
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }
        /// <summary>
        /// The cooldown period between redemptions in seconds
        /// </summary>
        [JsonPropertyName("global_cooldown_seconds")]
        public int GlobalCooldownSeconds { get; init; }
    }
    /// <summary>
    /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream.
    /// </summary>
    public readonly struct MaxPerStreamSetting
    {
        /// <summary>
        /// Whether this setting is enabled
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }
        /// <summary>
        /// The Maximum to the number of redemptions allowed per live stream
        /// </summary>
        [JsonPropertyName("max_per_stream")]
        public int MaxPerStream { get; init; }
    }
    /// <summary>
    /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream
    /// </summary>
    public readonly struct MaxPerUserPerStreamSetting
    {
        /// <summary>
        /// Whether this setting is enabled
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }
        /// <summary>
        /// The maximum to the number of redemptions allowed per user per live stream
        /// </summary>
        [JsonPropertyName("max_per_user_per_stream")]
        public int MaxPerUserPerStream { get; init; }
    }
    /// <summary>
    /// Data about the redemption, includes unique id and user that redeemed it
    /// </summary>
    public readonly struct Redemption
    {
        /// <summary>
        /// The ID that uniquely identifies this redemption
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; }
        /// <summary>
        /// Information on the user that redeemed the reward
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; init; }
        /// <summary>
        /// ID of the channel where the redemption took place
        /// </summary>
        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }
        /// <summary>
        /// Time of redemption
        /// </summary>
        [JsonPropertyName("redeemed_at")]
        public DateTime RedeemedAt { get; init; }
        /// <summary>
        /// The reward chosen
        /// </summary>
        [JsonPropertyName("reward")]
        public Reward Reward { get; init; }
        /// <summary>
        /// A string that the user entered if the reward requires input
        /// </summary>
        [JsonPropertyName("user_input")]
        public string UserInput { get; init; }
        /// <summary>
        /// reward redemption status, will be FULFULLED if a user skips the reward queue, UNFULFILLED otherwise
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; init; }
    }
    /// <summary>
    /// Represents a channel point reward
    /// </summary>
    public readonly struct Reward
    {
        /// <summary>
        /// The ID that uniquely identifies this custom reward
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; }
        /// <summary>
        /// ID of the channel where the reward is
        /// </summary>
        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }
        /// <summary>
        /// Title of the reward
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; }
        /// <summary>
        /// The prompt shown to the viewer when they redeem the reward if user input is required (see the <see cref="IsUserInputRequired"/>)
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; init; }
        /// <summary>
        /// The cost of the reward in Channel Points.
        /// </summary>
        [JsonPropertyName("cost")]
        public long Cost { get; init; }
        /// <summary>
        /// A Boolean value that determines whether the user must enter information when redeeming the reward. Is true if the user is prompted.
        /// </summary>
        [JsonPropertyName("is_user_input_required")]
        public bool IsUserInputRequired { get; init; }
        /// <summary>
        /// Whether this reward is only available to subscribers
        /// </summary>
        [JsonPropertyName("is_sub_only")]
        public bool IsSubOnly { get; init; }
        /// <summary>
        /// Custom image of this reward, if applicable
        /// </summary>
        [JsonPropertyName("image")]
        public Image? Image { get; init; }
        /// <summary>
        /// The default image for this reward
        /// </summary>
        [JsonPropertyName("default_image")]
        public Image DefaultImage { get; init; }
        /// <summary>
        /// The background color for this reward
        /// </summary>
        [JsonPropertyName("background_color")]
        public string BackgroundColor { get; init; }
        /// <summary>
        /// Whether the reward is enabled
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }
        /// <summary>
        /// Whether the reward is temporarily disabled
        /// </summary>
        [JsonPropertyName("is_paused")]
        public bool IsPaused { get; init; }
        /// <summary>
        /// Whether the reward is still in stock
        /// </summary>
        [JsonPropertyName("is_in_stock")]
        public bool IsInStock { get; init; }
        /// <summary>
        /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream.
        /// </summary>
        [JsonPropertyName("max_per_stream")]
        public MaxPerStreamSetting MaxPerStream { get; init; }
        /// <summary>
        /// Boolean value that determines whether redemptions should be set to FULFILLED status immediately when a reward is redeemed. If false, status is set to UNFULFILLED and follows the normal request queue process
        /// </summary>
        [JsonPropertyName("should_redemptions_skip_request_queue")]
        public bool ShouldRedemptionsSkipRequestQueue { get; init; }
        /// <summary>
        /// I don't know what this is
        /// </summary>
        [JsonPropertyName("template_id")]
        public object? TemplateId { get; init; }
        /// ???
        [JsonPropertyName("updated_for_indicator_at")]
        public DateTime? UpdatedForIndicatorAt { get; init; }
        /// <summary>
        /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream.
        /// </summary>
        [JsonPropertyName("max_per_user_per_stream")]
        public MaxPerUserPerStreamSetting MaxPerUserPerStream { get; init; }
        /// <summary>
        /// The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown
        /// </summary>
        [JsonPropertyName("global_cooldown")]
        public CooldownSetting GlobalCooldown { get; init; }
        /// <summary>
        /// The number of redemptions redeemed during the current live stream. The number counts against the <see cref="MaxPerStream"/> limit. 
        /// <para>This property is <see langword="null"/> if the broadcaster’s stream isn’t live or <see cref="MaxPerStream"/> isn’t enabled</para>
        /// </summary>
        [JsonPropertyName("redemptions_redeemed_current_stream")]
        public int? RedemptionsRedeemedCurrentStream { get; init; }
        /// <summary>
        /// The timestamp of when the cooldown period expires. Is <see langword="null"/> if the reward isn’t in a cooldown state. See <see cref="GlobalCooldown"/>
        /// </summary>
        [JsonPropertyName("cooldown_expires_at")]
        public DateTime? CooldownExpiresAt { get; init; }
    }
    /// <summary>
    /// Represents information about a user
    /// </summary>
    public readonly struct User
    {
        /// <summary>
        /// ID of the user
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; init; }
        /// <summary>
        /// Name of the user
        /// </summary>
        [JsonPropertyName("login")]
        public string Name { get; init; }
        /// <summary>
        /// Display name of the user
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }
    }

}