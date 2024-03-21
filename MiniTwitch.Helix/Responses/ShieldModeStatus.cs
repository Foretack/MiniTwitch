using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ShieldModeStatus : BaseResponse<ShieldModeStatus.Status>
{
    public record Status(
       bool IsActive,
       long ModeratorId,
       [property: JsonPropertyName("moderator_name")] string ModeratorDisplayName,
       [property: JsonPropertyName("moderator_login")] string ModeratorName,
       DateTime LastActivatedAt
   );
}