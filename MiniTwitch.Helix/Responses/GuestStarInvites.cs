using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class GuestStarInvites : BaseResponse<GuestStarInvites.Invite>
{
    public record Invite(
        long UserId,
        DateTime InvitedAt,
        string Status,
        bool IsAudioEnabled,
        bool IsVideoEnabled,
        bool IsAudioAvailable,
        bool IsVideoAvailable
    );

}