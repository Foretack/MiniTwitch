using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Videos : PaginableResponse<Videos.Video>
{
    public record Video(
         string Id,
         string? StreamId,
       long UserId,
        [property: JsonPropertyName("user_login")] string UserName,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
         string Title,
         string Description,
         DateTime CreatedAt,
         DateTime PublishedAt,
         string Url,
         string ThumbnailUrl,
         int ViewCount,
         string Language,
         string Type,
         string Duration,
         IReadOnlyList<MutedSegment>? MutedSegments
    );

    public record MutedSegment(
         int Duration,
         int Offset
    );
}