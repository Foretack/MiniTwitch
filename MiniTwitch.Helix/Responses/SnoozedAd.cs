using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class SnoozedAd : BaseResponse<SnoozedAd.Info>
{
    public record Info(
        int SnoozeCount,
        DateTime SnoozeRefreshAt,
        DateTime NextAdAt
    );
}
