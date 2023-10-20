using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class StreamMarker : SingleResponse<StreamMarker.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] int Id,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("description")] string Description,
       [property: JsonPropertyName("position_seconds")] int PositionSeconds
   );
}