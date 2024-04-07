using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdateConduitRequest
{
    [property: JsonPropertyName("id")]
    public required string ShardId { get; init; }

    public required ShardTransport Transport { get; init; }

    public struct ShardTransport
    {
        public required string Method { get; init; }

        public string SessionId { get; init; }

        public string CallbackUrl { get; init; }

        public string Secret { get; init; }
    }
};
