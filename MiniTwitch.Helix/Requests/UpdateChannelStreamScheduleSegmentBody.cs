using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Models;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdateChannelStreamScheduleSegmentBody
{
    [JsonPropertyName(QueryParams.StartTime)]
    public DateTime StartTime { get; init; }
    [JsonPropertyName(QueryParams.Timezone)]
    public string Timezone { get; init; }
    [JsonPropertyName("duration")]
    public string Duration { get; init; }
    [JsonPropertyName("is_recurring")]
    public bool IsRecurring { get; init; }
    [JsonPropertyName("category_id")]
    public string CategoryId { get; init; }
    [JsonPropertyName("title")]
    public string Title { get; init; }
}
