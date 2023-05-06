using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct CreateEventSubSubscriptionBody : IJsonObject
{
    public required string Type { get; init; }
    public required string Version { get; init; }
    public required EventsubTransport Transport { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        type = Type,
        version = Version,
        transport = new
        {
            method = Transport.Method,
            secret = Transport.Secret,
            session_id = Transport.SessionId,
        }
    };

    public readonly struct EventsubTransport
    {
        public required string Method { get; init; }
        public string Callback { get; init; }
        public string Secret { get; init; }
        public string SessionId { get; init; }
    }
}
