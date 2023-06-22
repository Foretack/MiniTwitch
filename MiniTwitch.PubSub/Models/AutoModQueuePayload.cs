using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Models;

public readonly record struct AutoModQueuePayload(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("data")] AutoModQueueMessage Data = default
);

public readonly record struct Automod(
        [property: JsonPropertyName("topics")] FragmentTopics Topics = default
    );

public readonly record struct Content(
    [property: JsonPropertyName("text")] string Text = ""
)
{
    [property: JsonPropertyName("fragments")]
    private readonly IReadOnlyList<Fragment> _fragments { get; init; } = default!;
    public IReadOnlyList<Fragment> Fragments => _fragments ?? new List<Fragment>();
};

public readonly record struct ContentClassification(
    [property: JsonPropertyName("category")] string Category = "",
    [property: JsonPropertyName("level")] int Level = default
);

public readonly record struct AutoModQueueMessage(
    [property: JsonPropertyName("message")] Message Message = default,
    [property: JsonPropertyName("content_classification")] ContentClassification ContentClassification = default,
    [property: JsonPropertyName("status")] string Status = "",
    [property: JsonPropertyName("reason_code")] string ReasonCode = "",
    [property: JsonPropertyName("resolver_id")] long ResolverId = default,
    [property: JsonPropertyName("resolver_login")] string ResolverUsername = ""
);

public readonly record struct Fragment(
    [property: JsonPropertyName("text")] string Text = "",
    [property: JsonPropertyName("automod")] Automod Automod = default
);

public readonly record struct Message(
    [property: JsonPropertyName("id")] string Id = "",
    [property: JsonPropertyName("content")] Content Content = default,
    [property: JsonPropertyName("sender")] Sender Sender = default,
    [property: JsonPropertyName("sent_at")] DateTime SentAt = default
);

public readonly record struct Sender(
    [property: JsonPropertyName("user_id")] long UserId = default,
    [property: JsonPropertyName("login")] string Name = "",
    [property: JsonPropertyName("display_name")] string DisplayName = "",
    [property: JsonPropertyName("chat_color")] string ColorCode = ""
);

public readonly record struct FragmentTopics(
    [property: JsonPropertyName("swearing")] int Swearing = default
);