using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class EndPrediction : SingleResponse<EndPrediction.Datum>
{
   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
       [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
       [property: JsonPropertyName("title")] string Title,
       [property: JsonPropertyName("winning_outcome_id")] string? WinningOutcomeId,
       [property: JsonPropertyName("outcomes")] IReadOnlyList<Outcome> Outcomes,
       [property: JsonPropertyName("prediction_window")] int PredictionWindow,
       [property: JsonPropertyName("status")] string Status,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("ended_at")] DateTime? EndedAt,
       [property: JsonPropertyName("locked_at")] DateTime? LockedAt
   );

   public record Outcome(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("title")] string Title,
       [property: JsonPropertyName("users")] int Users,
       [property: JsonPropertyName("channel_points")] int ChannelPoints,
       [property: JsonPropertyName("top_predictors")] object TopPredictors,
       [property: JsonPropertyName("color")] string Color
   );
}