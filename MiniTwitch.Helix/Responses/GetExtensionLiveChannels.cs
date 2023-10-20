using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetExtensionLiveChannels : BaseResponse<GetExtensionLiveChannels.Datum>, IPaginable
{
   [JsonPropertyName("pagination")]
   public Pagination Pagination { get; init; }

   public record Datum(
   [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
   [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
   [property: JsonPropertyName("game_name")] string GameName,
   [property: JsonPropertyName("game_id")] string GameId,
   [property: JsonPropertyName("title")] string Title
);
}