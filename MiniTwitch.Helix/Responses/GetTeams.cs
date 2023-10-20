using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetTeams
{
   public record Datum(
       [property: JsonPropertyName("users")] IReadOnlyList<User> Users,
       [property: JsonPropertyName("background_image_url")] string? BackgroundImageUrl,
       [property: JsonPropertyName("banner")] string? Banner,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("updated_at")] DateTime UpdatedAt,
       [property: JsonPropertyName("info")] string Info,
       [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
       [property: JsonPropertyName("team_name")] string TeamName,
       [property: JsonPropertyName("team_display_name")] string TeamDisplayName,
       [property: JsonPropertyName("id")] string Id
   );

   public record User(
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("user_name")] string UserDisplayName,
       [property: JsonPropertyName("user_login")] string Username
   );
}