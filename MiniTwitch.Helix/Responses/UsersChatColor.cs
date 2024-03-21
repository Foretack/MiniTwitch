using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UsersChatColor : BaseResponse<UsersChatColor.ColorInfo>
{
    public record ColorInfo(
        long Id,
        [property: JsonPropertyName("user_name")] string DisplayName,
        [property: JsonPropertyName("user_login")] string Name,
        string Color
    );
}