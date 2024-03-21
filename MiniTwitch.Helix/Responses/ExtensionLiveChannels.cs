using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionLiveChannels : PaginableResponse<ExtensionLiveChannels.Channel>
{
    public record Channel(
        string BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        string GameName,
        string GameId,
        string Title
 );
}