using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class UpdateCustomReward : BaseResponse<UpdateCustomReward.Datum>
{
   public record Datum(
       [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
       [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("id")] string RewardId,
       [property: JsonPropertyName("image")] Image? Image,
       [property: JsonPropertyName("background_color")] string BackgroundColor,
       [property: JsonPropertyName("is_enabled")] bool IsEnabled,
       [property: JsonPropertyName("cost")] long Cost,
       [property: JsonPropertyName("title")] string Title,
       [property: JsonPropertyName("prompt")] string Prompt,
       [property: JsonPropertyName("is_user_input_required")] bool IsUserInputRequired,
       [property: JsonPropertyName("max_per_stream_setting")] MaxPerStreamSetting MaxPerStreamSetting,
       [property: JsonPropertyName("max_per_user_per_stream_setting")] MaxPerUserPerStreamSetting MaxPerUserPerStreamSetting,
       [property: JsonPropertyName("global_cooldown_setting")] GlobalCooldownSetting GlobalCooldownSetting,
       [property: JsonPropertyName("is_paused")] bool IsPaused,
       [property: JsonPropertyName("is_in_stock")] bool IsInStock,
       [property: JsonPropertyName("default_image")] Image DefaultImage,
       [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool ShouldRedemptionsSkipRequestQueue,
       [property: JsonPropertyName("redemptions_redeemed_current_stream")] int? RedemptionsRedeemedInCurrentStream,
       [property: JsonPropertyName("cooldown_expires_at")] DateTime? CooldownExpiresAt
   );

   public record struct Image(
      [property: JsonPropertyName("url_1x")] string Url1x,
      [property: JsonPropertyName("url_2x")] string Url2x,
      [property: JsonPropertyName("url_4x")] string Url4x
   );

   public record struct GlobalCooldownSetting(
       [property: JsonPropertyName("is_enabled")] bool IsEnabled,
       [property: JsonPropertyName("global_cooldown_seconds")] long GlobalCooldownSeconds
   );

   public record struct MaxPerStreamSetting(
       [property: JsonPropertyName("is_enabled")] bool IsEnabled,
       [property: JsonPropertyName("max_per_stream")] long MaxPerStream
   );

   public record struct MaxPerUserPerStreamSetting(
       [property: JsonPropertyName("is_enabled")] bool IsEnabled,
       [property: JsonPropertyName("max_per_user_per_stream")] long MaxPerUserPerStream
   );
}