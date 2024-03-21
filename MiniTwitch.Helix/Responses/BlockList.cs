using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class BlockList : PaginableResponse<BlockList.User>
{
    public record User(
       long UserId,
        [property: JsonPropertyName("user_login")] string Username,
        [property: JsonPropertyName("display_name")] string UserDisplayName
    );
}