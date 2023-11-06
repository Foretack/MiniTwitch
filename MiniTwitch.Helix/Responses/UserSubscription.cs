using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UserSubscription : BaseResponse<UserSubscription.Info>
{
    public record Info(
        [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
        [property: JsonPropertyName("is_gift")] bool IsGift,
        [property: JsonPropertyName("tier")] string Tier
    );
}