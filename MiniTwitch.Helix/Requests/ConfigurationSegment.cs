using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct ConfigurationSegment
{

    public required string ExtensionId { get; init; }

    [JsonConverter(typeof(EnumConverter<ConfigSegmentType>))]
    public required ConfigSegmentType Segment { get; init; }

    [JsonConverter(typeof(OptionalLongConverter))]
    public long? BroadcasterId { get; init; }

    public string Content { get; init; }

    public string Version { get; init; }
}
