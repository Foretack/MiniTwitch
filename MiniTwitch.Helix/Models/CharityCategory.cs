using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class CharityCategory
{
    private readonly AllCategories _all;

    internal CharityCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<CharityCampaign>> GetCharityCampaign(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetCharityCampaign(broadcasterId, cancellationToken);

    public Task<HelixResult<CharityCampaignDonations>> GetCharityCampaignDonations(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCharityCampaignDonations(broadcasterId, first, cancellationToken);
}
