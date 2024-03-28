using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct Announcement
{
    public required string Message { get; init; }
    [JsonConverter(typeof(EnumConverter<AnnouncementColor?, SnakeCase>))]
    public AnnouncementColor? Color { get; init; }
}
