using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class EntitlementsCategory
{
    private readonly AllCategories _all;

    internal EntitlementsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<DropsEntitlements>> GetDropsEntitlements(
        string? id = null,
        long? userId = null,
        string? gameId = null,
        FulfillmentStatus? fulfillmentStatus = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetDropsEntitlements(id, userId, gameId, fulfillmentStatus, first, cancellationToken);

    public Task<HelixResult<DropsEntitlements>> GetDropsEntitlements(
        IEnumerable<string>? ids = null,
        long? userId = null,
        string? gameId = null,
        FulfillmentStatus? fulfillmentStatus = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetDropsEntitlements(ids, userId, gameId, fulfillmentStatus, first, cancellationToken);

    public Task<HelixResult<UpdatedDropsEntitlements>> UpdateDropsEntitlements(
        IEnumerable<string>? entitlementIds = null,
        FulfillmentStatus? fulfillmentStatus = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateDropsEntitlements(entitlementIds, fulfillmentStatus, cancellationToken);
}
