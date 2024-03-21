using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChatBadges : BaseResponse<ChatBadges.BadgeSet>
{
    public record BadgeSet(
        string SetId,
        IReadOnlyList<Version> Versions
    );

    public record Version(
        string Id,
        [property: JsonPropertyName("image_url_1x")] string ImageUrl1x,
        [property: JsonPropertyName("image_url_2x")] string ImageUrl2x,
        [property: JsonPropertyName("image_url_4x")] string ImageUrl4x,
        string Title,
        string Description,
        string ClickAction,
        string ClickUrl
    );
}