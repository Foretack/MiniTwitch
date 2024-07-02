using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class WarnInfo : BaseResponse<WarnInfo.Info>
{
    public record Info(
        long BroadcasterId,
        long UserId,
        long ModeratorId,
        string Reason
    );
}
