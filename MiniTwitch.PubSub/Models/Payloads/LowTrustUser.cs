using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

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
    [JsonPropertyName("evaluated_at")]
    public DateTime EvaluatedAt { get; init; } = default;
    [JsonPropertyName("treatment")]
    public string Treatment { get; init; } = "";
    [JsonPropertyName("ban_evasion_evaluation")]
    public string BanEvasionEvaluation { get; init; } = "";

    internal bool IsTreatmentMessage => !string.IsNullOrEmpty(this.Treatment);

    public LowTrustUser(object? _) { }

    public readonly struct LowTrustUserData
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("low_trust_id")]
        public string LowTrustId { get; init; }

        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }

        [JsonPropertyName("sender")]
        public UserInfo Sender { get; init; }

        [JsonPropertyName("evaluated_at")]
        public DateTime EvaluatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; init; }

        [JsonPropertyName("updated_by")]
        public UserInfo UpdatedBy { get; init; }

        [JsonPropertyName("types")]
        public string[] Types { get; init; }

        [JsonPropertyName("treatment")]
        public string Treatment { get; init; }

        [JsonPropertyName("ban_evasion_evaluation")]
        public string BanEvasionEvaluation { get; init; }
    }
    public readonly struct UserInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("login")]
        public string Login { get; init; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }
    }
    public readonly struct MessageContentData
    {
        [JsonPropertyName("text")]
        public string Text { get; init; }
    }

}