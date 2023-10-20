using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class UpdateDropsEntitlements : BaseResponse<UpdateDropsEntitlements.Datum>
{
   public record Datum(
       [property: JsonPropertyName("status")] string Status,
       [property: JsonPropertyName("ids")] IReadOnlyList<string> Ids
   );
}