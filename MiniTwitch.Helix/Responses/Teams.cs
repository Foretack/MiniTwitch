using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Teams : BaseResponse<Teams.Team>
{
    public record Team(
        IReadOnlyList<User> Users,
        string? BackgroundImageUrl,
        string? Banner,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string Info,
        string ThumbnailUrl,
        string TeamName,
        string TeamDisplayName,
        string Id
    );

    public record User(
        long UserId,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
        [property: JsonPropertyName("user_login")] string Username
    );
}