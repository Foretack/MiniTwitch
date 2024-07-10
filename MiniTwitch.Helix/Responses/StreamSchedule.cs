using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class StreamSchedule : BaseResponse
{
    [property: JsonPropertyName("data")]
    public ScheduleData Data { get; init; }

    public record Category(
        string Id,
        string Name
    );

    public record ScheduleData(
        IReadOnlyList<Segment> Segments,
        long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        Vacation Vacation
    );

    public record Segment(
        string Id,
        DateTime StartTime,
        DateTime EndTime,
        string Title,
        DateTime? CanceledUntil,
        Category Category,
        bool IsRecurring
    );

    public record Vacation(
        DateTime StartTime,
        DateTime EndTime
    );
}