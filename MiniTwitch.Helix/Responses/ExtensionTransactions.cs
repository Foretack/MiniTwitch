using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionTransactions : PaginableResponse<ExtensionTransactions.Transaction>
{
    public record Transaction(
        string Id,
        DateTime Timestamp,
        long BroadcasterId,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
      long UserId,
        [property: JsonPropertyName("user_login")] string UserName,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
        string ProductType,
        ProductData ProductData
    );
    public record ProductData(
        string Domain,
        string Sku,
        Cost Cost,
        [property: JsonPropertyName("inDevelopment")] bool InDevelopment,
        [property: JsonPropertyName("displayName")] string DisplayName,
        string Expiration,
        bool Broadcast
    );
    public record Cost(
        int Amount,
        string Type
    );
}