using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Models;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdateChannelStreamScheduleSegmentBody
{
    public DateTime StartTime { get; init; }
    public string Timezone { get; init; }
    public string Duration { get; init; }
    public bool IsRecurring { get; init; }
    public string CategoryId { get; init; }
    public string Title { get; init; }
}
