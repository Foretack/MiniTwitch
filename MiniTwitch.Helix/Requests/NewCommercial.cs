using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct NewCommercial
{
    [JsonConverter(typeof(LongToString))]
    public required long BroadcasterId { get; init; }
    public required int Length { get; init; }
}
