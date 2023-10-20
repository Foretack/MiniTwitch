using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Responses;

public class AdSnoozeResponse
{
    public record SnoozeResult(
        [property: JsonPropertyName("snooze_count")] int SnoozeCount,
        [property: JsonPropertyName("snooze_refresh_at")] DateTime SnoozeRefreshAt,
        [property: JsonPropertyName("next_ad_at")] DateTime NextAdAt
    );
}
