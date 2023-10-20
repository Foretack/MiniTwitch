using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class Videos : PaginableResponse<Videos.Video>
{
   public record Video(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("stream_id")] string? StreamId,
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("user_login")] string UserName,
       [property: JsonPropertyName("user_name")] string UserDisplayName,
       [property: JsonPropertyName("title")] string Title,
       [property: JsonPropertyName("description")] string Description,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("published_at")] DateTime PublishedAt,
       [property: JsonPropertyName("url")] string Url,
       [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
       [property: JsonPropertyName("view_count")] int ViewCount,
       [property: JsonPropertyName("language")] string Language,
       [property: JsonPropertyName("type")] string Type,
       [property: JsonPropertyName("duration")] string Duration,
       [property: JsonPropertyName("muted_segments")] IReadOnlyList<MutedSegment>? MutedSegments
   );

   public record MutedSegment(
       [property: JsonPropertyName("duration")] int Duration,
       [property: JsonPropertyName("offset")] int Offset
   );
}