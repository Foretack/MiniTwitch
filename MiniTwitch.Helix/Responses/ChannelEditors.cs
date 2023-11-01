using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChannelEditors : BaseResponse<ChannelEditors.Editor>
{
    public record Editor(
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
        [property: JsonPropertyName("created_at")] DateTime CreatedAt
    );
}