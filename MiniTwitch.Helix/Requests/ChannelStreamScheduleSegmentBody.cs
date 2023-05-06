using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Models;

namespace MiniTwitch.Helix.Requests;

public readonly struct ChannelStreamScheduleSegmentBody
{
    [JsonPropertyName(QueryParams.StartTime)]
    public required DateTime StartTime { get; init; }
    [JsonPropertyName(QueryParams.Timezone)]
    public required string Timezone { get; init; }
    [JsonPropertyName("duration")]
    public required string Duration { get; init; }
    [JsonPropertyName("is_recurring")]
    public bool IsRecurring { get; init; }
    [JsonPropertyName("category_id")]
    public string CategoryId { get; init; }
    [JsonPropertyName("title")]
    public string Title { get; init; }
}
