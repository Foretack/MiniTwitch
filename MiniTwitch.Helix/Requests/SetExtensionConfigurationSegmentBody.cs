namespace MiniTwitch.Helix.Requests;

public readonly struct SetExtensionConfigurationSegmentBody
{

    public required string ExtensionId { get; init; }

    public required string Segment {  get; init; }

    public long? BroadcasterId { get; init; }

    public string Content { get; init; }

    public string Version { get; init; }
}
