using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class UserExtensions : BaseResponse<UserExtensions.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("version")] string Version,
       [property: JsonPropertyName("name")] string Name,
       [property: JsonPropertyName("can_activate")] bool CanActivate,
       [property: JsonPropertyName("type")] IReadOnlyList<string> Type
   );
}