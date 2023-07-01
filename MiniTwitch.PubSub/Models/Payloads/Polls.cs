using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct Polls
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }


    public readonly record struct CostSetting(
        [property: JsonPropertyName("is_enabled")] bool IsEnabled,
        [property: JsonPropertyName("cost")] int Cost
    );

    public readonly record struct Choice(
        [property: JsonPropertyName("choice_id")] string ChoiceId,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("votes")] Votes Votes,
        [property: JsonPropertyName("tokens")] Tokens Tokens,
        [property: JsonPropertyName("total_voters")] int TotalVoters
    );

    public readonly record struct PayloadData(
        [property: JsonPropertyName("poll")] Poll Poll
    );

    public readonly record struct Setting(
        [property: JsonPropertyName("is_enabled")] bool IsEnabled
    );

    public readonly record struct Poll(
        [property: JsonPropertyName("poll_id")] string PollId,
        [property: JsonPropertyName("owned_by")] long OwnedBy,
        [property: JsonPropertyName("created_by")] long CreatedBy,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("started_at")] DateTime StartedAt,
        [property: JsonPropertyName("ended_at")] DateTime? EndedAt,
        [property: JsonPropertyName("ended_by")] long? EndedBy,
        [property: JsonPropertyName("duration_seconds")] int DurationSeconds,
        [property: JsonPropertyName("settings")] Settings Settings,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("choices")] IReadOnlyList<Choice> Choices,
        [property: JsonPropertyName("votes")] Votes Votes,
        [property: JsonPropertyName("tokens")] Tokens Tokens,
        [property: JsonPropertyName("total_voters")] int TotalVoters,
        [property: JsonPropertyName("remaining_duration_milliseconds")] long RemainingDurationMilliseconds,
        [property: JsonPropertyName("top_contributor")] string? TopContributor,
        [property: JsonPropertyName("top_bits_contributor")] string? TopBitsContributor,
        [property: JsonPropertyName("top_channel_points_contributor")] string? TopChannelPointsContributor
    );

    public readonly record struct Settings(
        [property: JsonPropertyName("multi_choice")] Setting MultiChoice,
        [property: JsonPropertyName("subscriber_only")] Setting SubscriberOnly,
        [property: JsonPropertyName("subscriber_multiplier")] Setting SubscriberMultiplier,
        [property: JsonPropertyName("bits_votes")] CostSetting BitsVotes,
        [property: JsonPropertyName("channel_points_votes")] CostSetting ChannelPointsVotes
    );

    public readonly record struct Tokens(
        [property: JsonPropertyName("bits")] int Bits,
        [property: JsonPropertyName("channel_points")] int ChannelPoints
    );

    public readonly record struct Votes(
        [property: JsonPropertyName("total")] int Total,
        [property: JsonPropertyName("bits")] int Bits,
        [property: JsonPropertyName("channel_points")] int ChannelPoints,
        [property: JsonPropertyName("base")] int Base
    );
}
