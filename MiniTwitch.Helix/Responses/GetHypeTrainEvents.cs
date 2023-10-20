using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetHypeTrainEvents : PaginableResponse<GetHypeTrainEvents.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("event_type")] string EventType,
       [property: JsonPropertyName("event_timestamp")] DateTime EventTimestamp,
       [property: JsonPropertyName("version")] string Version,
       [property: JsonPropertyName("event_data")] EventData EventData
   );

   public record EventData(
       [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
       [property: JsonPropertyName("cooldown_end_time")] string CooldownEndTime,
       [property: JsonPropertyName("expires_at")] string ExpiresAt,
       [property: JsonPropertyName("goal")] int Goal,
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("last_contribution")] Contribution LastContribution,
       [property: JsonPropertyName("level")] int Level,
       [property: JsonPropertyName("started_at")] string StartedAt,
       [property: JsonPropertyName("top_contributions")] IReadOnlyList<Contribution> TopContributions,
       [property: JsonPropertyName("total")] int Total
   );

   public record Contribution(
       [property: JsonPropertyName("total")] int Total,
       [property: JsonPropertyName("type")] string Type,
       [property: JsonPropertyName("user")] long UserId
   );

}