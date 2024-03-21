using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class SentMessage : BaseResponse<SentMessage.Info>
{
    public record Info(
        string MessageId,
        bool IsSent,
        DropInfo? DropReason
    );

    public record DropInfo(
        string Code,
        string Message
    );
}