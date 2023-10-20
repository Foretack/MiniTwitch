using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UserExtensions : BaseResponse<UserExtensions.Extension>
{
    public record Extension(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("version")] string Version,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("can_activate")] bool CanActivate,
        [property: JsonPropertyName("type")] IReadOnlyList<string> Type
    );
}