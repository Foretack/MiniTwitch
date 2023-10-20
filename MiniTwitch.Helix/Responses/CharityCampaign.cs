using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class CharityCampaign : BaseResponse<CharityCampaign.Campaign>
{
    public record Campaign(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        [property: JsonPropertyName("charity_name")] string CharityName,
        [property: JsonPropertyName("charity_description")] string CharityDescription,
        [property: JsonPropertyName("charity_logo")] string CharityLogo,
        [property: JsonPropertyName("charity_website")] string CharityWebsite,
        [property: JsonPropertyName("current_amount")] CurrentAmount CurrentAmount,
        [property: JsonPropertyName("target_amount")] TargetAmount TargetAmount
    );

    public record CurrentAmount(
       [property: JsonPropertyName("value")] int Value,
        [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
        [property: JsonPropertyName("currency")] string Currency
    );

    public record TargetAmount(
        [property: JsonPropertyName("value")] int Value,
        [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
        [property: JsonPropertyName("currency")] string Currency
    );
}