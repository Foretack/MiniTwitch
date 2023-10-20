using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetChannelChatBadges : BaseResponse<GetChannelChatBadges.BadgeSet>
{
   public record BadgeSet(
       [property: JsonPropertyName("set_id")] string SetId,
       [property: JsonPropertyName("versions")] IReadOnlyList<Version> Versions
   );

   public record Version(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("image_url_1x")] string ImageUrl1x,
       [property: JsonPropertyName("image_url_2x")] string ImageUrl2x,
       [property: JsonPropertyName("image_url_4x")] string ImageUrl4x,
       [property: JsonPropertyName("title")] string Title,
       [property: JsonPropertyName("description")] string Description,
       [property: JsonPropertyName("click_action")] string ClickAction,
       [property: JsonPropertyName("click_url")] string ClickUrl
   );
}