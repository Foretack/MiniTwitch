using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class SharedChatSession : BaseResponse<SharedChatSession.Session>
{
    public record Session(
        string SessionId,
        long HostBroadcasterId,
        IReadOnlyList<SharedChatParticipant> Participants,
        DateTime? CreatedAt,
        DateTime? UpdatedAt
    );

    public record SharedChatParticipant(
        long BroadcasterId
    );
}
