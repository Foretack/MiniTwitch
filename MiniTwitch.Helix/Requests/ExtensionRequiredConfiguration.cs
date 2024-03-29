﻿namespace MiniTwitch.Helix.Requests;

public readonly struct ExtensionRequiredConfiguration
{
    public required string ExtensionId { get; init; }
    public required string ExtensionVersion { get; init; }
    public required string RequiredConfiguration { get; init; }
}
