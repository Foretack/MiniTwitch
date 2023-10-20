using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class CheckAutoModStatus : BaseResponse<CheckAutoModStatus.Datum>
{
   public record Datum(
       [property: JsonPropertyName("msg_id")] string MessageId,
       [property: JsonPropertyName("is_permitted")] bool IsPermitted
   );
}