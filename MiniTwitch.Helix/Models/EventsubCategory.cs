using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class EventSubCategory
{
    private readonly AllCategories _all;

    internal EventSubCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<CreatedSubscription>> CreateEventSubSubscription(
        NewSubscription body,
        CancellationToken cancellationToken = default)
    => _all.CreateEventSubSubscription(body, cancellationToken);

    public Task<HelixResult> DeleteEventSubSubscription(
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteEventSubSubscription(id, cancellationToken);

    public Task<HelixResult<EventSubSubscriptions>> GetEventSubSubscriptions(
        EventSubStatus? status = null,
        string? type = null,
        long? userId = null,
        CancellationToken cancellationToken = default)
    => _all.GetEventSubSubscriptions(status, type, userId, cancellationToken);
}
