using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Payloads;

/// <inheritdoc/>
public readonly struct LowTrustUser : ILowTrustTreatmentMessage, ILowTrustChatMessage
{
    /// <inheritdoc/>
    [JsonPropertyName("low_trust_user")]
    public LowTrustUserData LowTrustUserInfo { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("message_content")]
    public MessageContentData MessageContent { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("message_id")]
    public string MessageId { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("sent_at")]
    public DateTime SentAt { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("low_trust_id")]
    public string LowTrustId { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("channel_id")]
    public long ChannelId { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("updated_by")]
    public UserInfo UpdatedBy { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("target_user_id")]
    public long TargetUserId { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("target_user")]
    public string TargetUser { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("types")]
    public string[] Types { get; init; } = Array.Empty<string>();
    /// <inheritdoc/>
    [JsonPropertyName("evaluated_at")]
    public DateTime EvaluatedAt { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("treatment")]
    public string Treatment { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("ban_evasion_evaluation")]
    public string BanEvasionEvaluation { get; init; } = "";

    internal bool IsTreatmentMessage => !string.IsNullOrEmpty(this.Treatment);

    internal LowTrustUser(object? _) { }

    /// <inheritdoc/>
    public readonly struct LowTrustUserData
    {
        /// <summary>
        /// ID of the suspected user
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; init; }
        /// <summary>
        /// ID of this event
        /// </summary>
        [JsonPropertyName("low_trust_id")]
        public string LowTrustId { get; init; }
        /// <summary>
        /// ID of the channel
        /// </summary>
        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }
        /// <summary>
        /// Information about the suspected user
        /// </summary>
        [JsonPropertyName("sender")]
        public UserInfo Sender { get; init; }
        /// <summary>
        /// A list of channel IDs where the suspicious user is also banned. <see langword="null"/> if there are none
        /// </summary>
        [JsonPropertyName("shared_ban_channel_ids")]
        public long[]? SharedBanChannelIds { get; init; }
        /// <summary>
        /// The first time the suspicious user was automatically evaluated by Twitch
        /// </summary>
        [JsonPropertyName("evaluated_at")]
        public DateTime EvaluatedAt { get; init; }
        /// <summary>
        /// Time when the treatment was updated for the suspicious user
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; init; }
        /// <summary>
        /// Information about the moderator who made any update for the suspicious user
        /// </summary>
        [JsonPropertyName("updated_by")]
        public UserInfo UpdatedBy { get; init; }
        /// <summary>
        /// User types (if any) that apply to the suspicious user, can be “UNKNOWN_TYPE”, “MANUALLY_ADDED”, “DETECTED_BAN_EVADER”, or “BANNED_IN_SHARED_CHANNEL”
        /// </summary>
        [JsonPropertyName("types")]
        public string[] Types { get; init; }
        /// <summary>
        /// The treatment set for the suspicious user, can be “NO_TREATMENT”, “ACTIVE_MONITORING”, or “RESTRICTED”
        /// </summary>
        [JsonPropertyName("treatment")]
        public string Treatment { get; init; }
        /// <summary>
        /// A ban evasion likelihood value (if any) that as been applied to the user automatically by Twitch, can be “UNKNOWN_EVADER”, “UNLIKELY_EVADER”, “LIKELY_EVADER”, or “POSSIBLE_EVADER”
        /// </summary>
        [JsonPropertyName("ban_evasion_evaluation")]
        public string BanEvasionEvaluation { get; init; }
    }
    /// <inheritdoc/>
    public readonly struct UserInfo
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
    /// <inheritdoc/>
    public readonly struct MessageContentData
    {
        /// <summary>
        /// Text content of the user's message
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; init; }
    }

}