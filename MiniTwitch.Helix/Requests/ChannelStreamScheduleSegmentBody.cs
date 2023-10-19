namespace MiniTwitch.Helix.Requests;

public readonly struct ChannelStreamScheduleSegmentBody
{
    public required DateTime StartTime { get; init; }
    public required string Timezone { get; init; }
    public required string Duration { get; init; }
    public bool IsRecurring { get; init; }
    public string CategoryId { get; init; }
    public string Title { get; init; }
}
