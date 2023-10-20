using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class ContentClassificationLabels : BaseResponse<ContentClassificationLabels.Label>
{
   public record Label(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("description")] string Description,
       [property: JsonPropertyName("name")] string Name
   );
}