using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class SnoozedAd : SingleResponse<SnoozedAd.Info>
{
    public record Info(
        [property: JsonPropertyName("snooze_count")] int SnoozeCount,
        [property: JsonPropertyName("snooze_refresh_at")] DateTime SnoozeRefreshAt,
        [property: JsonPropertyName("next_ad_at")] DateTime NextAdAt
    );
}
