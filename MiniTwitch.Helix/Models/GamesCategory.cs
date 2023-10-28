using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class GamesCategory
{
    private readonly AllCategories _all;

    internal GamesCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Games>> GetTopGames(
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetTopGames(first, cancellationToken);

    public Task<HelixResult<Game>> GetGames(
        string? id = null,
        string? name = null,
        string? igdbId = null,
        CancellationToken cancellationToken = default)
    => _all.GetGames(id, name, igdbId, cancellationToken);

    public Task<HelixResult<Games>> GetGames(
        IEnumerable<string>? ids = null,
        IEnumerable<string>? names = null,
        IEnumerable<string>? igdbIds = null,
        CancellationToken cancellationToken = default)
    => _all.GetGames(ids, names, igdbIds, cancellationToken);
}
