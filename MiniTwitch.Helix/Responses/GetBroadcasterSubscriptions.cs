using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetBroadcasterSubscriptions : PaginableResponse<GetBroadcasterSubscriptions.Datum>
{
   [property: JsonPropertyName("total")]
   public int Total { get; init; }
   [property: JsonPropertyName("points")]
   public int Points { get; init; }

   public record Datum(
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
       [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
       // TODO: this should be a long
       [property: JsonPropertyName("gifter_id")] string GifterId,
       [property: JsonPropertyName("gifter_login")] string GifterName,
       [property: JsonPropertyName("gifter_name")] string GifterDisplayName,
       [property: JsonPropertyName("is_gift")] bool IsGift,
       [property: JsonPropertyName("tier")] string Tier,
       [property: JsonPropertyName("plan_name")] string PlanName,
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("user_name")] string UserDisplayName,
       [property: JsonPropertyName("user_login")] string Username
   );
}