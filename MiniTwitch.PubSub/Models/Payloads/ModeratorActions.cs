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

    /// Not exposed
    public readonly struct PayloadData : IUserTimedOut, IUserBanned, IUserUntimedOut, IUserUnbanned
    {
        /// Not exposed
        [JsonPropertyName("moderation_action")]
        public string ModerationAction { get; init; }
        /// Not exposed
        [JsonPropertyName("args")]
        public IReadOnlyList<string> Args { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("created_by")]
        public string CreatedBy { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("created_by_user_id")]
        public long CreatedByUserId { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("target_user_id")]
        public long TargetUserId { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("target_user_login")]
        public string TargetUsername { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("from_automod")]
        public bool FromAutomod { get; init; }
        /// <inheritdoc/>
        public string Reason => this.Args.Count > 2 ? Args[2] : this.Args.Count > 1 ? Args[1] : string.Empty;
        /// <inheritdoc/>
        public TimeSpan Duration => int.TryParse(Args[1], out int result) ? TimeSpan.FromSeconds(result) : TimeSpan.Zero;
    }
}
