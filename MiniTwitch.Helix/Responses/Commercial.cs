using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Commercial : BaseResponse<Commercial.Info>
{
    public record Info(
        int Length,
        string Message,
        int RetryAfter
    );
}