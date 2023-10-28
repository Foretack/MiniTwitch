using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class ChannelPointsCategory
{
    private readonly AllCategories _all;

    internal ChannelPointsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<CustomReward>> CreateCustomReward(
        long broadcasterId,
        NewCustomReward body,
        CancellationToken cancellationToken = default)
    => _all.CreateCustomReward(broadcasterId, body, cancellationToken);

    public Task<HelixResult> DeleteCustomReward(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteCustomReward(broadcasterId, id, cancellationToken);

    public Task<HelixResult<CustomReward>> GetCustomReward(
        long broadcasterId,
        string? id = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    => _all.GetCustomReward(broadcasterId, id, onlyManageableRewards, cancellationToken);

    public Task<HelixResult<CustomReward>> GetCustomReward(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    => _all.GetCustomReward(broadcasterId, ids, onlyManageableRewards, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        long broadcasterId,
        string rewardId,
        RewardRedemptionStatus status,
        string? id = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCustomRewardRedemption(broadcasterId, rewardId, status, id, sort, first, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        long broadcasterId,
        string rewardId,
        RewardRedemptionStatus status,
        IEnumerable<string>? ids = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCustomRewardRedemption(broadcasterId, rewardId, status, ids, sort, first, cancellationToken);

    public Task<HelixResult<CustomReward>> UpdateCustomReward(
        long broadcasterId,
        string id,
        UpdatedCustomReward body,
        CancellationToken cancellationToken = default)
    => _all.UpdateCustomReward(broadcasterId, id, body, cancellationToken);

    public Task<HelixResult<CustomRewardRedemption>> UpdateRedemptionStatus(
        long broadcasterId,
        string id,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    => _all.UpdateRedemptionStatus(broadcasterId, id, rewardId, status, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> UpdateRedemptionStatus(
        long broadcasterId,
        IEnumerable<string> ids,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    => _all.UpdateRedemptionStatus(broadcasterId, ids, rewardId, status, cancellationToken);
}
