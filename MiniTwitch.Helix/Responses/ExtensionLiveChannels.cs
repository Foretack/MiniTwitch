using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionLiveChannels : PaginableResponse<ExtensionLiveChannels.Channel>
{
    public record Channel(
        [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("game_name")] string GameName,
        [property: JsonPropertyName("game_id")] string GameId,
        [property: JsonPropertyName("title")] string Title
 );
}