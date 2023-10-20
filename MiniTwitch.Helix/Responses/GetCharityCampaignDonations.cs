using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetCharityCampaignDonations : BaseResponse<GetCharityCampaignDonations.Datum>, IPaginable
{
   [JsonPropertyName("pagination")]
   public Pagination Pagination { get; init; }

   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("campaign_id")] string CampaignId,
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("user_login")] string Username,
       [property: JsonPropertyName("user_name")] string UserDisplayName,
       [property: JsonPropertyName("amount")] Donation Amount
   );

   public record Donation(
       [property: JsonPropertyName("value")] int Value,
       [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
       [property: JsonPropertyName("curency")] string Currency
   )
   {
       public double GetAmount() => this.Value * Math.Pow(10, -DecimalPlaces);
   };
}