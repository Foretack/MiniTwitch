using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class PollsCategory
{
    private readonly AllCategories _all;

    internal PollsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Polls>> GetPolls(
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPolls(id, first, cancellationToken);

    public Task<HelixResult<Polls>> GetPolls(
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPolls(ids, first, cancellationToken);

    public Task<HelixResult<Poll>> CreatePoll(
        NewPoll body,
        CancellationToken cancellationToken = default)
    => _all.CreatePoll(body, cancellationToken);

    public Task<HelixResult<Poll>> EndPoll(
        string id,
        string status,
        CancellationToken cancellationToken = default)
    => _all.EndPoll(id, status, cancellationToken);
}
