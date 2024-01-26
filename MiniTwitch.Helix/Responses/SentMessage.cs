using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class SentMessage : BaseResponse<SentMessage.Info>
{
    public record Info(
        [property: JsonPropertyName("message_id")] string MessageId,
        [property: JsonPropertyName("is_sent")] bool IsSent,
        [property: JsonPropertyName("drop_reason")] DropInfo[] DropReason
    );
    
    public record DropInfo(
        [property: JsonPropertyName("code")] string Code,
        [property: JsonPropertyName("message")] bool Message
    );
}