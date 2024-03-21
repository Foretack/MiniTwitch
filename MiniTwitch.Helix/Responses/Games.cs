using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Games : PaginableResponse<Games.Game>
{
    public record Game(
        string Id,
        string Name,
        string BoxArtUrl,
        string IgdbId
    );
}