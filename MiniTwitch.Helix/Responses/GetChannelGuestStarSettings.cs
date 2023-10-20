using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetChannelGuestStarSettings : BaseResponse<GetChannelGuestStarSettings.Datum>
{
   public record Datum(
       [property: JsonPropertyName("is_moderator_send_live_enabled")] bool IsModeratorSendLiveEnabled,
       [property: JsonPropertyName("slot_count")] int SlotCount,
       [property: JsonPropertyName("is_browser_source_audio_enabled")] bool IsBrowserSourceAudioEnabled,
       [property: JsonPropertyName("layout")] string Layout,
       [property: JsonPropertyName("browser_source_token")] string BrowserSourceToken
   );
}