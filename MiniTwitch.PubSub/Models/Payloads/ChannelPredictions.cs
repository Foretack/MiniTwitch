using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct ChannelPredictions
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("data")]
    public PredictionData Data { get; init; }

    public readonly record struct PredictionData(
        [property: JsonPropertyName("timestamp")] DateTime Timestamp,
        [property: JsonPropertyName("event")] EventData Event
    );

    public readonly record struct EventData(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("channel_id")] long ChannelId,
        [property: JsonPropertyName("created_at")] DateTime CreatedAt,
        [property: JsonPropertyName("created_by")] User CreatedBy,
        [property: JsonPropertyName("ended_at")] DateTime? EndedAt,
        [property: JsonPropertyName("ended_by")] User? EndedBy,
        [property: JsonPropertyName("locked_at")] DateTime? LockedAt,
        [property: JsonPropertyName("locked_by")] User? LockedBy,
        [property: JsonPropertyName("outcomes")] IReadOnlyList<Outcome> Outcomes,
        [property: JsonPropertyName("prediction_window_seconds")] int PredictionWindowSeconds,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("winning_outcome_id")] string WinningOutcomeId
    ) : IPredictionStarted, IPredictionUpdate, IPredictionWindowClosed, IPredictionEnded,
        IPredictionLocked, IPredictionCancelled;

    public readonly record struct User(
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("user_display_name")] string UserDisplayName,
        [property: JsonPropertyName("extension_client_id")] string? ExtensionClientId
    );

    public readonly record struct Outcome(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("color")] string Color,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("total_points")] int TotalPoints,
        [property: JsonPropertyName("total_users")] int TotalUsers,
        [property: JsonPropertyName("top_predictors")] IReadOnlyList<Predictor> TopPredictors,
        [property: JsonPropertyName("badge")] Badge Badge
    );

    public readonly record struct Predictor(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("event_id")] string EventId,
        [property: JsonPropertyName("outcome_id")] string OutcomeId,
        [property: JsonPropertyName("channel_id")] string ChannelId,
        [property: JsonPropertyName("points")] int Points,
        [property: JsonPropertyName("predicted_at")] string PredictedAt,
        [property: JsonPropertyName("updated_at")] string UpdatedAt,
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("result")] Result? Result,
        [property: JsonPropertyName("user_display_name")] string UserDisplayName
    );

    public readonly record struct Result(
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("points_won")] int? PointsWon,
        [property: JsonPropertyName("is_acknowledged")] bool IsAcknowledged
    );

    public readonly record struct Badge(
        [property: JsonPropertyName("version")] string Version,
        [property: JsonPropertyName("set_id")] string SetId
    );
}
