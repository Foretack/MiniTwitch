using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Requests;

public class NewChannelInformation
{
    public string? GameId { get; }
    public string? BroadcasterLanguage { get; }
    public string? Title { get; }
    [JsonConverter(typeof(TimeSpanToSeconds))]
    public TimeSpan? Delay { get; }
    public IEnumerable<string>? Tags { get; }
    [JsonPropertyName("content_classification_labels")]
    public IEnumerable<ContentClassificationLabel>? ClassificationLabels { get; }
    public bool? IsBrandedContent { get; }

    public NewChannelInformation(
        string? gameId = null,
        string? broadcasterLanguage = null,
        string? title = null,
        TimeSpan? delay = null,
        IEnumerable<string>? tags = null,
        IEnumerable<ContentClassificationLabel>? classificationLabels = null,
        bool? isBrandedContent = null
    )
    {
        this.GameId = gameId;
        this.BroadcasterLanguage = broadcasterLanguage;
        this.Title = title;
        this.Delay = delay;
        this.Tags = tags;
        this.ClassificationLabels = classificationLabels;
        this.IsBrandedContent = isBrandedContent;
    }
}
