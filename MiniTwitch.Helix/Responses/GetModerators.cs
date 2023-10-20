using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetModerators : PaginableResponse<GetModerators.Datum>
{
   public record Datum(
       [property: JsonPropertyName("user_id")] long Id,
       [property: JsonPropertyName("user_login")] string Name,
       [property: JsonPropertyName("user_name")] string DisplayName
   );
}