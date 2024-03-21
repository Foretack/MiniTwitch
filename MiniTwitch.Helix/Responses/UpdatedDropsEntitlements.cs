using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UpdatedDropsEntitlements : BaseResponse<UpdatedDropsEntitlements.Info>
{
    public record Info(
        string Status,
        IReadOnlyList<string> Ids
    );
}