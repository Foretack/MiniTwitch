using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Conduits : BaseResponse<Conduits.Conduit>
{
    public record Conduit(
        string Id,
        int ShardCount
   );
}
