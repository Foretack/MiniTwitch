using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetUserExtensions : BaseResponse<GetUserExtensions.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("version")] string Version,
       [property: JsonPropertyName("name")] string Name,
       [property: JsonPropertyName("can_activate")] bool CanActivate,
       [property: JsonPropertyName("type")] IReadOnlyList<string> Type
   );
}