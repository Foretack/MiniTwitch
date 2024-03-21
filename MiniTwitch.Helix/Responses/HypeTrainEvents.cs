using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class HypeTrainEvents : PaginableResponse<HypeTrainEvents.Event>
{
    public record Event(
        string Id,
        string EventType,
        DateTime EventTimestamp,
        string Version,
        EventData EventData
    );

    public record EventData(
        long BroadcasterId,
        string CooldownEndTime,
        DateTime ExpiresAt,
        int Goal,
        string Id,
        Contribution LastContribution,
        int Level,
        DateTime StartedAt,
        IReadOnlyList<Contribution> TopContributions,
        int Total
    );

    public record Contribution(
        int Total,
        string Type,
        [property: JsonPropertyName("user")] long UserId
    );

}