using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class StreamMarker : BaseResponse<StreamMarker.Marker>
{
    public record Marker(
        int Id,
        DateTime CreatedAt,
        string Description,
        int PositionSeconds
    );
}