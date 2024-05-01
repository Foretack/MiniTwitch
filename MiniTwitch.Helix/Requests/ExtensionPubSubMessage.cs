using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct ExtensionPubSubMessage
{
    public IEnumerable<string> Target { get; }

    [JsonConverter(typeof(LongConverter))]
    public long BroadcasterId { get; }

    public string Message { get; }

    public bool? IsGlobalBroadcast { get; }

    public ExtensionPubSubMessage(IEnumerable<string> target, long broadcasterId, string message, bool? isGlobalBroadcast)
    {
        this.Target = target;
        this.BroadcasterId = broadcasterId;
        this.Message = message;
        this.IsGlobalBroadcast = isGlobalBroadcast;
    }
}
