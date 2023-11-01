using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class SearchCategory
{
    private readonly AllCategories _all;

    internal SearchCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Categories>> SearchCategories(
        string query,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.SearchCategories(query, first, cancellationToken);

    public Task<HelixResult<Channels>> SearchChannels(
        string query,
        bool? liveOnly = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.SearchChannels(query, liveOnly, first, cancellationToken);
}
