using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class BannedUser : BaseResponse<BannedUser.User>
{
    public record User(
         long BroadcasterId,
         long ModeratorId,
       long UserId,
         DateTime CreatedAt,
         DateTime? EndTime
    );
}