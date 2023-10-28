using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class TeamsCategory
{
    private readonly AllCategories _all;

    internal TeamsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<ChannelTeams>> GetChannelTeams(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelTeams(broadcasterId, cancellationToken);

    public Task<HelixResult<Teams>> GetTeams(
        string name,
        string id,
        CancellationToken cancellationToken = default)
    => _all.GetTeams(name, id, cancellationToken);
}
