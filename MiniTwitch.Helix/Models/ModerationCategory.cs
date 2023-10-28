using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class ModerationCategory
{
    private readonly AllCategories _all;

    internal ModerationCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<AutoModStatus>> CheckAutoModStatus(
        long broadcasterId,
        MessageToCheck body,
        CancellationToken cancellationToken = default)
    => _all.CheckAutoModStatus(broadcasterId, body, cancellationToken);

    public Task<HelixResult> ManageHeldAutoModMessages(
        long userId,
        string msgId,
        string action,
        CancellationToken cancellationToken = default)
    => _all.ManageHeldAutoModMessages(userId, msgId, action, cancellationToken);

    public Task<HelixResult<AutoModSettings>> GetAutoModSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.GetAutoModSettings(broadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult<AutoModSettings>> UpdateAutoModSettings(
        long broadcasterId,
        long moderatorId,
        NewAutoModSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateAutoModSettings(broadcasterId, moderatorId, body, cancellationToken);

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBannedUsers(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBannedUsers(broadcasterId, userIds, first, cancellationToken);

    public Task<HelixResult<BannedUser>> BanUser(
        long broadcasterId,
        long moderatorId,
        UserToBan body,
        CancellationToken cancellationToken = default)
    => _all.BanUser(broadcasterId, moderatorId, body, cancellationToken);

    public Task<HelixResult> UnbanUser(
        long broadcasterId,
        long moderatorId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.UnbanUser(broadcasterId, moderatorId, userId, cancellationToken);

    public Task<HelixResult<BlockedTerms>> GetBlockedTerms(
        long broadcasterId,
        long moderatorId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBlockedTerms(broadcasterId, moderatorId, first, cancellationToken);

    public Task<HelixResult<BlockedTerm>> AddBlockedTerm(
        long broadcasterId,
        long moderatorId,
        string text,
        CancellationToken cancellationToken = default)
    => _all.AddBlockedTerm(broadcasterId, moderatorId, text, cancellationToken);

    public Task<HelixResult> RemoveBlockedTerm(
        long broadcasterId,
        long moderatorId,
        string id,
        CancellationToken cancellationToken = default)
    => _all.RemoveBlockedTerm(broadcasterId, moderatorId, id, cancellationToken);

    public Task<HelixResult> DeleteChatMessages(
        long broadcasterId,
        long moderatorId,
        string? messageId = null,
        CancellationToken cancellationToken = default)
    => _all.DeleteChatMessages(broadcasterId, moderatorId, messageId, cancellationToken);

    public Task<HelixResult<Moderators>> GetModerators(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModerators(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<Moderators>> GetModerators(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModerators(broadcasterId, userIds, first, cancellationToken);

    public Task<HelixResult> AddChannelModerator(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.AddChannelModerator(broadcasterId, userId, cancellationToken);

    public Task<HelixResult> RemoveChannelModerator(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.RemoveChannelModerator(broadcasterId, userId, cancellationToken);

    public Task<HelixResult<ShieldModeStatus>> UpdateShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        bool isActive,
        CancellationToken cancellationToken = default)
    => _all.UpdateShieldModeStatus(broadcasterId, moderatorId, isActive, cancellationToken);

    public Task<HelixResult<ShieldModeStatus>> GetShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.GetShieldModeStatus(broadcasterId, moderatorId, cancellationToken);
}
