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

    public readonly record struct PayloadData(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("channel_id")] long ChannelId,
    [property: JsonPropertyName("expires_at")] DateTime ExpiresAt,
    [property: JsonPropertyName("expires_in_ms")] long ExpiresInMs,
    [property: JsonPropertyName("reason")] string Reason,
    [property: JsonPropertyName("target_id")] long TargetId,
    [property: JsonPropertyName("user_is_restricted")] bool UserIsRestricted,
    [property: JsonPropertyName("ChannelID")] long ChannelId2
    ) : ITimeOutData, IUntimeOutData, IBanData, IUnbanData, IAliasRestrictedUpdate;
}

