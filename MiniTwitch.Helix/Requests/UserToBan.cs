using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct UserToBan
{
    [JsonConverter(typeof(LongConverter))]
    public required long UserId { get; init; }
    [JsonConverter(typeof(TimeSpanToSeconds))]
    public TimeSpan? Duration { get; init; }
    public string Reason { get; init; }
}
