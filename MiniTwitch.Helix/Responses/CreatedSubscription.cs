using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class CreatedSubscription : SingleResponse<CreatedSubscription.Info>
{
    [JsonPropertyName("total")]
    public int Total { get; init; }
    [JsonPropertyName("total_cost")]
    public int TotalCost { get; init; }
    [JsonPropertyName("max_total_cost")]
    public int MaxTotalCost { get; init; }

    public record Condition(
        [property: JsonPropertyName("user_id")] long UserId
    );

    public record Info(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("version")] string Version,
        [property: JsonPropertyName("condition")] Condition Condition,
        [property: JsonPropertyName("created_at")] string CreatedAt,
        [property: JsonPropertyName("transport")] Transport Transport,
        [property: JsonPropertyName("cost")] int Cost
    );

    public record Transport(
        [property: JsonPropertyName("method")] string Method,
        [property: JsonPropertyName("callback")] string Callback
    );
}