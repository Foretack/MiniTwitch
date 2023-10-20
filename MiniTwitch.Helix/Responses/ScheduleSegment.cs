using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Responses;

public class ScheduleSegment
{
    [property: JsonPropertyName("data")]
    public ScheduleData Data { get; init; }

    public record Category(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name
    );

    public record ScheduleData(
        [property: JsonPropertyName("segments")] IReadOnlyList<Segment> Segments,
        [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        [property: JsonPropertyName("vacation")] Vacation Vacation
    );

    public record Segment(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("start_time")] DateTime StartTime,
        [property: JsonPropertyName("end_time")] DateTime EndTime,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("canceled_until")] DateTime? CanceledUntil,
        [property: JsonPropertyName("category")] Category Category,
        [property: JsonPropertyName("is_recurring")] bool IsRecurring
    );

    public record Vacation(
        [property: JsonPropertyName("start_time")] DateTime StartTime,
        [property: JsonPropertyName("end_time")] DateTime EndTime
    );
}