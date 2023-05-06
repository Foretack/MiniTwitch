using MiniTwitch.Helix.Internal.Interfaces;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Requests;

public readonly struct ModifyChannelInformationBody : IJsonObject
{
    public string GameId { get; init; }
    public string BroadcasterLanguage { get; init; }
    public string Title { get; init; }
    public TimeSpan Delay { get; init; }
    public IEnumerable<string> Tags { get; init; }
    public IEnumerable<ContentClassificationLabel> ClassificationLabels { get; init; }
    public bool IsBrandedContent { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        game_id = GameId,
        broadcaster_language = BroadcasterLanguage,
        title = Title,
        delay = (int)Delay.TotalSeconds > 900 ? 900 : (int)Delay.TotalSeconds,
        tags = Tags.ToArray(),
        content_classification_labels = ClassificationLabels.ToArray(),
        is_branded_content = IsBrandedContent
    };
}
