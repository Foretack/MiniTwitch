using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models.Payloads;

/// <summary>
///  Received when AutoMod flags a message as potentially inappropriate, and when a moderator takes action on a message.
/// </summary>
public readonly struct AutoModQueue
{
    /// <summary>
    /// Action type
    /// <para>Known values: automod_caught_message</para>
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; }
    /// <summary>
    /// Payload data
    /// </summary>
    [JsonPropertyName("data")]
    public PayloadData Data { get; init; }

    /// <summary>
    /// AutoMod data
    /// </summary>
    public readonly struct PayloadData
    {
        /// <summary>
        /// Message information
        /// </summary>
        [JsonPropertyName("message")]
        public UserMessage Message { get; init; }
        /// <summary>
        /// Object defining the category and level that the content was classified as
        /// </summary>
        [JsonPropertyName("content_classification")]
        public ContentClassification ContentClassification { get; init; }
        /// <summary>
        /// Current status of the message, can be “PENDING”, “ALLOWED”, “DENIED”, or “EXPIRED”.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; init; }
        /// <summary>
        /// User ID of the moderator that resolved this message
        /// </summary>
        [JsonPropertyName("resolver_id")]
        public long ResolverId { get; init; }
        /// <summary>
        /// Name of the moderator that resolved this message
        /// </summary>
        [JsonPropertyName("resolver_login")]
        public string ResolverName { get; init; }
    }
    /// <summary>
    /// Represents the message that was sent that violated AutoMod
    /// </summary>
    public readonly struct UserMessage
    {
        /// <summary>
        /// ID of the message
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; init; }
        /// <summary>
        /// Content of the message
        /// </summary>
        [JsonPropertyName("content")]
        public MessageContent Content { get; init; }
        /// <summary>
        /// Sender of the message
        /// </summary>
        [JsonPropertyName("sender")]
        public MessageSender Sender { get; init; }
        /// <summary>
        /// Time when the message was sent
        /// </summary>
        [JsonPropertyName("sent_at")]
        public DateTime SentAt { get; init; }
    }
    /// <summary>
    /// Contents of the message
    /// </summary>
    public readonly struct MessageContent
    {
        /// <summary>
        /// Text content of the message
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; init; }
        /// <summary>
        /// Segments of the message that violated AutoMod
        /// </summary>
        [JsonPropertyName("fragments")]
        public Fragments[] Fragments { get; init; }
    }
    /// <summary>
    /// Portrays a segment of a message that violated AutoMod
    /// </summary>
    public readonly struct Fragments
    {
        /// <summary>
        /// Text of the segment
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; init; }
        /// <summary>
        /// AutoMod information on this segment
        /// </summary>
        [JsonPropertyName("automod")]
        public FragmentsAutomod Automod { get; init; }
    }
    /// <summary>
    /// AutoMod classification of a text segment
    /// </summary>
    public readonly struct FragmentsAutomod
    {
        /// <summary>
        /// A collection of classifications for the text segments and their respective levels
        /// </summary>
        [JsonPropertyName("topics")]
        public Dictionary<string, double> Topics { get; init; }
    }
    /// <summary>
    /// Information about a message author
    /// </summary>
    public readonly struct MessageSender
    {
        /// <summary>
        /// ID of the user that sent the message
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; init; }
        /// <summary>
        /// Name of the user that sent the message
        /// </summary>
        [JsonPropertyName("login")]
        public string Name { get; init; }
        /// <summary>
        /// Display name of the user that sent the message
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }
        /// <summary>
        /// The user's chat color's code
        /// </summary>
        [JsonPropertyName("chat_color")]
        public string ColorCode { get; init; }
    }
    /// <summary>
    /// The final classification of the message content
    /// </summary>
    public readonly struct ContentClassification
    {
        /// <summary>
        /// Category of classification
        /// </summary>
        [JsonPropertyName("category")]
        public string Category { get; init; }
        /// <summary>
        /// Level of classification
        /// </summary>
        [JsonPropertyName("level")]
        public double Level { get; init; }
    }

}