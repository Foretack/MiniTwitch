using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChannelsInformation : BaseResponse<ChannelsInformation.Information>
{
    public record Information(
        [property: JsonPropertyName("broadcaster_id")] long Id,
        [property: JsonPropertyName("broadcaster_login")] string Name,
        [property: JsonPropertyName("broadcaster_name")] string DisplayName,
        [property: JsonPropertyName("broadcaster_language")] string Language,
        [property: JsonPropertyName("game_name")] string GameName,
        [property: JsonPropertyName("game_id")] string GameId,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("delay")] int Delay,
        [property: JsonPropertyName("tags")] IReadOnlyList<string> Tags
    );
}

public class ChannelInformation : SingleResponse<ChannelsInformation.Information>
{
}