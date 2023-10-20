using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionBitsProducts : BaseResponse<ExtensionBitsProducts.BitsProduct>
{
    public record Cost(
        [property: JsonPropertyName("amount")] int Amount,
        [property: JsonPropertyName("type")] string Type
    );

    public record BitsProduct(
        [property: JsonPropertyName("sku")] string SKU,
        [property: JsonPropertyName("cost")] Cost Cost,
        [property: JsonPropertyName("in_development")] bool InDevelopment,
        [property: JsonPropertyName("display_name")] string DisplayName,
        [property: JsonPropertyName("expiration")] DateTime Expiration,
        [property: JsonPropertyName("is_broadcast")] bool IsBroadcast
    );
}