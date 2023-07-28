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

public readonly struct Poll : IPollCreated, IPollUpdated, IPollCompleted
{
    [JsonPropertyName("poll_id")]
    public string PollId { get; init; }
    [JsonPropertyName("owned_by")]
    public long OwnedBy { get; init; }
    [JsonPropertyName("created_by")]
    public long CreatedBy { get; init; }
    [JsonPropertyName("title")]
    public string Title { get; init; }
    [JsonPropertyName("started_at")]
    public DateTime StartedAt { get; init; }
    [JsonPropertyName("ended_at")]
    public DateTime? EndedAt { get; init; }
    [JsonPropertyName("ended_by")]
    public long? EndedBy { get; init; }
    [JsonPropertyName("duration_seconds")]
    public long DurationSeconds { get; init; }
    [JsonPropertyName("settings")]
    public PollSettings Settings { get; init; }
    [JsonPropertyName("status")]
    public string Status { get; init; }
    [JsonPropertyName("choices")]
    public IReadOnlyList<Choice> Choices { get; init; }
    [JsonPropertyName("votes")]
    public PollVotes Votes { get; init; }
    [JsonPropertyName("tokens")]
    public PollTokens Tokens { get; init; }
    [JsonPropertyName("total_voters")]
    public int TotalVoters { get; init; }
    [JsonPropertyName("remaining_duration_milliseconds")]
    public long RemainingDurationMilliseconds { get; init; }
    [JsonPropertyName("top_contributor")]
    public string? TopContributor { get; init; }
    [JsonPropertyName("top_bits_contributor")]
    public string? TopBitsContributor { get; init; }
    [JsonPropertyName("top_channel_points_contributor")]
    public string? TopChannelPointsContributor { get; init; }


    public readonly record struct CostSetting(
        [property: JsonPropertyName("is_enabled")] bool IsEnabled,
        [property: JsonPropertyName("cost")] int Cost
    );
    public readonly record struct Choice(
        [property: JsonPropertyName("choice_id")] string ChoiceId,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("votes")] PollVotes Votes,
        [property: JsonPropertyName("tokens")] PollTokens Tokens,
        [property: JsonPropertyName("total_voters")] int TotalVoters
    );
    public readonly record struct Setting(
        [property: JsonPropertyName("is_enabled")] bool IsEnabled
    );
    public readonly record struct PollSettings(
        [property: JsonPropertyName("multi_choice")] Setting MultiChoice,
        [property: JsonPropertyName("subscriber_only")] Setting SubscriberOnly,
        [property: JsonPropertyName("subscriber_multiplier")] Setting SubscriberMultiplier,
        [property: JsonPropertyName("bits_votes")] CostSetting BitsVotes,
        [property: JsonPropertyName("channel_points_votes")] CostSetting ChannelPointsVotes
    );
    public readonly record struct PollTokens(
        [property: JsonPropertyName("bits")] int Bits,
        [property: JsonPropertyName("channel_points")] int ChannelPoints
    );
    public readonly record struct PollVotes(
        [property: JsonPropertyName("total")] int Total,
        [property: JsonPropertyName("bits")] int Bits,
        [property: JsonPropertyName("channel_points")] int ChannelPoints,
        [property: JsonPropertyName("base")] int Base
    );
}
