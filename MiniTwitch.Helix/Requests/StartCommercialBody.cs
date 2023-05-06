using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct StartCommercialBody : IJsonObject
{
    public required long BroadcasterId { get; init; }
    public required int Length { get; init; }


    object IJsonObject.ToJsonObject()
    {
        return new
        {
            broadcaster_id = BroadcasterId.ToString(),
            length = Length > 180 ? 180 : Length,
        };
    }
}
