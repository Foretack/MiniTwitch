using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetChatters : BaseResponse<GetChatters.Datum>, IPaginable
{
   [JsonPropertyName("total")]
   public int Total { get; init; }
   [JsonPropertyName("pagination")]
   public Pagination Pagination { get; init; }

   public record Datum(
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("user_login")] string Username,
       [property: JsonPropertyName("user_name")] string UserDisplayName
   );
}