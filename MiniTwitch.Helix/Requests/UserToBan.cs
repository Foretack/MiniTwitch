using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class UserToBan
{
    [JsonConverter(typeof(LongConverter))]
    public long UserId { get; }
    [JsonConverter(typeof(TimeSpanToSeconds))]
    public TimeSpan? Duration { get; }
    public string? Reason { get; }

    public UserToBan(long userId, TimeSpan? duration = null, string? reason = null)
    {
        this.UserId = userId;
        this.Duration = duration;
        this.Reason = reason;
    }
}
