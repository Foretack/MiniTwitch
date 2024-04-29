using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class NewScheduleSegment
{
    public DateTime StartTime { get; }
    public string Timezone { get; }
    [JsonConverter(typeof(IntConverter))]
    public int DurationHours { get; }
    public bool? IsRecurring { get; }
    public string? CategoryId { get; }
    public string? Title { get; }

    public NewScheduleSegment(
        DateTime startTime,
        string timeZone,
        int durationHours,
        bool? isRecurring = null,
        string? categoryId = null,
        string? title = null
    )
    {
        this.StartTime = startTime;
        this.Timezone = timeZone;
        this.DurationHours = durationHours;
        this.IsRecurring = isRecurring;
        this.CategoryId = categoryId;
        this.Title = title;
    }
}
