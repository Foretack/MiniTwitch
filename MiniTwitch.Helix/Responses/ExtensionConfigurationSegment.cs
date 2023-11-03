using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionConfigurationSegment : BaseResponse<ExtensionConfigurationSegment.ConfigSegment>
{
    public record ConfigSegment(
        [property: JsonPropertyName("segment")] string Segment,
        [property: JsonPropertyName("content")] string Content,
        [property: JsonPropertyName("version")] string Version
    );
}