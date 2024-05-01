using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class ConfigurationSegment
{

    public string ExtensionId { get; }

    [JsonConverter(typeof(EnumConverter<ConfigSegmentType>))]
    public ConfigSegmentType Segment { get; }

    [JsonConverter(typeof(OptionalLongConverter))]
    public long? BroadcasterId { get; }

    public string? Content { get; }

    public string? Version { get; }

    public ConfigurationSegment(
        string extensionId, 
        ConfigSegmentType segment, 
        long? broadcasterId = null, 
        string? content = null, 
        string? version = null
    )
    {
        this.ExtensionId = extensionId;
        this.Segment = segment;
        this.BroadcasterId = broadcasterId;
        this.Content = content!;
        this.Version = version!;
    }
}
