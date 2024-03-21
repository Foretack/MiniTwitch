using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionSecrets : BaseResponse<ExtensionSecrets.Info>
{
    public record Info(
        int FormatVersion,
        IReadOnlyList<Secret> Secrets
    );

    public record Secret(
        string Content,
        DateTime ActiveAt,
        DateTime ExpiresAt
    );
}