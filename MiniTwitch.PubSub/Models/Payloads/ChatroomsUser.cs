using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

/// <inheritdoc/>
public readonly struct ChatroomsUser
{
    /// <inheritdoc/>
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// <inheritdoc/>
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly struct PayloadData : ITimeOutData, IUntimeOutData, IBanData, IUnbanData, IAliasRestrictedUpdate
    {
        [JsonPropertyName("action")]
        public string Action { get; init; }

        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }

        [JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; init; }

        [JsonPropertyName("expires_in_ms")]
        public long ExpiresInMs { get; init; }

        [JsonPropertyName("reason")]
        public string Reason { get; init; }

        [JsonPropertyName("target_id")]
        public long TargetId { get; init; }

        [JsonPropertyName("user_is_restricted")]
        public bool UserIsRestricted { get; init; }

        [JsonPropertyName("ChannelID")]
        public long ChannelId2 { get; init; }
    }
}

