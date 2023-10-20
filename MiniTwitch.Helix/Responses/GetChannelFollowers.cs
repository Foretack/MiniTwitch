using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetChannelFollowers : PaginableResponse<GetChannelFollowers.Datum>
{
   [JsonPropertyName("total")]
   public int Total { get; init; }

   public record Datum(
       [property: JsonPropertyName("user_id")] long Id,
       [property: JsonPropertyName("user_login")] string Name,
       [property: JsonPropertyName("user_name")] string DisplayName,
       [property: JsonPropertyName("followed_at")] DateTime FollowedAt
   );
}