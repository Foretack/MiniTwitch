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

    public readonly struct PayloadData : IUserTimedOut, IUserBanned, IUserUntimedOut, IUserUnbanned
    {
        [JsonPropertyName("moderation_action")]
        public string ModerationAction { get; init; }

        [JsonPropertyName("args")]
        public IReadOnlyList<string> Args { get; init; }

        [JsonPropertyName("created_by")]
        public string CreatedBy { get; init; }

        [JsonPropertyName("created_by_user_id")]
        public long CreatedByUserId { get; init; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; }

        [JsonPropertyName("target_user_id")]
        public long TargetUserId { get; init; }

        [JsonPropertyName("target_user_login")]
        public string TargetUsername { get; init; }

        [JsonPropertyName("from_automod")]
        public bool FromAutomod { get; init; }

        public string Reason => this.Args.Count > 2 ? Args[2] : this.Args.Count > 1 ? Args[1] : string.Empty;
        public TimeSpan Duration => int.TryParse(Args[1], out int result) ? TimeSpan.FromSeconds(result) : TimeSpan.Zero;
    }
}
