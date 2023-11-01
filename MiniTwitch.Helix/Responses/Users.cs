using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Users : BaseResponse<Users.User>
{
    public record User(
        [property: JsonPropertyName("id")] long Id,
        [property: JsonPropertyName("login")] string Name,
        [property: JsonPropertyName("display_name")] string DisplayName,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("broadcaster_type")] string BroadcasterType,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("profile_image_url")] string ProfileImageUrl,
        [property: JsonPropertyName("offline_image_url")] string OfflineImageUrl,
        [property: JsonPropertyName("email")] string? Email,
        [property: JsonPropertyName("created_at")] DateTime CreatedAt
    );
}

public class User : SingleResponse<Users.User>
{
}