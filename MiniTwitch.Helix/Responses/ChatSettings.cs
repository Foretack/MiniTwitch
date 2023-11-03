using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChatSettings : BaseResponse<ChatSettings.Settings>
{
    public record Settings(
        [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
        [property: JsonPropertyName("slow_mode")] bool SlowMode,
        [property: JsonPropertyName("slow_mode_wait_time")] int SlowModeWaitTime,
        [property: JsonPropertyName("follower_mode")] bool FollowerMode,
        [property: JsonPropertyName("follower_mode_duration")] int FollowerModeDuration,
        [property: JsonPropertyName("subscriber_mode")] bool SubscriberMode,
        [property: JsonPropertyName("emote_mode")] bool EmoteMode,
        [property: JsonPropertyName("unique_chat_mode")] bool UniqueChatMode,
        [property: JsonPropertyName("non_moderator_chat_delay")] bool NonModeratorChatDelay,
        [property: JsonPropertyName("non_moderator_chat_delay_duration")] int NonModeratorChatDelayDuration
    );
}