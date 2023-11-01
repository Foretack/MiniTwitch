using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class StreamsCategory
{
    private readonly AllCategories _all;

    internal StreamsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<StreamKey>> GetStreamKey(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetStreamKey(broadcasterId, cancellationToken);

    public Task<HelixResult<SingleStream>> GetStreams(
        long? userId = null,
        string? userLogin = null,
        string? gameId = null,
        StreamTypes? type = null,
        string? language = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetStreams(userId, userLogin, gameId, type, language, first, cancellationToken);

    public Task<HelixResult<Streams>> GetStreams(
        IEnumerable<long>? userIds = null,
        IEnumerable<string>? userLogins = null,
        IEnumerable<string>? gameIds = null,
        StreamTypes? type = null,
        IEnumerable<string>? languages = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetStreams(userIds, userLogins, gameIds, type, languages, first, cancellationToken);

    public Task<HelixResult<FollowedStreams>> GetFollowedStreams(
        long userId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetFollowedStreams(userId, first, cancellationToken);

    public Task<HelixResult<StreamMarker>> CreateStreamMarker(
        long userId,
        string? description = null,
        CancellationToken cancellationToken = default)
    => _all.CreateStreamMarker(userId, description, cancellationToken);

    public Task<HelixResult<StreamMarkers>> GetStreamMarkers(
        long userId,
        string? videoId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetStreamMarkers(userId, videoId, first, cancellationToken);
}
