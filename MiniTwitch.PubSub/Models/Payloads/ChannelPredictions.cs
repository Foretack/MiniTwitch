using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct ChannelPredictions
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("data")]
    public PredictionData Data { get; init; }

    public readonly struct PredictionData
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }

        [JsonPropertyName("event")]
        public EventData Event { get; init; }
    }

    public readonly struct EventData : IPredictionStarted, IPredictionUpdate, IPredictionWindowClosed,
        IPredictionEnded, IPredictionLocked, IPredictionCancelled
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; }

        [JsonPropertyName("created_by")]
        public User CreatedBy { get; init; }

        [JsonPropertyName("ended_at")]
        public DateTime? EndedAt { get; init; }

        [JsonPropertyName("ended_by")]
        public User? EndedBy { get; init; }

        [JsonPropertyName("locked_at")]
        public DateTime? LockedAt { get; init; }

        [JsonPropertyName("locked_by")]
        public User? LockedBy { get; init; }

        [JsonPropertyName("outcomes")]
        public IReadOnlyList<Outcome> Outcomes { get; init; }

        [JsonPropertyName("prediction_window_seconds")]
        public int PredictionWindowSeconds { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("winning_outcome_id")]
        public string WinningOutcomeId { get; init; }
    }

    public readonly struct User
    {
        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("user_id")]
        public long UserId { get; init; }

        [JsonPropertyName("user_display_name")]
        public string UserDisplayName { get; init; }

        [JsonPropertyName("extension_client_id")]
        public string? ExtensionClientId { get; init; }
    }
    public readonly struct Outcome
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("color")]
        public string Color { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; init; }

        [JsonPropertyName("total_users")]
        public int TotalUsers { get; init; }

        [JsonPropertyName("top_predictors")]
        public IReadOnlyList<Predictor> TopPredictors { get; init; }

        [JsonPropertyName("badge")]
        public Badge Badge { get; init; }
    }
    public readonly struct Predictor
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("event_id")]
        public string EventId { get; init; }

        [JsonPropertyName("outcome_id")]
        public string OutcomeId { get; init; }

        [JsonPropertyName("channel_id")]
        public string ChannelId { get; init; }

        [JsonPropertyName("points")]
        public int Points { get; init; }

        [JsonPropertyName("predicted_at")]
        public string PredictedAt { get; init; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; }

        [JsonPropertyName("user_id")]
        public long UserId { get; init; }

        [JsonPropertyName("result")]
        public Result? Result { get; init; }

        [JsonPropertyName("user_display_name")]
        public string UserDisplayName { get; init; }
    }
    public readonly struct Result
    {
        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("points_won")]
        public int? PointsWon { get; init; }

        [JsonPropertyName("is_acknowledged")]
        public bool IsAcknowledged { get; init; }
    }
    public readonly struct Badge
    {
        [JsonPropertyName("version")]
        public string Version { get; init; }

        [JsonPropertyName("set_id")]
        public string SetId { get; init; }
    }
}
