using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class Announcement
{
    public string Message { get; }
    [JsonConverter(typeof(EnumConverter<AnnouncementColor?>))]
    public AnnouncementColor? Color { get; }

    public Announcement(string message, AnnouncementColor? color = null)
    {
        this.Message = message;
        this.Color = color;
    }
}
