using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class Clips : PaginableResponse<Clips.Clip>
{
   public record Clip(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("url")] string Url,
       [property: JsonPropertyName("embed_url")] string EmbedUrl,
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
       [property: JsonPropertyName("creator_id")] long CreatorId,
       [property: JsonPropertyName("creator_name")] string CreatorName,
       [property: JsonPropertyName("video_id")] string VideoId,
       [property: JsonPropertyName("game_id")] string GameId,
       [property: JsonPropertyName("language")] string Language,
       [property: JsonPropertyName("title")] string Title,
       [property: JsonPropertyName("view_count")] int ViewCount,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
       [property: JsonPropertyName("duration")] int Duration,
       [property: JsonPropertyName("vod_offset")] int VodOffset,
       [property: JsonPropertyName("is_featured")] bool IsFeatured
   );
}