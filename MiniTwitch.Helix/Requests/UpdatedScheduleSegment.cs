using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdatedScheduleSegment
{
    public DateTime? StartTime { get; init; }
    public string Timezone { get; init; }
    [JsonConverter(typeof(IntToString))]
    public int DurationHours { get; init; }
    public bool? IsRecurring { get; init; }
    public string CategoryId { get; init; }
    public string Title { get; init; }
}
