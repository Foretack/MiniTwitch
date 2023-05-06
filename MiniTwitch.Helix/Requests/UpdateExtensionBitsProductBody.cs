using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdateExtensionBitsProductBody : IJsonObject
{
    public required string SKU { get; init; }
    public required int CostBits { get; init; }
    public required string DisplayName { get; init; }
    public bool? InDevelopment { get; init; }
    public DateTime? Expiration { get; init; }
    public bool? IsBroadcast { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        sku = SKU,
        cost = new
        {
            amount = CostBits,
            type = "bits"
        },
        display_name = DisplayName,
        in_development = InDevelopment,
        expiration = Expiration,
        is_broadcast = IsBroadcast
    };
}
