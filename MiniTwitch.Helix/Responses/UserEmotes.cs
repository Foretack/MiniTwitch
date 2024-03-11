using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UserEmotes : PaginableResponse<UserEmotes.Emote>
{
    public record Emote(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("emote_type")] string EmoteType,
        [property: JsonPropertyName("emote_set_id")] string EmoteSetId,
        [property: JsonPropertyName("owner_id")] long OwnerId,
        [property: JsonPropertyName("format")] IReadOnlyList<string> Format,
        [property: JsonPropertyName("scale")] IReadOnlyList<string> Scale,
        [property: JsonPropertyName("theme_mode")] IReadOnlyList<string> ThemeMode,
        [property: JsonPropertyName("template")] string Template,
    );
}
