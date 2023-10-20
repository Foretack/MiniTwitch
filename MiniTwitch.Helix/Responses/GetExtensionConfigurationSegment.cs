using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetExtensionConfigurationSegment : BaseResponse<GetExtensionConfigurationSegment.Datum>
{
   public record Datum(
       [property: JsonPropertyName("segment")] string Segment,
       [property: JsonPropertyName("content")] string Content,
       [property: JsonPropertyName("version")] string Version
   );
}