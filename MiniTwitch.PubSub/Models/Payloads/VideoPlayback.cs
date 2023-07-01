using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models.Payloads;

public readonly struct VideoPlayback : IStreamUp, IViewerCountUpdate, ICommercialBreak,
    IStreamDown
{
    [JsonPropertyName("type")]
    public string Type { get; init; }
    [JsonPropertyName("server_time")]
    public double ServerTime { get; init; }
    [JsonPropertyName("play_delay")]
    public int PlayDelay { get; init; }
    [JsonPropertyName("viewers")]
    public int Viewers { get; init; }
    [JsonPropertyName("length")]
    public int Length { get; init; }
    [JsonPropertyName("scheduled")]
    public bool Scheduled { get; init; }
}
