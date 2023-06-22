using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Enums;

namespace MiniTwitch.PubSub.Models;

public readonly record struct LowTrustUserPayload(
        [property: JsonPropertyName("low_trust_id")] string LowTrustId,
        [property: JsonPropertyName("channel_id")] long ChannelId,
        [property: JsonPropertyName("updated_by")] UpdatedBy UpdatedBy,
        [property: JsonPropertyName("updated_at")] DateTime UpdatedAt,
        [property: JsonPropertyName("target_user_id")] long TargetUserId,
        [property: JsonPropertyName("target_user")] string TargetUser,
        [property: JsonPropertyName("types")] IReadOnlyList<string> Types,
        //[property: JsonPropertyName("ban_evasion_evaluation")] string BanEvasionEvaluation,
        [property: JsonPropertyName("evaluated_at")] DateTime EvaluatedAt
)
{
    [JsonPropertyName("treatment")]
    private string _treatment { get; init; } = string.Empty;
    public LowTrustUserTreatment Treatment => Enum.Parse<LowTrustUserTreatment>(_treatment, true);
    [JsonPropertyName("ban_evasion_evaluation")]
    private string _eval { get; init; } = string.Empty;
    public UserBanEvasionEvaluation BanEvasionEvaluation => Enum.Parse<UserBanEvasionEvaluation>(_eval, true);
};

public readonly record struct UpdatedBy(
    [property: JsonPropertyName("id")] long Id,
    [property: JsonPropertyName("login")] string Name,
    [property: JsonPropertyName("display_name")] string DisplayName
);
