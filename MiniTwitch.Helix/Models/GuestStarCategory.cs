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
        CancellationToken cancellationToken = default)
    => _all.GetChannelGuestStarSettings(broadcasterId, cancellationToken);

    public Task<HelixResult> UpdateChannelGuestStarSettings(
        NewGuestStarSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelGuestStarSettings(body, cancellationToken);

    public Task<HelixResult<GuestStarSession>> GetGuestStarSession(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetGuestStarSession(broadcasterId, cancellationToken);

    public Task<HelixResult<GuestStarSession>> CreateGuestStarSession(
        CancellationToken cancellationToken = default)
    => _all.CreateGuestStarSession(cancellationToken);

    public Task<HelixResult<GuestStarSession>> EndGuestStarSession(
        string sessionId,
        CancellationToken cancellationToken = default)
    => _all.EndGuestStarSession(sessionId, cancellationToken);

    public Task<HelixResult<GuestStarInvites>> GetGuestStarInvites(
        long broadcasterId,
        string sessionId,
        CancellationToken cancellationToken = default)
    => _all.GetGuestStarInvites(broadcasterId, sessionId, cancellationToken);

    public Task<HelixResult> SendGuestStarInvite(
        long broadcasterId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    => _all.SendGuestStarInvite(broadcasterId, sessionId, guestId, cancellationToken);

    public Task<HelixResult> DeleteGuestStarInvite(
        long broadcasterId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    => _all.DeleteGuestStarInvite(broadcasterId, sessionId, guestId, cancellationToken);

    public Task<HelixResult> AssignGuestStarSlot(
        long broadcasterId,
        string sessionId,
        long guestId,
        string slotId,
        CancellationToken cancellationToken = default)
    => _all.AssignGuestStarSlot(broadcasterId, sessionId, guestId, slotId, cancellationToken);

    public Task<HelixResult> UpdateGuestStarSlot(
        long broadcasterId,
        string sessionId,
        string sourceSlotId,
        string? destinationSlotId = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateGuestStarSlot(broadcasterId, sessionId, sourceSlotId, destinationSlotId, cancellationToken);

    public Task<HelixResult> DeleteGuestStarSlot(
        long broadcasterId,
        string sessionId,
        long guestId,
        string slotId,
        string? shouldReinviteGuest = null,
        CancellationToken cancellationToken = default)
    => _all.DeleteGuestStarSlot(broadcasterId, sessionId, guestId, slotId, shouldReinviteGuest, cancellationToken);

    public Task<HelixResult> UpdateGuestStarSlotSettings(
        long broadcasterId,
        string sessionId,
        string slotId,
        bool? isAudioEnabled = null,
        bool? isVideoEnabled = null,
        bool? isLive = null,
        int? volume = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateGuestStarSlotSettings(broadcasterId, sessionId, slotId, isAudioEnabled, isVideoEnabled, isLive, volume, cancellationToken);
}
