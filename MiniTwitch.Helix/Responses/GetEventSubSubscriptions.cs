using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetEventSubSubscriptions : BaseResponse<GetEventSubSubscriptions.Datum>, IPaginable
{
   [JsonPropertyName("pagination")]
   public Pagination Pagination { get; init; }
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

   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("status")] string Status,
       [property: JsonPropertyName("type")] string Type,
       [property: JsonPropertyName("version")] string Version,
       [property: JsonPropertyName("condition")] Condition Condition,
       [property: JsonPropertyName("created_at")] string CreatedAt,
       [property: JsonPropertyName("transport")] Transport Transport,
       [property: JsonPropertyName("cost")] int Cost
   );

   public record Root(
       [property: JsonPropertyName("total")] int Total,
       [property: JsonPropertyName("data")] IReadOnlyList<Datum> Data,
       [property: JsonPropertyName("total_cost")] int TotalCost,
       [property: JsonPropertyName("max_total_cost")] int MaxTotalCost,
       [property: JsonPropertyName("pagination")] Pagination Pagination
   );

   public record Transport(
       [property: JsonPropertyName("method")] string Method,
       [property: JsonPropertyName("callback")] string Callback
   );
}