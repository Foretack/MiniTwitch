using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetGuestStarSession : SingleResponse<GetGuestStarSession.Datum>
{
   public record AudioSettings(
      [property: JsonPropertyName("is_available")] bool IsAvailable,
      [property: JsonPropertyName("is_host_enabled")] bool IsHostEnabled,
      [property: JsonPropertyName("is_guest_enabled")] bool IsGuestEnabled
  );

   public record Datum(
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