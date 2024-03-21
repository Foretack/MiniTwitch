using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class StreamKey : BaseResponse<StreamKey.Info>
{
    public record Info(
        string StreamKey
    );
}