using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class AnalyticsCategory
{
    private readonly AllCategories _all;

    internal AnalyticsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<ExtensionAnalytics>> GetExtensionAnalytics(
        string? extensionId = null,
        AnalyticsType? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionAnalytics(extensionId, type, startedAt, endedAt, first, cancellationToken);

    public Task<HelixResult<GameAnalytics>> GetGameAnalytics(
        string? gameId = null,
        AnalyticsType? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetGameAnalytics(gameId, type, startedAt, endedAt, first, cancellationToken);

}
