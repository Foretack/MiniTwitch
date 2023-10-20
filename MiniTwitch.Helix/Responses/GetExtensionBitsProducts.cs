using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetExtensionBitsProducts : BaseResponse<GetExtensionBitsProducts.Datum>
{
   public record Cost(
       [property: JsonPropertyName("amount")] int Amount,
       [property: JsonPropertyName("type")] string Type
   );

   public record Datum(
       [property: JsonPropertyName("sku")] string Sku,
       [property: JsonPropertyName("cost")] Cost Cost,
       [property: JsonPropertyName("in_development")] bool InDevelopment,
       [property: JsonPropertyName("display_name")] string DisplayName,
       [property: JsonPropertyName("expiration")] DateTime Expiration,
       [property: JsonPropertyName("is_broadcast")] bool IsBroadcast
   );
}