using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class Warning
{
    [JsonConverter(typeof(LongConverter))]
    public long UserId { get; }
    public string Reason { get; }

    public Warning(long userId, string reason)
    {
        this.UserId = userId;
        this.Reason = reason;
    }
}
