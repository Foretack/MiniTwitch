using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public readonly struct ExtensionConfigurationSegment
{

    public required string ExtensionId { get; init; }

    [JsonConverter(typeof(EnumToString<ConfigSegmentType, SnakeCase>))]
    public required ConfigSegmentType Segment { get; init; }

    [JsonConverter(typeof(LongToString))]
    public long? BroadcasterId { get; init; }

    public string Content { get; init; }

    public string Version { get; init; }
}
