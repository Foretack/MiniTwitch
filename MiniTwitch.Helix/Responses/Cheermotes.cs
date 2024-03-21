using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Cheermotes : BaseResponse<Cheermotes.Emote>
{
    public record Emote(
        string Prefix,
        IReadOnlyList<Tier> Tiers,
        string Type,
        int Order,
        DateTime LastUpdated,
        bool IsCharitable
    );
    public record Tier(
        int MinBits,
        string Id,
        string Color,
        Images Images,
        bool CanCheer,
        bool ShowInBitsCard
    );
    public record Images(
        ImageSet Dark,
        ImageSet Light
    );
    public record ImageSet(
        IDictionary<string, string> Animated,
        IDictionary<string, string> Static
    );
}