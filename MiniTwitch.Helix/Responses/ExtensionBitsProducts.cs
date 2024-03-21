using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionBitsProducts : BaseResponse<ExtensionBitsProducts.BitsProduct>
{
    public record Cost(
        int Amount,
        string Type
    );

    public record BitsProduct(
        [property: JsonPropertyName("sku")] string SKU,
        Cost Cost,
        bool InDevelopment,
        string DisplayName,
        DateTime Expiration,
        bool IsBroadcast
    );
}