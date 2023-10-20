using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class CheckUserSubscription : SingleResponse<CheckUserSubscription.Datum>
{
   public record Datum(
       [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
       [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
       [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
       [property: JsonPropertyName("is_gift")] bool IsGift,
       [property: JsonPropertyName("tier")] string Tier
   );
}