using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UserSubscription : BaseResponse<UserSubscription.Info>
{
    public record Info(
        string BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
        bool IsGift,
        string Tier
    );
}