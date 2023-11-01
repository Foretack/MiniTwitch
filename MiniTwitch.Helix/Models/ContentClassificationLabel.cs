using MiniTwitch.Helix.Enums;

namespace MiniTwitch.Helix.Models;

public readonly struct ContentClassificationLabel
{
    public required ContentLabelid Id { get; init; }
    public required bool IsEnabled { get; init; }
}
