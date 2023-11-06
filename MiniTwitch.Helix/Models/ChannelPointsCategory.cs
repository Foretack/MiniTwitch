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
        NewCustomReward body,
        CancellationToken cancellationToken = default)
    => _all.CreateCustomReward(body, cancellationToken);

    public Task<HelixResult> DeleteCustomReward(
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteCustomReward(id, cancellationToken);

    public Task<HelixResult<CustomReward>> GetCustomReward(
        string? id = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    => _all.GetCustomReward(id, onlyManageableRewards, cancellationToken);

    public Task<HelixResult<CustomReward>> GetCustomReward(
        IEnumerable<string>? ids = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    => _all.GetCustomReward(ids, onlyManageableRewards, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        string rewardId,
        RewardRedemptionStatus status,
        string? id = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCustomRewardRedemption(rewardId, status, id, sort, first, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        string rewardId,
        RewardRedemptionStatus status,
        IEnumerable<string>? ids = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCustomRewardRedemption(rewardId, status, ids, sort, first, cancellationToken);

    public Task<HelixResult<CustomReward>> UpdateCustomReward(
        string id,
        UpdatedCustomReward body,
        CancellationToken cancellationToken = default)
    => _all.UpdateCustomReward(id, body, cancellationToken);

    public Task<HelixResult<CustomRewardRedemption>> UpdateRedemptionStatus(
        string id,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    => _all.UpdateRedemptionStatus(id, rewardId, status, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> UpdateRedemptionStatus(
        IEnumerable<string> ids,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    => _all.UpdateRedemptionStatus(ids, rewardId, status, cancellationToken);
}
