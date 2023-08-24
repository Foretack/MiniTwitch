using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

internal readonly struct Polls
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    public readonly record struct PayloadData(
        [property: JsonPropertyName("poll")] Poll Poll
    );
}

/// <summary>
/// Represents a chat poll
/// </summary>
public readonly struct Poll : IPollCreated, IPollUpdated, IPollCompleted
{
    /// <inheritdoc cref="IPollCreated.PollId"/>
    [JsonPropertyName("poll_id")]
    public string PollId { get; init; }
    /// <inheritdoc cref="IPollCreated.OwnedBy"/>
    [JsonPropertyName("owned_by")]
    public long OwnedBy { get; init; }
    /// <inheritdoc cref="IPollCreated.CreatedBy"/>
    [JsonPropertyName("created_by")]
    public long CreatedBy { get; init; }
    /// <inheritdoc cref="IPollCreated.Title"/>
    [JsonPropertyName("title")]
    public string Title { get; init; }
    /// <inheritdoc cref="IPollCreated.StartedAt"/>
    [JsonPropertyName("started_at")]
    public DateTime StartedAt { get; init; }
    /// <inheritdoc cref="IPollCompleted.EndedAt"/>
    [JsonPropertyName("ended_at")]
    public DateTime? EndedAt { get; init; }
    /// <inheritdoc cref="IPollCompleted.EndedBy"/>
    [JsonPropertyName("ended_by")]
    public long? EndedBy { get; init; }
    /// <inheritdoc cref="IPollCreated.DurationSeconds"/>
    [JsonPropertyName("duration_seconds")]
    public long DurationSeconds { get; init; }
    /// <inheritdoc cref="IPollCreated.Settings"/>
    [JsonPropertyName("settings")]
    public PollSettings Settings { get; init; }
    /// <summary>
    /// Status of the poll
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; init; }
    /// <inheritdoc cref="IPollCreated.Choices"/>
    [JsonPropertyName("choices")]
    public IReadOnlyList<Choice> Choices { get; init; }
    /// <inheritdoc cref="IPollUpdated.Votes"/>
    [JsonPropertyName("votes")]
    public PollVotes Votes { get; init; }
    /// <inheritdoc cref="IPollUpdated.Tokens"/>
    [JsonPropertyName("tokens")]
    public PollTokens Tokens { get; init; }
    /// <inheritdoc cref="IPollUpdated.TotalVoters"/>
    [JsonPropertyName("total_voters")]
    public int TotalVoters { get; init; }
    /// <inheritdoc cref="IPollUpdated.RemainingDurationMilliseconds"/>
    [JsonPropertyName("remaining_duration_milliseconds")]
    public long RemainingDurationMilliseconds { get; init; }
    /// <inheritdoc cref="IPollUpdated.TopContributor"/>
    [JsonPropertyName("top_contributor")]
    public object? TopContributor { get; init; }
    /// <inheritdoc cref="IPollUpdated.TopBitsContributor"/>
    [JsonPropertyName("top_bits_contributor")]
    public object? TopBitsContributor { get; init; }
    /// <inheritdoc cref="IPollUpdated.TopChannelPointsContributor"/>
    [JsonPropertyName("top_channel_points_contributor")]
    public object? TopChannelPointsContributor { get; init; }

    /// <summary>
    /// Contains information about the cost settings of the poll
    /// </summary>
    public readonly struct CostSetting
    {
        /// <summary>
        /// Whether voting in the poll has a cost
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }
        /// <summary>
        /// Cost of voting
        /// </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; init; }
    }
    /// <summary>
    /// Represents information about a poll voting choice
    /// </summary>
    public readonly struct Choice
    {
        /// <summary>
        /// ID of the choice
        /// </summary>
        [JsonPropertyName("choice_id")]
        public string ChoiceId { get; init; }
        /// <summary>
        /// The title of the choice
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; }
        /// <summary>
        /// Votes information about the choice
        /// </summary>
        [JsonPropertyName("votes")]
        public PollVotes Votes { get; init; }
        /// <summary>
        /// Bit/point information about the choice
        /// </summary>
        [JsonPropertyName("tokens")]
        public PollTokens Tokens { get; init; }
        /// <summary>
        /// Total amount of voters
        /// </summary>
        [JsonPropertyName("total_voters")]
        public int TotalVoters { get; init; }
    }
    /// <summary>
    /// Represents a vote setting
    /// </summary>
    public readonly struct Setting
    {
        /// <summary>
        /// Whether this setting is enabled
        /// </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }
    }
    /// <summary>
    /// Contains information about the poll's settings
    /// </summary>
    public readonly struct PollSettings
    {
        /// <summary>
        /// Whether the poll has multiple choices
        /// <para>This is always <see langword="true"/></para>
        /// </summary>
        [JsonPropertyName("multi_choice")]
        public Setting MultiChoice { get; init; }
        /// <summary>
        /// Whether the poll is subscriber-only
        /// </summary>
        [JsonPropertyName("subscriber_only")]
        public Setting SubscriberOnly { get; init; }
        /// <summary>
        /// Whether the poll gives subscribers higher voting power
        /// </summary>
        [JsonPropertyName("subscriber_multiplier")]
        public Setting SubscriberMultiplier { get; init; }
        /// <summary>
        /// Whether the poll requires users to vote with bits
        /// </summary>
        [JsonPropertyName("bits_votes")]
        public CostSetting BitsVotes { get; init; }
        /// <summary>
        /// Whether the poll requires users to vote with channel points
        /// </summary>
        [JsonPropertyName("channel_points_votes")]
        public CostSetting ChannelPointsVotes { get; init; }

    }
    /// <summary>
    /// Contains total bits/channel points used in a poll
    /// </summary>
    public readonly struct PollTokens
    {
        /// <summary>
        /// Total amount of bits used
        /// </summary>
        [JsonPropertyName("bits")]
        public int Bits { get; init; }
        /// <summary>
        /// Total amount of channel points spent
        /// </summary>
        [JsonPropertyName("channel_points")]
        public int ChannelPoints { get; init; }

    }
    /// <summary>
    /// Contains information about the votes of a poll or choice
    /// </summary>
    public readonly struct PollVotes
    {
        /// <summary>
        /// Total voters
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; init; }
        /// <summary>
        /// Total bits used
        /// </summary>
        [JsonPropertyName("bits")]
        public int Bits { get; init; }
        /// <summary>
        /// Total channel points spent
        /// </summary>
        [JsonPropertyName("channel_points")]
        public int ChannelPoints { get; init; }
    }
}
