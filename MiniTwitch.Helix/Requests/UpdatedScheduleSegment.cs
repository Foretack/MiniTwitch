namespace MiniTwitch.Helix.Requests;

public readonly struct UpdatedScheduleSegment
{
    public DateTime? StartTime { get; init; }
    public string Timezone { get; init; }
    public string Duration { get; init; }
    public bool? IsRecurring { get; init; }
    public string CategoryId { get; init; }
    public string Title { get; init; }
}
