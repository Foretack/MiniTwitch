using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetBitsLeaderboard : BaseResponse<GetBitsLeaderboard.Datum>
{
   [JsonPropertyName("date_range")]
   public StartEndDate DateRange { get; init; }
   [JsonPropertyName("total")]
   public int Total { get; init; }

   public record Datum(
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("user_login")] string Username,
       [property: JsonPropertyName("user_name")] string DisplayName,
       [property: JsonPropertyName("rank")] int Rank,
       [property: JsonPropertyName("score")] int Score
   );
   public record StartEndDate(
       [property: JsonPropertyName("started_at")] DateTime StartedAt,
       [property: JsonPropertyName("ended_at")] DateTime EndedAt
   );
}