using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class BannedUser : BaseResponse<BannedUser.User>
{
    public record User(
        [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
        [property: JsonPropertyName("moderator_id")] long ModeratorId,
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("created_at")] DateTime CreatedAt,
        [property: JsonPropertyName("end_time")] DateTime? EndTime
    );
}