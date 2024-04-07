using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Responses;

[JsonConverter(typeof(ConduitTransportConverter))]
public abstract record ConduitTransport()
{
    public string Method { get; }

    public sealed record WebSocket(string SessionId, DateTime ConnectedAt, DateTime DisconnectedAt) : ConduitTransport();
    public sealed record Webhook(string Callback) : ConduitTransport();
}

public class ConduitTransportConverter : JsonConverter<ConduitTransport>
{
    public override void Write(Utf8JsonWriter writer, ConduitTransport value, JsonSerializerOptions options)
        => throw new NotImplementedException("This converter is read-only");

    public override ConduitTransport? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var root = JsonDocument.ParseValue(ref reader).RootElement;

        if (root.TryGetProperty("method", out var method))
        {
            return method.GetString() switch
            {
                "webhook" => root.Deserialize<ConduitTransport.Webhook>(),
                "websocket" => root.Deserialize<ConduitTransport.WebSocket>(),
                _ => throw new JsonException($"Unknown method: {method.GetString()}")
            };
        }

        return null;
    }
}
