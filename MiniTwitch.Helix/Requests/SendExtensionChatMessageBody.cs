using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct SendExtensionChatMessageBody : IJsonObject
{
    public required string Text { get; init; }
    public required string ExtensionId { get; init; }
    public required string ExtensionVersion { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        text = Text,
        extension_id = ExtensionId,
        extension_version = ExtensionVersion,
    };
}
