using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Channels : PaginableResponse<Channels.Channel>
{
    public record Channel(
        string BroadcasterLanguage,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        [property: JsonPropertyName("display_name")] string BroadcasterDisplayName,
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