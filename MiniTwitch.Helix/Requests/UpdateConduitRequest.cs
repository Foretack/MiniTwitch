using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public class UpdateConduitRequest
{
    [property: JsonPropertyName("id")]
    public string ShardId { get; }

    public ShardTransport Transport { get; }

    public class ShardTransport
    {
        public string Method { get; }

        public string? SessionId { get; }

        [property: JsonPropertyName("callback")]
        public string? CallbackUrl { get; }

        public string? Secret { get; }

        public ShardTransport(
            string method,
            string? sessionId = null,
            string? callbackUrl = null,
            string? secret = null
        )
        {
            this.Method = method;
            this.SessionId = sessionId;
            this.CallbackUrl = callbackUrl;
            this.Secret = secret;
        }
    }

    public UpdateConduitRequest(string shardId, ShardTransport transport)
    {
        this.ShardId = shardId;
        this.Transport = transport;
    }
};
