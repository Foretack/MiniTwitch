using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class VideosCategory
{
    private readonly AllCategories _all;

    internal VideosCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Videos>> GetVideos(
        string? id = null,
        long? userId = null,
        string? gameId = null,
        string? language = null,
        VideoPeriod? period = null,
        VideoSortMethod? sort = null,
        VideoType? type = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVideos(id, userId, gameId, language, period, sort, type, first, cancellationToken);

    public Task<HelixResult<Videos>> GetVideos(
        IEnumerable<string>? ids = null,
        long? userId = null,
        string? gameId = null,
        string? language = null,
        VideoPeriod? period = null,
        VideoSortMethod? sort = null,
        VideoType? type = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVideos(ids, userId, gameId, language, period, sort, type, first, cancellationToken);

    public Task<HelixResult> DeleteVideos(
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteVideos(id, cancellationToken);

    public Task<HelixResult> DeleteVideos(
        IEnumerable<string> ids,
        CancellationToken cancellationToken = default)
    => _all.DeleteVideos(ids, cancellationToken);
}
