using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class StreamMarkers : PaginableResponse<StreamMarkers.Info>
{
    public record Info(
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("user_name")] string UserDisplayName,
       [property: JsonPropertyName("user_login")] string Username,
       [property: JsonPropertyName("videos")] IReadOnlyList<Video> Videos
   );

    public record Marker(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("created_at")] DateTime CreatedAt,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("position_seconds")] int PositionSeconds,
        [property: JsonPropertyName("URL")] string URL
    );

    public record Video(
        [property: JsonPropertyName("video_id")] string VideoId,
        [property: JsonPropertyName("markers")] IReadOnlyList<Marker> Markers
    );
}