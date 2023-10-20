using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Chatters : PaginableResponse<Chatters.Chatter>
{
    [JsonPropertyName("total")]
    public int Total { get; init; }

    public record Chatter(
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("user_login")] string Username,
        [property: JsonPropertyName("user_name")] string UserDisplayName
    );
}