using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct MessageToCheck
{
    public required IEnumerable<Message> Data { get; init; }

    public record Message(
        [property: JsonPropertyName("msg_id")] string MessageId,
        [property: JsonPropertyName("msg_text")] string MessageText
    );
}
