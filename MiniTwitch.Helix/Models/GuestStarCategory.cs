using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class GuestStarCategory
{
    private readonly AllCategories _all;

    internal GuestStarCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<ChannelGuestStarSettings>> GetChannelGuestStarSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelGuestStarSettings(broadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult> UpdateChannelGuestStarSettings(
        NewGuestStarSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelGuestStarSettings(body, cancellationToken);

    public Task<HelixResult<GuestStarSession>> GetGuestStarSession(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.GetGuestStarSession(broadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult<GuestStarSession>> CreateGuestStarSession(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.CreateGuestStarSession(broadcasterId, cancellationToken);

    public Task<HelixResult<GuestStarSession>> EndGuestStarSession(
        long broadcasterId,
        string sessionId,
        CancellationToken cancellationToken = default)
    => _all.EndGuestStarSession(broadcasterId, sessionId, cancellationToken);

    public Task<HelixResult<GuestStarInvites>> GetGuestStarInvites(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        CancellationToken cancellationToken = default)
    => _all.GetGuestStarInvites(broadcasterId, moderatorId, sessionId, cancellationToken);

    public Task<HelixResult> SendGuestStarInvite(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    => _all.SendGuestStarInvite(broadcasterId, moderatorId, sessionId, guestId, cancellationToken);

    public Task<HelixResult> DeleteGuestStarInvite(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    => _all.DeleteGuestStarInvite(broadcasterId, moderatorId, sessionId, guestId, cancellationToken);

    public Task<HelixResult> AssignGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        string slotId,
        CancellationToken cancellationToken = default)
    => _all.AssignGuestStarSlot(broadcasterId, moderatorId, sessionId, guestId, slotId, cancellationToken);

    public Task<HelixResult> UpdateGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        string sourceSlotId,
        string? destinationSlotId = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateGuestStarSlot(broadcasterId, moderatorId, sessionId, sourceSlotId, destinationSlotId, cancellationToken);

    public Task<HelixResult> DeleteGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        string slotId,
        string? shouldReinviteGuest = null,
        CancellationToken cancellationToken = default)
    => _all.DeleteGuestStarSlot(broadcasterId, moderatorId, sessionId, guestId, slotId, shouldReinviteGuest, cancellationToken);

    public Task<HelixResult> UpdateGuestStarSlotSettings(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        string slotId,
        bool? isAudioEnabled = null,
        bool? isVideoEnabled = null,
        bool? isLive = null,
        int? volume = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateGuestStarSlotSettings(broadcasterId, moderatorId, sessionId, slotId, isAudioEnabled, isVideoEnabled, isLive, volume, cancellationToken);
}
