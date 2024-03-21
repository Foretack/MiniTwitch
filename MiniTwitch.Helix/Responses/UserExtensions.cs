using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UserExtensions : BaseResponse<UserExtensions.Extension>
{
    public record Extension(
        string Id,
        string Version,
        string Name,
        bool CanActivate,
        IReadOnlyList<string> Type
    );
}