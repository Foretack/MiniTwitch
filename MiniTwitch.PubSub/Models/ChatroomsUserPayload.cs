using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models;

public readonly record struct Data(
        [property: JsonPropertyName("action")] string Action,
        [property: JsonPropertyName("channel_id")] long ChannelId,
        [property: JsonPropertyName("expires_at")] DateTime ExpiresAt,
        [property: JsonPropertyName("expires_in_ms")] long ExpiresInMs,
        [property: JsonPropertyName("reason")] string Reason,
        [property: JsonPropertyName("target_id")] long TargetId,
        [property: JsonPropertyName("user_is_restricted")] bool UserIsRestricted,
        [property: JsonPropertyName("ChannelID")] long ChannelId2
) : ITimeOutData, IUntimeOutData, IBanData, IUnbanData, IAliasRestrictedUpdate;

public readonly record struct ChatroomsUserPayload(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("data")] Data Data
);

