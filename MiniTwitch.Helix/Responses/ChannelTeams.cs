using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChannelTeams : BaseResponse<ChannelTeams.Team>
{
    public record Team(
        [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        [property: JsonPropertyName("background_image_url")] string? BackgroundImageUrl,
        [property: JsonPropertyName("banner")] string? Banner,
        [property: JsonPropertyName("created_at")] DateTime CreatedAt,
        [property: JsonPropertyName("updated_at")] DateTime? UpdatedAt,
        [property: JsonPropertyName("info")] string Info,
        [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
        [property: JsonPropertyName("team_name")] string TeamName,
        [property: JsonPropertyName("team_display_name")] string TeamDisplayName,
        [property: JsonPropertyName("id")] string Id
    );
}