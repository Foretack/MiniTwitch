using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public class UpdatedBitsProduct
{
    [JsonPropertyName("sku")]
    public string SKU { get; }
    public BitsCost Cost { get; }
    public string DisplayName { get; }
    public bool? InDevelopment { get; }
    public DateTime? Expiration { get; }
    public bool? IsBroadcast { get; }

    public readonly struct BitsCost
    {
        public int Amount { get; }
        public string Type { get; }

        public BitsCost(int amount, string type)
        {
            this.Amount = amount;
            this.Type = type;
        }
    }

    public UpdatedBitsProduct(
        string sku,
        BitsCost cost,
        string displayName,
        bool? inDevelopment = null,
        DateTime? expiration = null,
        bool? isBroadcast = null
    )
    {
        this.SKU = sku;
        this.Cost = cost;
        this.DisplayName = displayName;
        this.InDevelopment = inDevelopment;
        this.Expiration = expiration;
        this.IsBroadcast = isBroadcast;
    }
}
