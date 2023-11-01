using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ContentClassificationLabels : BaseResponse<ContentClassificationLabels.Label>
{
    public record Label(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("name")] string Name
    );
}