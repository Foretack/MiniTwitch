using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct NewScheduleSegment
{
    public required DateTime StartTime { get; init; }
    public required string Timezone { get; init; }
    [JsonConverter(typeof(IntConverter))]
    public required int DurationHours { get; init; }
    public bool? IsRecurring { get; init; }
    public string CategoryId { get; init; }
    public string Title { get; init; }
}
