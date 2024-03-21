using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class CreatorGoals : BaseResponse<CreatorGoals.Goal>
{
    public record Goal(
        string Id,
        long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        string Type,
        string Description,
        int CurrentAmount,
        int TargetAmount,
        DateTime CreatedAt
    );
}