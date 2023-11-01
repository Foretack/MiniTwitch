namespace MiniTwitch.Helix.Requests;

public readonly struct NewChatSettings
{
    public bool? EmoteMode { get; init; }
    public bool? FollowerMode { get; init; }
    public bool? NonModeratorChatDelay { get; init; }
    public bool? SlowMode { get; init; }
    public bool? SubscriberMode { get; init; }
    public bool? UniqueChatMode { get; init; }
    public int? FollowerModeDuration { get; init; }
    public int? NonModeratorChatDelayDuration { get; init; }
    public int? SlowModeWaitTime { get; init; }
}
