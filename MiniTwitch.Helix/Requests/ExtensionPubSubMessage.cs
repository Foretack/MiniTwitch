namespace MiniTwitch.Helix.Requests;

public readonly struct ExtensionPubSubMessage
{
    public required IEnumerable<string> Target { get; init; }

    public required long BroadcasterId { get; init; }

    public required string Message { get; init; }

    public bool? IsGlobalBroadcast { get; init; }
}
