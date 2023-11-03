using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class SubscriptionsCategory
{
    private readonly AllCategories _all;

    internal SubscriptionsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBroadcasterSubscriptions(userId, first, cancellationToken);

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBroadcasterSubscriptions(userIds, first, cancellationToken);

    public Task<HelixResult<UserSubscription>> CheckUserSubscription(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.CheckUserSubscription(broadcasterId, cancellationToken);
}
