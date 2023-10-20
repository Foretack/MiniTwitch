using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UserChatColor : BaseResponse<UserChatColor.User>
{
    public record User(
        [property: JsonPropertyName("user_id")] long Id,
        [property: JsonPropertyName("user_name")] string DisplayName,
        [property: JsonPropertyName("user_login")] string Name,
        [property: JsonPropertyName("color")] string Color
    );
}