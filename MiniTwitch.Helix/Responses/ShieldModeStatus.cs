using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ShieldModeStatus : BaseResponse<ShieldModeStatus.Status>
{
    public record Status(
       [property: JsonPropertyName("is_active")] bool IsActive,
       [property: JsonPropertyName("moderator_id")] long ModeratorId,
       [property: JsonPropertyName("moderator_name")] string ModeratorDisplayName,
       [property: JsonPropertyName("moderator_login")] string ModeratorName,
       [property: JsonPropertyName("last_activated_at")] DateTime LastActivatedAt
   );
}