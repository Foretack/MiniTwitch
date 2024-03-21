using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class GuestStarSession : BaseResponse<GuestStarSession.Info>
{
    public record AudioSettings(
       bool IsAvailable,
       bool IsHostEnabled,
       bool IsGuestEnabled
   );

    public record Info(
        string Id,
        IReadOnlyList<Guest> Guests
    );

    public record Guest(
        string SlotId,
        long UserId,
        [property: JsonPropertyName("user_display_name")] string DisplayName,
        [property: JsonPropertyName("user_login")] string Username,
        bool IsLive,
        int Volume,
        DateTime AssignedAt,
        AudioSettings AudioSettings,
        VideoSettings VideoSettings
    );

    public record VideoSettings(
        bool IsAvailable,
        bool IsHostEnabled,
        bool IsGuestEnabled
    );
}