using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetUserBlockList : IPaginable
{
   [JsonPropertyName("data")]
   public Datum[] Data { get; init; }
   [JsonPropertyName("pagination")]
   public Pagination Pagination { get; init; }

   public record Datum(
       [property: JsonPropertyName("user_id")] long Id,
       [property: JsonPropertyName("user_login")] string Name,
       [property: JsonPropertyName("display_name")] string DisplayName
   );
}