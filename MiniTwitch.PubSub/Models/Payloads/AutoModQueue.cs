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

    public readonly record struct PayloadData(
        [property: JsonPropertyName("message")] PayloadMessage Message,
        [property: JsonPropertyName("content_classification")] ContentClassification ContentClassification,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("reason_code")] string ReasonCode,
        [property: JsonPropertyName("resolver_id")] long ResolverId,
        [property: JsonPropertyName("resolver_login")] string ResolverName
    );
    public readonly record struct PayloadMessage(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("content")] MessageContent Content,
        [property: JsonPropertyName("sender")] MessageSender Sender,
        [property: JsonPropertyName("sent_at")] DateTime SentAt
    );
    public readonly record struct MessageContent(
        [property: JsonPropertyName("text")] string Text,
        [property: JsonPropertyName("fragments")] Fragments[] Fragments
    );
    public readonly record struct Fragments(
        [property: JsonPropertyName("text")] string Text,
        [property: JsonPropertyName("automod")] FragmentsAutomod Automod
    );
    public readonly record struct FragmentsAutomod(
        [property: JsonPropertyName("topics")] Dictionary<string, double> Topics
    );
    public readonly record struct MessageSender(
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("login")] string Name,
        [property: JsonPropertyName("display_name")] string DisplayName,
        [property: JsonPropertyName("chat_color")] string ColorCode
    );
    public readonly record struct ContentClassification(
        [property: JsonPropertyName("category")] string Category,
        [property: JsonPropertyName("level")] double Level
    );
}