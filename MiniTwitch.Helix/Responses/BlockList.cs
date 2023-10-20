using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class BlockList : PaginableResponse<BlockList.User>
{
   public record User(
       [property: JsonPropertyName("user_id")] long UserId,
       [property: JsonPropertyName("user_login")] string Username,
       [property: JsonPropertyName("display_name")] string UserDisplayName
   );
}