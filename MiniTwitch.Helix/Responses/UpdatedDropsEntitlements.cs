using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class UpdatedDropsEntitlements : BaseResponse<UpdatedDropsEntitlements.Info>
{
   public record Info(
       [property: JsonPropertyName("status")] string Status,
       [property: JsonPropertyName("ids")] IReadOnlyList<string> Ids
   );
}