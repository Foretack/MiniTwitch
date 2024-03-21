using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class GameAnalytics : PaginableResponse<GameAnalytics.Analytics>
{
    public record Analytics(
        string GameId,
        string Url,
        string Type,
        DateRange DateRange
    );
    public record DateRange(
        DateTime StartedAt,
        DateTime EndedAt
    );
}