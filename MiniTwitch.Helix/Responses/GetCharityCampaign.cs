using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetCharityCampaign : BaseResponse<GetCharityCampaign.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
       [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
       [property: JsonPropertyName("charity_name")] string CharityName,
       [property: JsonPropertyName("charity_description")] string CharityDescription,
       [property: JsonPropertyName("charity_logo")] string CharityLogo,
       [property: JsonPropertyName("charity_website")] string CharityWebsite,
       [property: JsonPropertyName("current_amount")] CurrentAmount CurrentAmount,
       [property: JsonPropertyName("target_amount")] TargetAmount TargetAmount
   );

   public record struct CurrentAmount(
      [property: JsonPropertyName("value")] int Value,
       [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
       [property: JsonPropertyName("currency")] string Currency
   );

   public record struct TargetAmount(
       [property: JsonPropertyName("value")] int Value,
       [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
       [property: JsonPropertyName("currency")] string Currency
   );
}