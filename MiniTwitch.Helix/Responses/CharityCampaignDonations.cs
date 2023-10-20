using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class CharityCampaignDonations : PaginableResponse<CharityCampaignDonations.Donation>
{
    public record Donation(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("campaign_id")] string CampaignId,
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("user_login")] string Username,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
        [property: JsonPropertyName("amount")] DonationAmount Amount
    );

    public record DonationAmount(
        [property: JsonPropertyName("value")] int Value,
        [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
        [property: JsonPropertyName("curency")] string Currency
    )
    {
        public double GetActualAmount() => this.Value * Math.Pow(10, -this.DecimalPlaces);
    };
}