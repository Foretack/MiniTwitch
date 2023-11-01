using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionTransactions : PaginableResponse<ExtensionTransactions.Transaction>
{
    public record Transaction(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("timestamp")] DateTime Timestamp,
        [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("user_login")] string UserName,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
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