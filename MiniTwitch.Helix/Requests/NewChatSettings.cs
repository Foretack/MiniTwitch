namespace MiniTwitch.Helix.Requests;

public class NewChatSettings
{
    public bool? EmoteMode { get; }
    public bool? FollowerMode { get; }
    public bool? NonModeratorChatDelay { get; }
    public bool? SlowMode { get; }
    public bool? SubscriberMode { get; }
    public bool? UniqueChatMode { get; }
    public int? FollowerModeDuration { get; }
    public int? NonModeratorChatDelayDuration { get; }
    public int? SlowModeWaitTime { get; }

    public NewChatSettings(
        bool? emoteMode = null,
        bool? followerMode = null,
        bool? nonModeratorChatDelay = null,
        bool? slowMode = null,
        bool? subscriberMode = null,
        bool? uniqueChatMode = null,
        int? followerModeDuration = null,
        int? nonModeratorChatDelayDuration = null,
        int? slowModeWaitTime = null
    )
    {
        this.EmoteMode = emoteMode;
        this.FollowerMode = followerMode;
        this.NonModeratorChatDelay = nonModeratorChatDelay;
        this.SlowMode = slowMode;
        this.SubscriberMode = subscriberMode;
        this.UniqueChatMode = uniqueChatMode;
        this.FollowerModeDuration = followerModeDuration;
        this.NonModeratorChatDelayDuration = nonModeratorChatDelayDuration;
        this.SlowModeWaitTime = slowModeWaitTime;
    }
}
