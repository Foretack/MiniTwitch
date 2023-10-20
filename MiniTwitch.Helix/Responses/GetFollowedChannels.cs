using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetFollowedChannels : PaginableResponse<GetFollowedChannels.Datum>
{
   [JsonPropertyName("total")]
   public int Total { get; init; }

   public record Datum(
       [property: JsonPropertyName("broadcaster_id")] long Id,
       [property: JsonPropertyName("broadcaster_login")] string Name,
       [property: JsonPropertyName("broadcaster_name")] string DisplayName,
       [property: JsonPropertyName("followed_at")] DateTime FollowedAt
   );
}