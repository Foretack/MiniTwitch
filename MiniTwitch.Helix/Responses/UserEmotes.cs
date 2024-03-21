using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UserEmotes : PaginableResponse<UserEmotes.Emote>
{
    public record Emote(
        string Id,
        string Name,
        string EmoteType,
        string EmoteSetId,
        string OwnerId,
        IReadOnlyList<string> Format,
        IReadOnlyList<string> Scale,
        IReadOnlyList<string> ThemeMode,
        string Template
    );
}
