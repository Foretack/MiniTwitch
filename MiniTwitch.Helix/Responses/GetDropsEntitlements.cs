using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetDropsEntitlements : BaseResponse<GetDropsEntitlements.Entitlement>, IPaginable
{
   [JsonPropertyName("pagination")]
   public Pagination Pagination { get; init; }

   public record Entitlement(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("benefit_id")] string BenefitId,
       [property: JsonPropertyName("timestamp")] DateTime Timestamp,
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("game_id")] string GameId,
       [property: JsonPropertyName("fulfillment_status")] string FulfillmentStatus,
       [property: JsonPropertyName("last_updated")] DateTime LastUpdated
   );
}