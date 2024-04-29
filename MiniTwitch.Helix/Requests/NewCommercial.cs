using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class NewCommercial
{
    [JsonConverter(typeof(LongConverter))]
    public long BroadcasterId { get; }
    public int Length { get; }

    public NewCommercial(long broadcasterId, int length)
    {
        this.BroadcasterId = broadcasterId;
        this.Length = length;
    }
}
