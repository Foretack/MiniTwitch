using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetShieldModeStatus : SingleResponse<GetShieldModeStatus.Datum>
{
   public record Datum(
      [property: JsonPropertyName("is_active")] bool IsActive,
      [property: JsonPropertyName("moderator_id")] long ModeratorId,
      [property: JsonPropertyName("moderator_name")] string ModeratorDisplayName,
      [property: JsonPropertyName("moderator_login")] string ModeratorName,
      [property: JsonPropertyName("last_activated_at")] DateTime LastActivatedAt
  );
}