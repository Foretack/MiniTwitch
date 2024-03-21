using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class CharityCampaignDonations : PaginableResponse<CharityCampaignDonations.Donation>
{
    public record Donation(
        string Id,
        string CampaignId,
      long UserId,
        [property: JsonPropertyName("user_login")] string Username,
        [property: JsonPropertyName("user_name")] string UserDisplayName,
        DonationAmount Amount
    );

    public record DonationAmount(
        int Value,
        int DecimalPlaces,
        string Currency
    )
    {
        public double GetActualAmount() => this.Value * Math.Pow(10, -this.DecimalPlaces);
    };
}