using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Prediction : BaseResponse<Prediction.Info>
{
    public record Info(
        string Id,
        long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        string Title,
        string? WinningOutcomeId,
        IReadOnlyList<Outcome> Outcomes,
        int PredictionWindow,
        string Status,
        DateTime CreatedAt,
        DateTime? EndedAt,
        DateTime? LockedAt
    );

    public record Outcome(
        string Id,
        string Title,
        int Users,
        int ChannelPoints,
        object TopPredictors,
        string Color
    );
}