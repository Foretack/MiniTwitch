using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChannelFollowers : PaginableResponse<ChannelFollowers.Follower>
{
    [JsonPropertyName("total")]
    public int Total { get; init; }

    public record Follower(
        [property: JsonPropertyName("user_id")] long FollowerId,
        [property: JsonPropertyName("user_login")] string FollowerName,
        [property: JsonPropertyName("user_name")] string FollowerDisplayName,
        DateTime FollowedAt
    );
}