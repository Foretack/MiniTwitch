using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Clip : BaseResponse<Clip.Info>
{
    public record Info(
        string Id,
        string EditUrl
    );
}