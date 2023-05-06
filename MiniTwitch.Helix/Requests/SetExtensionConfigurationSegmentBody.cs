using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct SetExtensionConfigurationSegmentBody : IJsonObject
{
    public required string ExtensionId { get; init; }
    public required string Segment {  get; init; }
    public long? BroadcasterId { get; init; }
    public string Content { get; init; }
    public string Version { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        extension_id = ExtensionId,
        segment = Segment,
        broadcaster_id = BroadcasterId,
        content = Content,
        version = Version
    };
}
