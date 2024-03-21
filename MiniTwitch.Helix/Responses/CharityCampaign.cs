using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class CharityCampaign : BaseResponse<CharityCampaign.Campaign>
{
    public record Campaign(
        string Id,
        long BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
        [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
        string CharityName,
        string CharityDescription,
        string CharityLogo,
        string CharityWebsite,
        CurrentAmount CurrentAmount,
        TargetAmount TargetAmount
    );

    public record CurrentAmount(
       int Value,
        int DecimalPlaces,
        string Currency
    );

    public record TargetAmount(
        int Value,
        int DecimalPlaces,
        string Currency
    );
}