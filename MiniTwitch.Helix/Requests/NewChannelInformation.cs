using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Requests;

public readonly struct NewChannelInformation
{
    public string GameId { get; init; }
    public string BroadcasterLanguage { get; init; }
    public string Title { get; init; }
    [JsonConverter(typeof(TimeSpanToSeconds))]
    public TimeSpan? Delay { get; init; }
    public IEnumerable<string> Tags { get; init; }
    [JsonPropertyName("content_classification_labels")]
    public IEnumerable<ContentClassificationLabel> ClassificationLabels { get; init; }
    public bool? IsBrandedContent { get; init; }
}
