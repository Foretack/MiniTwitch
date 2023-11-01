using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class AutoModStatus : BaseResponse<AutoModStatus.Message>
{
    public record Message(
        [property: JsonPropertyName("msg_id")] string MessageId,
        [property: JsonPropertyName("is_permitted")] bool IsPermitted
    );
}