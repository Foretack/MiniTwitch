using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Models;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Requests;

public readonly struct NewChannelInformation
{
    [JsonPropertyName(QueryParams.GameId)]
    public string GameId { get; init; }
    public string BroadcasterLanguage { get; init; }
    public string Title { get; init; }
    [JsonIgnore]
    public TimeSpan? Delay { get; init; }
    [JsonInclude, JsonPropertyName("delay")]
    private int? Delay_ => (int?)this.Delay?.TotalSeconds;
    public IEnumerable<string> Tags { get; init; }
    [JsonPropertyName("content_classification_labels")]
    public IEnumerable<ContentClassificationLabel> ClassificationLabels { get; init; }
    public bool? IsBrandedContent { get; init; }
}
