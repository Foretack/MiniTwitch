using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class EventSubSubscriptions : PaginableResponse<EventSubSubscriptions.Subscription>
{
    [JsonPropertyName("total_cost")]
    public int TotalCost { get; init; }
    [JsonPropertyName("max_total_cost")]
    public int MaxTotalCost { get; init; }
    [JsonPropertyName("total")]
    public int Total { get; init; }

    public record Condition(
        [property: JsonPropertyName("broadcaster_user_id")] long BroadcasterUserId,
        [property: JsonPropertyName("user_id")] long UserId
    );

    public record Subscription(
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