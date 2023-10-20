using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class GuestStarInvites : BaseResponse<GuestStarInvites.Invite>
{
    public record Invite(
        [property: JsonPropertyName("user_id")] long UserId,
        [property: JsonPropertyName("invited_at")] DateTime InvitedAt,
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("is_audio_enabled")] bool IsAudioEnabled,
        [property: JsonPropertyName("is_video_enabled")] bool IsVideoEnabled,
        [property: JsonPropertyName("is_audio_available")] bool IsAudioAvailable,
        [property: JsonPropertyName("is_video_available")] bool IsVideoAvailable
    );

}