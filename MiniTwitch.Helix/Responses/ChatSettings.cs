using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChatSettings : BaseResponse<ChatSettings.Settings>
{
    public record Settings(
        long BroadcasterId,
        bool SlowMode,
        int? SlowModeWaitTime,
        bool FollowerMode,
        int? FollowerModeDuration,
        bool SubscriberMode,
        bool EmoteMode,
        bool UniqueChatMode,
        bool NonModeratorChatDelay,
        int? NonModeratorChatDelayDuration
    );
}