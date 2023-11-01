using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class ChannelsCategory
{
    private readonly AllCategories _all;

    internal ChannelsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Commercial>> StartCommercial(
        NewCommercial body,
        CancellationToken cancellationToken = default)
    => _all.StartCommercial(body, cancellationToken);

    public Task<HelixResult<AdSchedule>> GetAdSchedule(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetAdSchedule(broadcasterId, cancellationToken);

    public Task<HelixResult<SnoozedAd>> SnoozeNextAd(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.SnoozeNextAd(broadcasterId, cancellationToken);


    public Task<HelixResult<ChannelInformation>> GetChannelInformation(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelInformation(broadcasterId, cancellationToken);

    public Task<HelixResult<ChannelsInformation>> GetChannelInformation(
        IEnumerable<long> broadcasterIds,
        CancellationToken cancellationToken = default)
    => _all.GetChannelInformation(broadcasterIds, cancellationToken);

    public Task<HelixResult> ModifyChannelInformation(
        long broadcasterId,
        NewChannelInformation body,
        CancellationToken cancellationToken = default)
    => _all.ModifyChannelInformation(broadcasterId, body, cancellationToken);

    public Task<HelixResult<ChannelEditors>> GetChannelEditors(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelEditors(broadcasterId, cancellationToken);

    public Task<HelixResult<FollowedChannels>> GetFollowedChannels(
        long userId,
        long? broadcasterId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetFollowedChannels(userId, broadcasterId, first, cancellationToken);

    public Task<HelixResult<ChannelFollowers>> GetChannelFollowers(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChannelFollowers(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<VIPs>> GetVIPs(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVIPs(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<VIPs>> GetVIPs(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVIPs(broadcasterId, userIds, first, cancellationToken);

    public Task<HelixResult> AddChannelVIP(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.AddChannelVIP(broadcasterId, userId, cancellationToken);

    public Task<HelixResult> RemoveChannelVIP(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.RemoveChannelVIP(broadcasterId, userId, cancellationToken);
}
