using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Streams : PaginableResponse<Streams.Stream>
{
    public record Stream(
        string Language,
        [property: JsonPropertyName("user_login")] string BroadcasterName,
        [property: JsonPropertyName("user_name")] string BroadcasterDisplayName,
        string GameId,
        string GameName,
        [property: JsonPropertyName("id")] long BroadcasterId,
        bool IsLive,
        IReadOnlyList<string> Tags,
        string ThumbnailUrl,
        string Title,
        DateTime? StartedAt
    );
}