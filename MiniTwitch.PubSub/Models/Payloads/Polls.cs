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
    public object? TopContributor { get; init; }
    [JsonPropertyName("top_bits_contributor")]
    public object? TopBitsContributor { get; init; }
    [JsonPropertyName("top_channel_points_contributor")]
    public object? TopChannelPointsContributor { get; init; }


    public readonly struct CostSetting
    {
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }
        [JsonPropertyName("cost")]
        public int Cost { get; init; }
    }
    public readonly struct Choice
    {
        [JsonPropertyName("choice_id")]
        public string ChoiceId { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("votes")]
        public PollVotes Votes { get; init; }

        [JsonPropertyName("tokens")]
        public PollTokens Tokens { get; init; }

        [JsonPropertyName("total_voters")]
        public int TotalVoters { get; init; }
    }
    public readonly struct Setting
    {
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; init; }
    }
    public readonly struct PollSettings
    {
        [JsonPropertyName("multi_choice")]
        public Setting MultiChoice { get; init; }

        [JsonPropertyName("subscriber_only")]
        public Setting SubscriberOnly { get; init; }

        [JsonPropertyName("subscriber_multiplier")]
        public Setting SubscriberMultiplier { get; init; }

        [JsonPropertyName("bits_votes")]
        public CostSetting BitsVotes { get; init; }

        [JsonPropertyName("channel_points_votes")]
        public CostSetting ChannelPointsVotes { get; init; }

    }
    public readonly struct PollTokens
    {
        [JsonPropertyName("bits")]
        public int Bits { get; init; }

        [JsonPropertyName("channel_points")]
        public int ChannelPoints { get; init; }

    }
    public readonly struct PollVotes
    {
        [JsonPropertyName("total")]
        public int Total { get; init; }

        [JsonPropertyName("bits")]
        public int Bits { get; init; }

        [JsonPropertyName("channel_points")]
        public int ChannelPoints { get; init; }

        [JsonPropertyName("base")]
        public int Base { get; init; }

    }
}
