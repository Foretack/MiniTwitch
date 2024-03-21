using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class BitsLeaderboard : BaseResponse<BitsLeaderboard.User>
{
    [JsonPropertyName("date_range")]
    public StartEndDate DateRange { get; init; }
    [JsonPropertyName("total")]
    public int Total { get; init; }

    public record User(
       long UserId,
        [property: JsonPropertyName("user_login")] string Username,
        [property: JsonPropertyName("user_name")] string DisplayName,
         int Rank,
         int Score
    );
    public record StartEndDate(
         DateTime StartedAt,
         DateTime EndedAt
    );
}