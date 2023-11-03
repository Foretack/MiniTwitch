using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class GuestStarSession : BaseResponse<GuestStarSession.Info>
{
    public record AudioSettings(
       [property: JsonPropertyName("is_available")] bool IsAvailable,
       [property: JsonPropertyName("is_host_enabled")] bool IsHostEnabled,
       [property: JsonPropertyName("is_guest_enabled")] bool IsGuestEnabled
   );

    public record Info(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("guests")] IReadOnlyList<Guest> Guests
    );

    public record Guest(
        [property: JsonPropertyName("slot_id")] string SlotId,
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("user_display_name")] string DisplayName,
        [property: JsonPropertyName("user_login")] string Username,
        [property: JsonPropertyName("is_live")] bool IsLive,
        [property: JsonPropertyName("volume")] int Volume,
        [property: JsonPropertyName("assigned_at")] DateTime AssignedAt,
        [property: JsonPropertyName("audio_settings")] AudioSettings AudioSettings,
        [property: JsonPropertyName("video_settings")] VideoSettings VideoSettings
    );

    public record VideoSettings(
        [property: JsonPropertyName("is_available")] bool IsAvailable,
        [property: JsonPropertyName("is_host_enabled")] bool IsHostEnabled,
        [property: JsonPropertyName("is_guest_enabled")] bool IsGuestEnabled
    );
}