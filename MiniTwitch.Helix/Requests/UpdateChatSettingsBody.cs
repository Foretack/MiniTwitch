using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdateChatSettingsBody : IJsonObject
{
    public bool? EmoteMode { get; init; }
    public bool? FollowerMode { get; init; }
    public bool? NonModeratorChatDelay { get; init; }
    public bool? SlowMode { get; init; }
    public bool? SubscriberMode { get; init; }
    public bool? UniqueChatMode { get; init; }
    public int? FollowerModeDuration { get; init; }
    public int? NonModeratorChatDelayDuration { get; init; }
    public int? SlowModeDuration { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        emote_mode = EmoteMode,
        follower_mode = FollowerMode,
        follower_mode_duration = FollowerModeDuration,
        non_moderator_chat_delay = NonModeratorChatDelay,
        non_moderator_chat_delay_duration = NonModeratorChatDelayDuration,
        slow_mode = SlowMode,
        slow_mode_wait_time = SlowModeDuration,
        subscriber_mode = SubscriberMode,
        unique_chat_mode = UniqueChatMode,
    };
}
