namespace MiniTwitch.PubSub.Models;

public readonly record struct Topic(string Key)
{
    internal string? OverrideToken { get; init; } = null;

    public static List<Topic> operator |(Topic left, Topic right)
    {
        return new() { left, right };
    }
    public static List<Topic> operator |(List<Topic> left, Topic right)
    {
        left.Add(right);
        return left;
    }
    public static implicit operator Topic(string key) => new(key);
};

public static class Topics
{
    public static Topic BitsEventsV1(long channelId, string? overrideToken = null) => new($"channel-bits-events-v1.{channelId}") { OverrideToken = overrideToken };

    public static Topic BitsEventsV2(long channelId, string? overrideToken = null) => new($"channel-bits-events-v2.{channelId}") { OverrideToken = overrideToken };

    public static Topic BitsBadgeUnlock(long channelId, string? overrideToken = null) => new($"channel-bits-badge-unlocks.{channelId}") { OverrideToken = overrideToken };

    public static Topic ChannelPoints(long channelId, string? overrideToken = null) => new($"channel-points-channel-v1.{channelId}") { OverrideToken = overrideToken };

    public static Topic SubscribeEvents(long channelId, string? overrideToken = null) => new($"channel-subscribe-events-v1.{channelId}") { OverrideToken = overrideToken };

    public static Topic AutomodQueue(long moderatorId, long channelId, string? overrideToken = null) => new($"automod-queue.{moderatorId}.{channelId}") { OverrideToken = overrideToken };

    public static Topic LowTrustUsers(long channelId, long suspiciousUserId, string? overrideToken = null) => new($"low-trust-users.{channelId}.{suspiciousUserId}") { OverrideToken = overrideToken };

    public static Topic ModerationNotifications(long currentUserId, long channelId, string? overrideToken = null) => new($"user-moderation-notifications.{currentUserId}.{channelId}") { OverrideToken = overrideToken };

    public static Topic ChatroomsUser(long userId, string? overrideToken = null) => new($"chatrooms-user-v1.{userId}") { OverrideToken = overrideToken };

    public static Topic ChannelPredictions(long channelId, string? overrideToken = null) => new($"predictions-channel-v1.{channelId}") { OverrideToken = overrideToken };

    public static Topic PinnedChatUpdates(long channelId, string? overrideToken = null) => new($"pinned-chat-updates-v1.{channelId}") { OverrideToken = overrideToken };

    public static Topic VideoPlayback(long channelId, string? overrideToken = null) => new($"video-playback-by-id.{channelId}") { OverrideToken = overrideToken };

    public static Topic BroadcastSettingsUpdate(long channelId, string? overrideToken = null) => new($"broadcast-settings-update.{channelId}") { OverrideToken = overrideToken };

    public static Topic ModeratorActions(long userId, long channelId, string? overrideToken = null) => new($"chat_moderator_actions.{userId}.{channelId}") { OverrideToken = overrideToken };

    public static Topic Polls(long channelId, string? overrideToken = null) => new($"polls.{channelId}");

    public static Topic CommunityChannelPoints(long channelId, string? overrideToken = null) => new($"community-points-channel-v1.{channelId}");
}
