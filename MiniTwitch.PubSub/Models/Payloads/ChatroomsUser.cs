using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

/// Not exposed
public readonly struct ChatroomsUser
{
    /// Not exposed
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// Not exposed
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    /// Not exposed
    public readonly struct PayloadData : ITimeOutData, IUntimeOutData, IBanData, IUnbanData, IAliasRestrictedUpdate
    {
        /// Not exposed
        [JsonPropertyName("action")]
        public string Action { get; init; }
        /// Not exposed
        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }
        /// Not exposed
        [JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; init; }
        /// Not exposed
        [JsonPropertyName("expires_in_ms")]
        public long ExpiresInMs { get; init; }
        /// Not exposed
        [JsonPropertyName("reason")]
        public string Reason { get; init; }
        /// Not exposed
        [JsonPropertyName("target_id")]
        public long TargetId { get; init; }
        /// Not exposed
        [JsonPropertyName("user_is_restricted")]
        public bool UserIsRestricted { get; init; }
        /// Not exposed
        [JsonPropertyName("ChannelID")]
        public long ChannelId2 { get; init; }
    }
}

