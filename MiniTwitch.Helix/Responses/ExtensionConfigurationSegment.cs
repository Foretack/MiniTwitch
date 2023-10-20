using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class ExtensionConfigurationSegment : SingleResponse<ExtensionConfigurationSegment.ConfigSegment>
{
   public record ConfigSegment(
       [property: JsonPropertyName("segment")] string Segment,
       [property: JsonPropertyName("content")] string Content,
       [property: JsonPropertyName("version")] string Version
   );
}