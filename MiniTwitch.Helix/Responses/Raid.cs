using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Raid : BaseResponse<Raid.Info>
{
    public record Info(
        DateTime CreatedAt,
        bool IsMature
    );
}