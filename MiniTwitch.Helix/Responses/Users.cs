using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Users : BaseResponse<Users.User>
{
    public record User(
        long Id,
        [property: JsonPropertyName("login")] string Name,
        [property: JsonPropertyName("display_name")] string DisplayName,
        string Type,
        string BroadcasterType,
        string Description,
        string ProfileImageUrl,
        string OfflineImageUrl,
        string? Email,
        DateTime CreatedAt
    );
}