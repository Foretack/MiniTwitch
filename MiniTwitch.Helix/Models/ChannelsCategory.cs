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


    public Task<HelixResult<ChannelsInformation>> GetChannelInformation(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelInformation(broadcasterId, cancellationToken);

    public Task<HelixResult<ChannelsInformation>> GetChannelInformation(
        IEnumerable<long> broadcasterIds,
        CancellationToken cancellationToken = default)
    => _all.GetChannelInformation(broadcasterIds, cancellationToken);

    public Task<HelixResult> ModifyChannelInformation(
        NewChannelInformation body,
        CancellationToken cancellationToken = default)
    => _all.ModifyChannelInformation(body, cancellationToken);

    public Task<HelixResult<ChannelEditors>> GetChannelEditors(
        CancellationToken cancellationToken = default)
    => _all.GetChannelEditors(cancellationToken);

    public Task<HelixResult<FollowedChannels>> GetFollowedChannels(
        long? broadcasterId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetFollowedChannels(broadcasterId, first, cancellationToken);

    public Task<HelixResult<ChannelFollowers>> GetChannelFollowers(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChannelFollowers(userId, first, cancellationToken);

    public Task<HelixResult<VIPs>> GetVIPs(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVIPs(userId, first, cancellationToken);

    public Task<HelixResult<VIPs>> GetVIPs(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVIPs(userIds, first, cancellationToken);

    public Task<HelixResult> AddChannelVIP(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.AddChannelVIP(userId, cancellationToken);

    public Task<HelixResult> RemoveChannelVIP(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.RemoveChannelVIP(userId, cancellationToken);
}
