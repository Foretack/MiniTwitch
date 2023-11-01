using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Moderators : PaginableResponse<Moderators.Moderator>
{
    public record Moderator(
        [property: JsonPropertyName("user_id")] long ModeratorId,
        [property: JsonPropertyName("user_login")] string ModeratorName,
        [property: JsonPropertyName("user_name")] string ModeratorDisplayName
    );
}