using System.Text.Json;
using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Responses;

[JsonConverter(typeof(ConduitTransportConverter))]
public abstract record ConduitTransport()
{
    public sealed record WebSocket(string SessionId, DateTime ConnectedAt, DateTime DisconnectedAt) : ConduitTransport();
    public sealed record Webhook(string Callback) : ConduitTransport();
}
