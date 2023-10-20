using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetUserChatColor : BaseResponse<GetUserChatColor.User>
{
   public record User(
       [property: JsonPropertyName("user_id")] long Id,
       [property: JsonPropertyName("user_name")] string DisplayName,
       [property: JsonPropertyName("user_login")] string Name,
       [property: JsonPropertyName("color")] string Color
   );
}