using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetCreatorGoals : BaseResponse<GetCreatorGoals.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
       [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
       [property: JsonPropertyName("type")] string Type,
       [property: JsonPropertyName("description")] string Description,
       [property: JsonPropertyName("current_amount")] int CurrentAmount,
       [property: JsonPropertyName("target_amount")] int TargetAmount,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt
   );
}