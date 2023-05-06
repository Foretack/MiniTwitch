using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct SendExtensionPubSubMessageBody : IJsonObject
{
    public required IEnumerable<string> Target { get; init; }
    public required long BroadcasterId { get; init; }
    public required string Message { get; init; }
    public bool? IsGlobalBroadcast { get; init; }

    object IJsonObject.ToJsonObject() => new 
    {
        target = Target,
        broadcaster_id = BroadcasterId,
        message = Message,
        is_global_broadcast = IsGlobalBroadcast
    };
}
