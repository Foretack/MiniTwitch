using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct PredictionToEnd
{
    [JsonConverter(typeof(LongToString))]
    public required long BroadcasterId { get; init; }
    public required string Id { get; init; }
    public required string Status { get; init; }
    public string WinningOutcomeId { get; init; }
}
