using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class RaidsCategory
{
    private readonly AllCategories _all;

    internal RaidsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Raid>> StartARaid(
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    => _all.StartRaid(toBroadcasterId, cancellationToken);

    public Task<HelixResult> CancelARaid(CancellationToken cancellationToken = default)
    => _all.CancelRaid(cancellationToken);
}
