using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class CustomRewardRedemption : PaginableResponse<CustomRewardRedemption.Info>
{
    public record Info(
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
        [property: JsonPropertyName("user_login")] string UserName,
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("user_input")] string UserInput,
        [property: JsonPropertyName("redeemed_at")] DateTime RedeemedAt,
        [property: JsonPropertyName("reward")] RedemptionReward Reward
    )
    {
        internal string status = "None";
        public RewardRedemptionStatus Status => Enum.Parse<RewardRedemptionStatus>(status);
    };

    public record RedemptionReward(
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("prompt")] string Prompt,
        [property: JsonPropertyName("cost")] long Cost
    );
}