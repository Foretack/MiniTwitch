using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class Games : PaginableResponse<Games.Game>
{
   public record Game(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("name")] string Name,
       [property: JsonPropertyName("box_art_url")] string BoxArtUrl,
       [property: JsonPropertyName("igdb_id")] string IgdbId
   );
}