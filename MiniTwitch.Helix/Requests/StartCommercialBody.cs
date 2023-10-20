using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct StartCommercialBody
{
    [JsonIgnore]
    public required long BroadcasterId { get; init; }
    [JsonInclude]
    private string broadcaster_id => this.BroadcasterId.ToString();
    public required int Length { get; init; }
}
