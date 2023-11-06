using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdatedBitsProduct
{
    [JsonPropertyName("sku")]
    public required string SKU { get; init; }
    public required BitsCost Cost { get; init; }
    public required string DisplayName { get; init; }
    public bool? InDevelopment { get; init; }
    public DateTime? Expiration { get; init; }
    public bool? IsBroadcast { get; init; }

    public readonly struct BitsCost
    {
        public required int Amount { get; init; }
        public required string Type { get; init; }
    }
}
