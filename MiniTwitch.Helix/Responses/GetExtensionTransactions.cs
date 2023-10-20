using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetExtensionTransactions : PaginableResponse<GetExtensionTransactions.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("timestamp")] DateTime Timestamp,
       [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
       [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
       [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
       [property: JsonPropertyName("user_id")] string UserId,
       [property: JsonPropertyName("user_login")] string UserLogin,
       [property: JsonPropertyName("user_name")] string UserName,
       [property: JsonPropertyName("product_type")] string ProductType,
       [property: JsonPropertyName("product_data")] ProductData ProductData
   );
   public record ProductData(
       [property: JsonPropertyName("domain")] string Domain,
       [property: JsonPropertyName("sku")] string Sku,
       [property: JsonPropertyName("cost")] Cost Cost,
       [property: JsonPropertyName("inDevelopment")] bool InDevelopment,
       [property: JsonPropertyName("displayName")] string DisplayName,
       [property: JsonPropertyName("expiration")] string Expiration,
       [property: JsonPropertyName("broadcast")] bool Broadcast
   );
   public record Cost(
       [property: JsonPropertyName("amount")] int Amount,
       [property: JsonPropertyName("type")] string Type
   );
}