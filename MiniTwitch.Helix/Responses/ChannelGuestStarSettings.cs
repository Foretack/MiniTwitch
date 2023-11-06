using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChannelGuestStarSettings : BaseResponse<ChannelGuestStarSettings.Settings>
{
    public record Settings(
        [property: JsonPropertyName("is_moderator_send_live_enabled")] bool IsModeratorSendLiveEnabled,
        [property: JsonPropertyName("slot_count")] int SlotCount,
        [property: JsonPropertyName("is_browser_source_audio_enabled")] bool IsBrowserSourceAudioEnabled,
        [property: JsonPropertyName("layout")] string Layout,
        [property: JsonPropertyName("browser_source_token")] string BrowserSourceToken
    );
}