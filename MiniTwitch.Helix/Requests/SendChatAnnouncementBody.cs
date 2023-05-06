using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct SendChatAnnouncementBody : IJsonObject
{
    public required string Message { get; init; }
    public AnnouncementColor Color { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        message = Message,
        color = Color.ToString(),
    };
}
