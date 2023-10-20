using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class Extensions : BaseResponse<Extensions.Extension>
{
   public record Component(
       [property: JsonPropertyName("viewer_url")] string ViewerUrl,
       [property: JsonPropertyName("aspect_width")] int AspectWidth,
       [property: JsonPropertyName("aspect_height")] int AspectHeight,
       [property: JsonPropertyName("aspect_ratio_x")] int AspectRatioX,
       [property: JsonPropertyName("aspect_ratio_y")] int AspectRatioY,
       [property: JsonPropertyName("autoscale")] bool Autoscale,
       [property: JsonPropertyName("scale_pixels")] int ScalePixels,
       [property: JsonPropertyName("target_height")] int TargetHeight,
       [property: JsonPropertyName("size")] int Size,
       [property: JsonPropertyName("zoom")] bool Zoom,
       [property: JsonPropertyName("zoom_pixels")] int ZoomPixels,
       [property: JsonPropertyName("can_link_external_content")] bool CanLinkExternalContent
   );

   public record Extension(
       [property: JsonPropertyName("author_name")] string AuthorName,
       [property: JsonPropertyName("bits_enabled")] bool BitsEnabled,
       [property: JsonPropertyName("can_install")] bool CanInstall,
       [property: JsonPropertyName("configuration_location")] string ConfigurationLocation,
       [property: JsonPropertyName("description")] string Description,
       [property: JsonPropertyName("eula_tos_url")] string EulaTosUrl,
       [property: JsonPropertyName("has_chat_support")] bool HasChatSupport,
       [property: JsonPropertyName("icon_url")] string IconUrl,
       [property: JsonPropertyName("icon_urls")] IconUrls IconUrls,
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("name")] string Name,
       [property: JsonPropertyName("privacy_policy_url")] string PrivacyPolicyUrl,
       [property: JsonPropertyName("request_identity_link")] bool RequestIdentityLink,
       [property: JsonPropertyName("screenshot_urls")] IReadOnlyList<string> ScreenshotUrls,
       [property: JsonPropertyName("state")] string State,
       [property: JsonPropertyName("subscriptions_support_level")] string SubscriptionsSupportLevel,
       [property: JsonPropertyName("summary")] string Summary,
       [property: JsonPropertyName("support_email")] string SupportEmail,
       [property: JsonPropertyName("version")] string Version,
       [property: JsonPropertyName("viewer_summary")] string ViewerSummary,
       [property: JsonPropertyName("views")] Views Views,
       [property: JsonPropertyName("allowlisted_config_urls")] IReadOnlyList<string> AllowlistedConfigUrls,
       [property: JsonPropertyName("allowlisted_panel_urls")] IReadOnlyList<string> AllowlistedPanelUrls
   );

   public record IconUrls(
       [property: JsonPropertyName("100x100")] string Url100x100,
       [property: JsonPropertyName("24x24")] string Url24x24,
       [property: JsonPropertyName("300x200")] string Url300x200
   );

   public record Mobile(
       [property: JsonPropertyName("viewer_url")] string ViewerUrl
   );

   public record Panel(
       [property: JsonPropertyName("viewer_url")] string ViewerUrl,
       [property: JsonPropertyName("height")] int Height,
       [property: JsonPropertyName("can_link_external_content")] bool CanLinkExternalContent
   );

   public record VideoOverlay(
       [property: JsonPropertyName("viewer_url")] string ViewerUrl,
       [property: JsonPropertyName("can_link_external_content")] bool CanLinkExternalContent
   );

   public record Views(
       [property: JsonPropertyName("mobile")] Mobile Mobile,
       [property: JsonPropertyName("panel")] Panel Panel,
       [property: JsonPropertyName("video_overlay")] VideoOverlay VideoOverlay,
       [property: JsonPropertyName("component")] Component Component
   );
}