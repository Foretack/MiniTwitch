using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class BannedUsers : PaginableResponse<BannedUsers.User>
{
    public record User(
       long UserId,
        [property: JsonPropertyName("user_login")] string Username,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
         DateTime? ExpiresAt,
         DateTime CreatedAt,
         string Reason,
         long ModeratorId,
        [property: JsonPropertyName("moderator_login")] string ModeratorName,
        [property: JsonPropertyName("moderator_name")] string ModeratorDisplayName
    );
}