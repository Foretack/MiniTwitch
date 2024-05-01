namespace MiniTwitch.Helix.Requests;

public class NewSubscription
{
    public string Type { get; }
    public string Version { get; }
    public EventsubTransport Transport { get; }

    public readonly struct EventsubTransport
    {
        public string Method { get; }
        public string? Callback { get; }
        public string? Secret { get; }
        public string? SessionId { get; }

        public EventsubTransport(
            string method,
            string? callback = null,
            string? secret = null,
            string? sessionId = null
        )
        {
            this.Method = method;
            this.Callback = callback;
            this.Secret = secret;
            this.SessionId = sessionId;
        }
    }

    public NewSubscription(string type, string version, EventsubTransport transport)
    {
        this.Type = type;
        this.Version = version;
        this.Transport = transport;
    }
}
