using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

/// Not exposed
public readonly struct ChannelPredictions
{
    /// Not exposed
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// Not exposed
    [JsonPropertyName("data")]
    public PredictionData Data { get; init; }
    /// Not exposed
    public readonly struct PredictionData
    {
        /// Not exposed
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; init; }
        /// Not exposed
        [JsonPropertyName("event")]
        public EventData Event { get; init; }
    }

    /// Not exposed
    public readonly struct EventData : IPredictionStarted, IPredictionUpdate, IPredictionWindowClosed,
        IPredictionEnded, IPredictionLocked, IPredictionCancelled
    {
        /// Not exposed
        [JsonPropertyName("id")]
        public string Id { get; init; }
        /// Not exposed
        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }
        /// Not exposed
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; init; }
        /// Not exposed
        [JsonPropertyName("created_by")]
        public User CreatedBy { get; init; }
        /// Not exposed
        [JsonPropertyName("ended_at")]
        public DateTime? EndedAt { get; init; }
        /// Not exposed
        [JsonPropertyName("ended_by")]
        public User? EndedBy { get; init; }
        /// Not exposed
        [JsonPropertyName("locked_at")]
        public DateTime? LockedAt { get; init; }
        /// Not exposed
        [JsonPropertyName("locked_by")]
        public User? LockedBy { get; init; }
        /// Not exposed
        [JsonPropertyName("outcomes")]
        public IReadOnlyList<Outcome> Outcomes { get; init; }
        /// Not exposed
        [JsonPropertyName("prediction_window_seconds")]
        public int PredictionWindowSeconds { get; init; }
        /// Not exposed
        [JsonPropertyName("status")]
        public string Status { get; init; }
        /// Not exposed
        [JsonPropertyName("title")]
        public string Title { get; init; }
        /// Not exposed
        [JsonPropertyName("winning_outcome_id")]
        public string WinningOutcomeId { get; init; }
    }

    /// Not exposed
    public readonly struct User
    {
        /// <summary>
        /// Type of the user
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; init; }
        /// <summary>
        /// ID of the user
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; init; }
        /// <summary>
        /// Display name of the user
        /// </summary>
        [JsonPropertyName("user_display_name")]
        public string DisplayName { get; init; }
        /// <summary>
        /// It's not known what purpose this serves
        /// </summary>
        [JsonPropertyName("extension_client_id")]
        public string? ExtensionClientId { get; init; }
    }
    /// Not exposed
    public readonly struct Outcome
    {
        /// <summary>
        /// ID to identify this outcome
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; }
        /// <summary>
        /// Color of this outcome when shown on webchat
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; init; }
        /// <summary>
        /// Title of the outcome
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; }
        /// <summary>
        /// Total amount of points on this outcome from all users combined
        /// <para>This value is 0 when the predictions starts</para>
        /// </summary>
        [JsonPropertyName("total_points")]
        public int TotalPoints { get; init; }
        /// <summary>
        /// Total amount of users that chose this outcome
        /// <para>This value is 0 when the prediction starts</para>
        /// </summary>
        [JsonPropertyName("total_users")]
        public int TotalUsers { get; init; }
        /// <summary>
        /// The top 10 users with the most points spent on this outcome
        /// <para>This collection is empty when the prediction starts</para>
        /// </summary>
        [JsonPropertyName("top_predictors")]
        public IReadOnlyList<Predictor> TopPredictors { get; init; }
        /// <summary>
        /// Badge information about this outcome - what badge should the users who chose this outcome have?
        /// </summary>
        [JsonPropertyName("badge")]
        public Badge Badge { get; init; }
    }
    /// <summary>
    /// Represents a user that made a prediction
    /// </summary>
    public readonly struct Predictor
    {
        /// <summary>
        /// ID of the predictor's participation
        /// <para>User ID is <see cref="UserId"/></para>
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; }
        /// <summary>
        /// ID of the prediction
        /// </summary>
        [JsonPropertyName("event_id")]
        public string EventId { get; init; }
        /// <summary>
        /// ID of the outcome the user chose
        /// </summary>
        [JsonPropertyName("outcome_id")]
        public string OutcomeId { get; init; }
        /// <summary>
        /// ID of the channel
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; init; }
        /// <summary>
        /// The amount of points the user spent on the outcome
        /// </summary>
        [JsonPropertyName("points")]
        public int Points { get; init; }
        /// <summary>
        /// Time at which the user made the prediction
        /// </summary>
        [JsonPropertyName("predicted_at")]
        public DateTime PredictedAt { get; init; }
        /// <summary>
        /// Time at which the user updated their choice - possibly when they spent even more points on the outcome
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; init; }
        /// <summary>
        /// ID of the user
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; init; }
        /// <summary>
        /// Result of the user's choice
        /// <para>This value is not null only when the prediction ends (<see cref="IPredictionEnded"/>)</para>
        /// </summary>
        [JsonPropertyName("result")]
        public Result? Result { get; init; }
        /// <summary>
        /// Display name of the user
        /// </summary>
        [JsonPropertyName("user_display_name")]
        public string DisplayName { get; init; }
    }
    /// <summary>
    /// Represents a user's win or loss
    /// </summary>
    public readonly struct Result
    {
        /// <summary>
        /// The user's result outcome. Can be either "WIN" or "LOSE"
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; init; }
        /// <summary>
        /// Amount of points the user won
        /// <para>This value is null if <see cref="Type"/> == "LOSE"</para>
        /// </summary>
        [JsonPropertyName("points_won")]
        public int? PointsWon { get; init; }
        /// <summary>
        /// It's not known what purpose this serves
        /// </summary>
        [JsonPropertyName("is_acknowledged")]
        public bool IsAcknowledged { get; init; }
    }
    /// <summary>
    /// Information about the prediction badge
    /// </summary>
    public readonly struct Badge
    {
        /// <summary>
        /// Version/name of the badge
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; init; }
        /// <summary>
        /// Name of the set the badge belongs to
        /// </summary>
        [JsonPropertyName("set_id")]
        public string SetId { get; init; }
    }
}
