using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;
public class ModeratedChannels : PaginableResponse<ModeratedChannels.Info>
{
    public record Info(
        [property: JsonPropertyName("broadcaster_id")] long Id,
        [property: JsonPropertyName("broadcaster_login")] string Name,
        [property: JsonPropertyName("broadcaster_name")] string DisplayName
    );
}
