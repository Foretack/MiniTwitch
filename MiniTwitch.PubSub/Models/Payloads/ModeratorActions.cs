using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

/// Not exposed directly 
public readonly struct ModeratorActions
{
    /// Not exposed directly 
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// Not exposed directly 
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly record struct PayloadData(
        [property: JsonPropertyName("moderation_action")] string ModerationAction,
        [property: JsonPropertyName("args")] IReadOnlyList<string> Args,
        [property: JsonPropertyName("created_by")] string CreatedBy,
        [property: JsonPropertyName("created_by_user_id")] long CreatedByUserId,
        [property: JsonPropertyName("created_at")] DateTime CreatedAt,
        [property: JsonPropertyName("target_user_id")] long TargetUserId,
        [property: JsonPropertyName("target_user_login")] string TargetUsername,
        [property: JsonPropertyName("from_automod")] bool FromAutomod
    ) : IUserTimedOut, IUserBanned, IUserUntimedOut, IUserUnbanned
    {
        public string Reason => this.Args.Count > 2 ? Args[2] : this.Args.Count > 1 ? Args[1] : string.Empty;
        public TimeSpan Duration => int.TryParse(Args[1], out int result) ? TimeSpan.FromSeconds(result) : TimeSpan.Zero;
    };
}
