using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Payloads;

/// <inheritdoc/>
public readonly struct SubscribeEvents : ISubEvent, ISubGiftEvent, IAnonSubGiftEvent
{
    /// <inheritdoc/>
    [JsonPropertyName("channel_name")]
    public string ChannelName { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("channel_id")]
    public long ChannelId { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("time")]
    public DateTime Time { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("sub_plan")]
    public string SubPlan { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("sub_plan_name")]
    public string SubPlanName { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("context")]
    public string Context { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("is_gift")]
    public bool IsGift { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("sub_message")]
    public SubMessageData SubMessage { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("recipient_id")]
    public long RecipientId { get; init; } = default;
    /// <inheritdoc/>
    [JsonPropertyName("recipient_user_name")]
    public string RecipientUsername { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("recipient_display_name")]
    public string RecipientDisplayName { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("user_name")]
    public string Username { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("display_name")]
    public string DisplayName { get; init; } = "";
    /// <inheritdoc/>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; } = 0;
    /// <inheritdoc/>
    [JsonPropertyName("months")]
    public int Months { get; init; } = 0;
    /// <inheritdoc/>
    [JsonPropertyName("streak_months")]
    public int StreakMonths { get; init; } = 0;
    /// <inheritdoc/>
    [JsonPropertyName("multi_month_duration")]
    public int MultiMonthDuration { get; init; } = 1;
    /// <inheritdoc/>
    [JsonPropertyName("cumulative_months")]
    public int CumulativeMonths { get; init; } = 0;

    internal SubscribeEvents(object? any) { }

    /// <summary>
    /// Represents information about an emote
    /// </summary>
    public readonly struct EmoteData
    {
        /// <summary>
        /// Start index of the emote in the message
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; init; }
        /// <summary>
        /// End index of the emote in the message
        /// </summary>
        [JsonPropertyName("end")]
        public int End { get; init; }
        /// <summary>
        /// ID of the emote
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; init; }
    }

    /// <summary>
    /// Represents information about the subscriber's message
    /// </summary>
    public readonly struct SubMessageData
    {
        /// <summary>
        /// The message of the subscriber
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; init; }
        /// <summary>
        /// Emotes in <see cref="Message"/>. <see langword="null"/> if there are none
        /// </summary>
        [JsonPropertyName("emotes")]
        public IReadOnlyList<EmoteData>? Emotes { get; init; }
    }
}