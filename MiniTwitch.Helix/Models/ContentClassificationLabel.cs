using MiniTwitch.Helix.Enums;

namespace MiniTwitch.Helix.Models;

public class ContentClassificationLabel
{
    public ContentLabelId Id { get; }
    public bool IsEnabled { get; }

    public ContentClassificationLabel(ContentLabelId id, bool isEnabled)
    {
        this.Id = id;
        this.IsEnabled = isEnabled;
    }
}
