using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UserEmotes : PaginableResponse<UserEmotes.Emote>
{
    public record Emote(
        string Id,
        string Name,
        string EmoteType,
        string EmoteSetId,
        [property: JsonConverter(typeof(OptionalLongConverter))] long? OwnerId,
        IReadOnlyList<string> Format,
        IReadOnlyList<string> Scale,
        IReadOnlyList<string> ThemeMode,
        string Template
    );
}
