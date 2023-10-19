﻿namespace MiniTwitch.Helix.Requests;

public readonly struct SendExtensionChatMessageBody
{
    public required string Text { get; init; }
    public required string ExtensionId { get; init; }
    public required string ExtensionVersion { get; init; }
}
