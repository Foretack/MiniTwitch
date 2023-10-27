using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Streams : PaginableResponse<Streams.Stream>
{
    public record Stream(
        [property: JsonPropertyName("language")] string Language,
        [property: JsonPropertyName("user_login")] string BroadcasterName,
        [property: JsonPropertyName("user_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("game_id")] string GameId,
        [property: JsonPropertyName("game_name")] string GameName,
        [property: JsonPropertyName("id")] long BroadcasterId,
        [property: JsonPropertyName("is_live")] bool IsLive,
        [property: JsonPropertyName("tags")] IReadOnlyList<string> Tags,
        [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("started_at")] DateTime? StartedAt
    );
}