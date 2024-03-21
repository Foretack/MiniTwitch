using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class StreamMarkers : PaginableResponse<StreamMarkers.Info>
{
    public record Info(
       long UserId,
       [property: JsonPropertyName("user_name")] string UserDisplayName,
       [property: JsonPropertyName("user_login")] string Username,
       IReadOnlyList<Video> Videos
   );

    public record Marker(
        string Id,
        DateTime CreatedAt,
        string Description,
        int PositionSeconds,
        [property: JsonPropertyName("URL")] string URL
    );

    public record Video(
        string VideoId,
        IReadOnlyList<Marker> Markers
    );
}