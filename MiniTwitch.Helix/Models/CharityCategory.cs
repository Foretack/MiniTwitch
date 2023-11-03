using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class CharityCategory
{
    private readonly AllCategories _all;

    internal CharityCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<CharityCampaign>> GetCharityCampaign(CancellationToken cancellationToken = default)
    => _all.GetCharityCampaign(cancellationToken);

    public Task<HelixResult<CharityCampaignDonations>> GetCharityCampaignDonations(
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCharityCampaignDonations(first, cancellationToken);
}
