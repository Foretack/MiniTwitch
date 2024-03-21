using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class AdSchedule : BaseResponse<AdSchedule.Ad>
{
    public record Ad(
         DateTime? NextAdAt,
         DateTime? LastAdAt,
         int Duration,
         int PrerollFreeTime,
         int SnoozeCount,
         DateTime? SnoozeRefreshAt
    );
}
