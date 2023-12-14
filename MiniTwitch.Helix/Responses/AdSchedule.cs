using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class AdSchedule : BaseResponse<AdSchedule.Ad>
{
    public record Ad(
        [property: JsonPropertyName("next_ad_at")] DateTime? NextAdAt,
        [property: JsonPropertyName("last_ad_at")] DateTime? LastAdAt,
        [property: JsonPropertyName("duration")] int Duration,
        [property: JsonPropertyName("preroll_free_time")] int PrerollFreeTime,
        [property: JsonPropertyName("snooze_count")] int SnoozeCount,
        [property: JsonPropertyName("snooze_refresh_at")] DateTime? SnoozeRefreshAt
    );
}
