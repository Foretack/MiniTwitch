using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class ClipsCategory
{
    private readonly AllCategories _all;

    internal ClipsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Clip>> CreateClip(
        long broadcasterId,
        bool? hasDelay = null,
        CancellationToken cancellationToken = default)
    => _all.CreateClip(broadcasterId, hasDelay, cancellationToken);

    public Task<HelixResult<Clips>> GetClips(
        long broadcasterId,
        long gameId,
        string id,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        bool? isFeatured = null,
        CancellationToken cancellationToken = default)
    => _all.GetClips(broadcasterId, gameId, id, startedAt, endedAt, first, isFeatured, cancellationToken);

    public Task<HelixResult<Clips>> GetClips(
        long broadcasterId,
        long gameId,
        IEnumerable<string> ids,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        bool? isFeatured = null,
        CancellationToken cancellationToken = default)
    => _all.GetClips(broadcasterId, gameId, ids, startedAt, endedAt, first, isFeatured, cancellationToken);
}
