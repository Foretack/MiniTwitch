namespace MiniTwitch.Helix.Requests;

public readonly struct NewSubscription
{
    public required string Type { get; init; }
    public required string Version { get; init; }
    public required EventsubTransport Transport { get; init; }

    public readonly struct EventsubTransport
    {
        public required string Method { get; init; }
        public string Callback { get; init; }
        public string Secret { get; init; }
        public string SessionId { get; init; }
    }
}
