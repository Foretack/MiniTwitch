using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class BitsCategory
{
    private readonly AllCategories _all;

    internal BitsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<BitsLeaderboard>> GetBitsLeaderboard(
        int? count = null,
        BitsLeaderboardPeriod? period = null,
        DateTime? startedAt = null,
        long? UserId = null,
        CancellationToken cancellationToken = default)
    => _all.GetBitsLeaderboard(count, period, startedAt, UserId, cancellationToken);

    public Task<HelixResult<Cheermotes>> GetCheermotes(
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    => _all.GetCheermotes(broadcasterId, cancellationToken);

    public Task<HelixResult<ExtensionBitsProducts>> GetExtensionBitsProducts(
        bool? shouldIncludeAll = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionBitsProducts(shouldIncludeAll, cancellationToken);

    public Task<HelixResult<ExtensionBitsProducts>> UpdateExtensionBitsProduct(
        UpdatedBitsProduct body,
        CancellationToken cancellationToken = default)
    => _all.UpdateExtensionBitsProduct(body, cancellationToken);

}
