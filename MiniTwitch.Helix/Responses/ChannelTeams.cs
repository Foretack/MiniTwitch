using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChannelTeams : BaseResponse<ChannelTeams.Team>
{
    public record Team(
        long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        string? BackgroundImageUrl,
        string? Banner,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Info,
        string ThumbnailUrl,
        string TeamName,
        string TeamDisplayName,
        string Id
    );
}