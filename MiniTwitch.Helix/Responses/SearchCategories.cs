using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class SearchCategories : PaginableResponse<SearchCategories.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("name")] string Name,
       [property: JsonPropertyName("box_art_url")] string BoxArtUrl
   );
}