using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

/// <summary>
/// Portrays information about bits send in chat
/// </summary>
public readonly struct BitsEvents
{
    /// <summary>
    /// Information about the cheer
    /// </summary>
    [JsonPropertyName("data")]
    public BitsData Data { get; init; }
    /// <summary>
    /// ID of the cheer message
    /// </summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; init; }
    /// <summary>
    /// Whether the cheerer was anonymous
    /// </summary>
    [JsonPropertyName("is_anonymous")]
    public bool IsAnonymous { get; init; }

    /// <summary>
    /// Information about a badge entitlement
    /// </summary>
    public readonly struct BadgeEntitlement
    {
        /// <summary>
        /// New version of the cheer badge
        /// </summary>
        [JsonPropertyName("new_version")]
        public int NewVersion { get; init; }
        /// <summary>
        /// Previous version of the cheer badge
        /// </summary>
        [JsonPropertyName("previous_version")]
        public int PreviousVersion { get; init; }
    }
    /// <summary>
    /// Contains information about a cheer event
    /// </summary>
    public readonly struct BitsData
    {
        /// <summary>
        /// Login name of the person who used the Bits - if the cheer was not anonymous. <see langword="null"/> if anonymous
        /// </summary>
        [JsonPropertyName("user_name")]
        public string? Name { get; init; }
        /// <summary>
        /// Name of the channel
        /// </summary>
        [JsonPropertyName("channel_name")]
        public string ChannelName { get; init; }
        /// <summary>
        /// User ID of the person who used the Bits - if the cheer was not anonymous. <see langword="null"/> if anonymous
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; init; }
        /// <summary>
        /// ID of the channel
        /// </summary>
        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }
        /// <summary>
        /// Time when the Bits were used
        /// </summary>
        [JsonPropertyName("time")]
        public DateTime Time { get; init; }
        /// <summary>
        /// Chat message sent with the cheer
        /// </summary>
        [JsonPropertyName("chat_message")]
        public string ChatMessage { get; init; }
        /// <summary>
        /// Number of bits used
        /// </summary>
        [JsonPropertyName("bits_used")]
        public int BitsUsed { get; init; }
        /// <summary>
        /// All time total number of Bits used in the channel by a specified user
        /// </summary>
        [JsonPropertyName("total_bits_used")]
        public int TotalBitsUsed { get; init; }
        /// <summary>
        /// Context of this event. Known values: "cheer"
        /// </summary>
        [JsonPropertyName("context")]
        public string Context { get; init; }
        /// <summary>
        /// Information about a user’s new badge level, if the cheer was not anonymous and the user reached a new badge level with this cheer. Otherwise, <see langword="null"/>.
        /// </summary>
        [JsonPropertyName("badge_entitlement")]
        public BadgeEntitlement? BadgeEntitlement { get; init; }
    }

}
