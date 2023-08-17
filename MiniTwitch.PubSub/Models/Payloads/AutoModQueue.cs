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

    public readonly struct PayloadData
    {
        [JsonPropertyName("message")]
        public PayloadMessage Message { get; init; }

        [JsonPropertyName("content_classification")]
        public ContentClassification ContentClassification { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; }

        [JsonPropertyName("reason_code")]
        public string ReasonCode { get; init; }

        [JsonPropertyName("resolver_id")]
        public long ResolverId { get; init; }

        [JsonPropertyName("resolver_login")]
        public string ResolverName { get; init; }
    }
    public readonly struct PayloadMessage
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("content")]
        public MessageContent Content { get; init; }

        [JsonPropertyName("sender")]
        public MessageSender Sender { get; init; }

        [JsonPropertyName("sent_at")]
        public DateTime SentAt { get; init; }
    }
    public readonly struct MessageContent
    {
        [JsonPropertyName("text")]
        public string Text { get; init; }

        [JsonPropertyName("fragments")]
        public Fragments[] Fragments { get; init; }
    }
    public readonly struct Fragments
    {
        [JsonPropertyName("text")]
        public string Text { get; init; }

        [JsonPropertyName("automod")]
        public FragmentsAutomod Automod { get; init; }
    }
    public readonly struct FragmentsAutomod
    {
        [JsonPropertyName("topics")]
        public Dictionary<string, double> Topics { get; init; }
    }
    public readonly struct MessageSender
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; init; }

        [JsonPropertyName("login")]
        public string Name { get; init; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }

        [JsonPropertyName("chat_color")]
        public string ColorCode { get; init; }
    }
    public readonly struct ContentClassification
    {
        [JsonPropertyName("category")]
        public string Category { get; init; }

        [JsonPropertyName("level")]
        public double Level { get; init; }
    }

}