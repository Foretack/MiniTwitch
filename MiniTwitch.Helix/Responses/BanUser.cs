using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class BanUser : BaseResponse<BanUser.Datum>
{
   public record Datum(
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("moderator_id")] long ModeratorId,
       [property: JsonPropertyName("user_id")] string UserId,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("end_time")] DateTime? EndTime
   );
}