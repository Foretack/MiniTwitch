using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public class MessageToCheck
{
    public IEnumerable<Message> Data { get; }

    public record Message(
        [property: JsonPropertyName("msg_id")] string MessageId,
        [property: JsonPropertyName("msg_text")] string MessageText
    );

    public MessageToCheck(IEnumerable<Message> data)
    {
        this.Data = data;
    }
}
