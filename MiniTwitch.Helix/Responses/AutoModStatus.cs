using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class AutoModStatus : BaseResponse<AutoModStatus.Message>
{
   public record Message(
       [property: JsonPropertyName("msg_id")] string MessageId,
       [property: JsonPropertyName("is_permitted")] bool IsPermitted
   );
}