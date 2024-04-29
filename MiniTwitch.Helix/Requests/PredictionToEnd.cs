using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class PredictionToEnd
{
    [JsonConverter(typeof(LongConverter))]
    public long BroadcasterId { get; }
    public string Id { get; }
    public string Status { get; }
    public string? WinningOutcomeId { get; }

    public PredictionToEnd(long broadcasterId, string id, string status, string? winningOutcomeId = null)
    {
        this.BroadcasterId = broadcasterId;
        this.Id = id;
        this.Status = status;
        this.WinningOutcomeId = winningOutcomeId;
    }
}
