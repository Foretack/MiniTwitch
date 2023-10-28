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
        long fromBroadcasterId,
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    => _all.StartARaid(fromBroadcasterId, toBroadcasterId, cancellationToken);

    public Task<HelixResult> CancelARaid(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.CancelARaid(broadcasterId, cancellationToken);
}
