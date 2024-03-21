using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class DropsEntitlements : PaginableResponse<DropsEntitlements.Entitlement>
{
    public record Entitlement(
        string Id,
        string BenefitId,
        DateTime Timestamp,
      long UserId,
        string GameId,
        string FulfillmentStatus,
        DateTime LastUpdated
    );
}