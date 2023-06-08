namespace MiniTwitch.PubSub.Models;

public readonly record struct Topic(string Key)
{
    public static List<Topic> operator |(Topic left, Topic right)
    {
        return new() { left, right };
    }
    public static List<Topic> operator |(List<Topic> left, Topic right)
    {
        left.Add(right); 
        return left;
    }
};

public static class Topics
{
    public static Topic BitsEventsV1(long channelId) => new($"channel-bits-events-v1.{channelId}");

    public static Topic BitsEventsV2(long channelId) => new($"channel-bits-events-v2.{channelId}");

    public static Topic BitsBadgeUnlock(long channelId) => new($"channel-bits-badge-unlocks.{channelId}");

    public static Topic ChannelPoints(long channelId) => new($"channel-points-channel-v1.{channelId}");

    public static Topic SubscribeEvents(long channelId) => new($"channel-subscribe-events-v1.{channelId}");

    public static Topic AutomodQueue(long moderatorId, long channelId) => new($"automod-queue.{moderatorId}.{channelId}");

    public static Topic ModeratorActions(long userId, long channelId) => new($"chat_moderator_actions.{userId}.{channelId}");

    public static Topic LowTrustUsers(long channelId, long suspiciousUserId) => new($"low-trust-users.{channelId}.{suspiciousUserId}");

    public static Topic ModerationNotifications(long currentUserId, long channelId) => new($"user-moderation-notifications.{currentUserId}.{channelId}");

    public static Topic ChatroomsUser(long userId) => new($"chatrooms-user-v1.{userId}");

    public static Topic ChannelPredictions(long channelId) => new($"predictions-channel-v1.{channelId}");
}
