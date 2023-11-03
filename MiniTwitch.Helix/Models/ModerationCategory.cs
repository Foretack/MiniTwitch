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
        MessageToCheck body,
        CancellationToken cancellationToken = default)
    => _all.CheckAutoModStatus(body, cancellationToken);

    public Task<HelixResult> ManageHeldAutoModMessages(
        string msgId,
        string action,
        CancellationToken cancellationToken = default)
    => _all.ManageHeldAutoModMessages(msgId, action, cancellationToken);

    public Task<HelixResult<AutoModSettings>> GetAutoModSettings(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetAutoModSettings(broadcasterId, cancellationToken);

    public Task<HelixResult<AutoModSettings>> UpdateAutoModSettings(
        long broadcasterId,
        NewAutoModSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateAutoModSettings(broadcasterId, body, cancellationToken);

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBannedUsers(userId, first, cancellationToken);

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBannedUsers(userIds, first, cancellationToken);

    public Task<HelixResult<BannedUser>> BanUser(
        long broadcasterId,
        UserToBan body,
        CancellationToken cancellationToken = default)
    => _all.BanUser(broadcasterId, body, cancellationToken);

    public Task<HelixResult> UnbanUser(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.UnbanUser(broadcasterId, userId, cancellationToken);

    public Task<HelixResult<BlockedTerms>> GetBlockedTerms(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBlockedTerms(broadcasterId, first, cancellationToken);

    public Task<HelixResult<BlockedTerms>> AddBlockedTerm(
        long broadcasterId,
        string text,
        CancellationToken cancellationToken = default)
    => _all.AddBlockedTerm(broadcasterId, text, cancellationToken);

    public Task<HelixResult> RemoveBlockedTerm(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    => _all.RemoveBlockedTerm(broadcasterId, id, cancellationToken);

    public Task<HelixResult> DeleteChatMessages(
        long broadcasterId,
        string? messageId = null,
        CancellationToken cancellationToken = default)
    => _all.DeleteChatMessages(broadcasterId, messageId, cancellationToken);

    public Task<HelixResult<Moderators>> GetModerators(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModerators(userId, first, cancellationToken);

    public Task<HelixResult<Moderators>> GetModerators(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModerators(userIds, first, cancellationToken);

    public Task<HelixResult> AddChannelModerator(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.AddChannelModerator(userId, cancellationToken);

    public Task<HelixResult> RemoveChannelModerator(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.RemoveChannelModerator(userId, cancellationToken);

    public Task<HelixResult<ShieldModeStatus>> UpdateShieldModeStatus(
        long broadcasterId,
        bool isActive,
        CancellationToken cancellationToken = default)
    => _all.UpdateShieldModeStatus(broadcasterId, isActive, cancellationToken);

    public Task<HelixResult<ShieldModeStatus>> GetShieldModeStatus(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetShieldModeStatus(broadcasterId, cancellationToken);
}
