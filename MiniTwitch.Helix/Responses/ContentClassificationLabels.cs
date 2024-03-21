using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ContentClassificationLabels : BaseResponse<ContentClassificationLabels.Label>
{
    public record Label(
        string Id,
        string Description,
        string Name
    );
}