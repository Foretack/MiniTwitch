using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct CreateEventSubSubscriptionBody
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
