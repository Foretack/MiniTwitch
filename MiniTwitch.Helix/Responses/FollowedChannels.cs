using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class FollowedChannels : PaginableResponse<FollowedChannels.Channel>
{
    [JsonPropertyName("total")]
    public int Total { get; init; }

    public record Channel(
        long ChannelId,
        [property: JsonPropertyName("broadcaster_login")] string ChannelName,
        [property: JsonPropertyName("broadcaster_name")] string ChannelDisplayName,
        DateTime FollowedAt
    );
}