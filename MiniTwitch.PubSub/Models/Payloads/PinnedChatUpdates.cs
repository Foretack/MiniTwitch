using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

/// Not exposed
public readonly struct PinnedChatUpdates
{
    /// Not exposed
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// Not exposed
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    /// Not exposed
    public readonly struct PayloadData : IModPinnedMessage, IModUnpinnedMessage, IHypeChatPinnedMessage
    {
        /// <inheritdoc/>
        [JsonPropertyName("id")]
        public string Id { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("pinned_by")]
        public UserInfo PinnedBy { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("unpinned_by")]
        public UserInfo UnpinnedBy { get; init; }
        /// Not exposed
        [JsonPropertyName("message")]
        public MessageData Message { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("reason")]
        public string Reason { get; init; }
    }

    /// <summary>
    /// Represents a user that pinned a message
    /// </summary>
    public readonly struct UserInfo
    {
        /// <summary>
        /// ID of the user
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; init; }
        /// <summary>
        /// Display name of the user
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }
    }

    /// <summary>
    /// Represents information and contents of a pinned message
    /// </summary>
    public readonly struct MessageData : IModPinnedMessageData, IModPinnedMessageDataUpdate, IHypeChatPinnedMessageData
    {
        /// <inheritdoc/>
        [JsonPropertyName("id")]
        public string Id { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("ends_at")]
        public long EndsAt { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("sender")]
        public MessageSenderInfo Sender { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("content")]
        public MessageContent Content { get; init; }
        /// Not exposed
        [JsonPropertyName("type")]
        public string Type { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("starts_at")]
        public long StartsAt { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("sent_at")]
        public long SentAt { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; init; }
        /// <inheritdoc/>
        [JsonPropertyName("metadata")]
        public PaidMessageMetadata? Metadata { get; init; }
    }

    /// <summary>
    /// Contains information about a pinned message's sender
    /// </summary>
    public readonly struct MessageSenderInfo
    {
        /// <summary>
        /// ID of the sender
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; init; }
        /// <summary>
        /// Display name of the sender
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }
        /// <summary>
        /// The chat color code of the sender
        /// </summary>
        [JsonPropertyName("chat_color")]
        public string ColorCode { get; init; }
    }

    /// <summary>
    /// Contains information about a pinned message's content
    /// </summary>
    public readonly struct MessageContent
    {
        /// <summary>
        /// Text content of the message
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; init; }
        /// <summary>
        /// Emotes in <see cref="Text"/>. <see langword="null"/> if there are none
        /// </summary>
        [JsonPropertyName("emotes")]
        public IReadOnlyList<EmoteData>? Emotes { get; init; }
    }

    /// <summary>
    /// Contains data about a paid pinned message (hype chat)
    /// </summary>
    public readonly struct PaidMessageMetadata
    {
        /// <summary>
        /// The paid amount, unraised
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; init; }
        /// I don't know what this does, it's not documented anywhere
        [JsonPropertyName("canonical-amount")]
        public int CanonicalAmount { get; init; }
        /// <summary>
        /// Currency used
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; init; }
        /// <summary>
        /// The exponent to negatively raise <see cref="Amount"/> with
        /// </summary>
        [JsonPropertyName("exponent")]
        public int Exponent { get; init; }
        /// <summary>
        /// Hype chat level
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; init; }
        /// <summary>
        /// Gets the actual amount of money sent using this formula: <c>Amount * Math.Pow(10, -Exponent)</c>
        /// </summary>
        /// <returns></returns>
        public double GetActualAmount() => this.Amount * Math.Pow(10, -this.Exponent);
    }

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
}