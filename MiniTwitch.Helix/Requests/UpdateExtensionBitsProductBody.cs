using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdateExtensionBitsProductBody
{
    [JsonPropertyName("sku")]
    public required string SKU { get; init; }
    [JsonIgnore]
    public required int CostBits { get; init; }
    [JsonInclude]
    private object cost => new { amount = CostBits, type = "bits" };
    public required string DisplayName { get; init; }
    public bool? InDevelopment { get; init; }
    public DateTime? Expiration { get; init; }
    public bool? IsBroadcast { get; init; }
}
