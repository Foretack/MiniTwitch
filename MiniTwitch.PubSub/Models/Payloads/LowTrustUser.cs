using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct LowTrustUser : ILowTrustTreatmentMessage, ILowTrustChatMessage
{
    [JsonPropertyName("low_trust_user")]
    public LowTrustUserData LowTrustUserInfo { get; init; } = default;
    [JsonPropertyName("message_content")]
    public MessageContentData MessageContent { get; init; } = default;
    [JsonPropertyName("message_id")]
    public string MessageId { get; init; } = "";
    [JsonPropertyName("sent_at")]
    public DateTime SentAt { get; init; } = default;
    [JsonPropertyName("low_trust_id")]
    public string LowTrustId { get; init; } = "";
    [JsonPropertyName("channel_id")]
    public long ChannelId { get; init; } = default;
    [JsonPropertyName("updated_by")]
    public UserInfo UpdatedBy { get; init; } = default;
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; } = default;
    [JsonPropertyName("target_user_id")]
    public long TargetUserId { get; init; } = default;
    [JsonPropertyName("target_user")]
    public string TargetUser { get; init; } = "";
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

    public readonly record struct LowTrustUserData(
        [property: JsonPropertyName("id")] long Id,
        [property: JsonPropertyName("low_trust_id")] string LowTrustId,
        [property: JsonPropertyName("channel_id")] long ChannelId,
        [property: JsonPropertyName("sender")] UserInfo Sender,
        [property: JsonPropertyName("evaluated_at")] DateTime EvaluatedAt,
        [property: JsonPropertyName("updated_at")] DateTime UpdatedAt,
        [property: JsonPropertyName("updated_by")] UserInfo UpdatedBy,
        [property: JsonPropertyName("shared_ban_channel_ids")] long[]? SharedBanChannelIds,
        [property: JsonPropertyName("types")] string[] Types,
        [property: JsonPropertyName("treatment")] string Treatment,
        [property: JsonPropertyName("ban_evasion_evaluation")] string BanEvasionEvaluation
    );

    public readonly record struct UserInfo(
        [property: JsonPropertyName("id")] long Id,
        [property: JsonPropertyName("login")] string Login,
        [property: JsonPropertyName("display_name")] string DisplayName
    );

    public readonly record struct MessageContentData(
        [property: JsonPropertyName("text")] string Text
    );
}