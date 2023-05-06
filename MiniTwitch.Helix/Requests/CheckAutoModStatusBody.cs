using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct CheckAutoModStatusBody : IJsonObject
{
    public required IEnumerable<Message> Data { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        data = Data
    };

    public record Message(
        [property: JsonPropertyName("msg_id")] string MessageId,
        [property: JsonPropertyName("msg_text")] string MessageText
    );
}
