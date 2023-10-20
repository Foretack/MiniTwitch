using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class StreamMarker : SingleResponse<StreamMarker.Marker>
{
    public record Marker(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("created_at")] DateTime CreatedAt,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("position_seconds")] int PositionSeconds
    );
}