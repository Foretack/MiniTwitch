namespace MiniTwitch.PubSub.Models;

/// <summary>
/// Represents a PubSub topic
/// <para>Do not create an instance of this object. Use the methods in the static class '<see cref="Topics"/>' instead</para>
/// </summary>
public readonly record struct Topic(string Key)
{
    internal string? OverrideToken { get; init; } = null;

    /// <summary>
    /// Pipes topics together into a list
    /// </summary>
    public static List<Topic> operator |(Topic left, Topic right)
    {
        return new(4) { left, right };
    }
    /// <summary>
    /// Adds a topic to the list
    /// </summary>
    public static List<Topic> operator |(List<Topic> left, Topic right)
    {
        left.Add(right);
        return left;
    }
};

/// <summary>
/// A static class exposing supported PubSub topics
/// </summary>
public static class Topics
{
    // TODO: Use new bullet list format

    /// <summary>
    /// Triggers <see cref="PubSubClient.OnBitsEvent"/>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the bit events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic BitsEventsV1(long channelId, string? overrideToken = null) => new($"channel-bits-events-v1.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnBitsEvent"/>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the bit events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic BitsEventsV2(long channelId, string? overrideToken = null) => new($"channel-bits-events-v2.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnBitsBadgeUnlock"/>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the bit badge events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic BitsBadgeUnlock(long channelId, string? overrideToken = null) => new($"channel-bits-badge-unlocks.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnChannelPointsRedemption"/>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the channel point events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic ChannelPoints(long channelId, string? overrideToken = null) => new($"channel-points-channel-v1.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnSub"/>, <see cref="PubSubClient.OnSubGift"/> and <see cref="PubSubClient.OnAnonSubGift"/>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the subscribe events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic SubscribeEvents(long channelId, string? overrideToken = null) => new($"channel-subscribe-events-v1.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnAutoModMessageCaught"/>
    /// </summary>
    /// <param name="moderatorId">ID of the moderator that wants to observe the automod events</param>
    /// <param name="channelId">ID of the channel to observe the automod events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic AutomodQueue(long moderatorId, long channelId, string? overrideToken = null) => new($"automod-queue.{moderatorId}.{channelId}") { OverrideToken = overrideToken };
    // TODO: The paramaters of this are wrong. Check Twitch4J
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnLowTrustChatMessage"/>, <see cref="PubSubClient.OnLowTrustTreatmentMessage"/>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the low trust events in</param>
    /// <param name="moderatorId">ID of the moderator that wants to observe low trust user events</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic LowTrustUsers(long channelId, long moderatorId, string? overrideToken = null) => new($"low-trust-users.{channelId}.{moderatorId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnUserBanned"/>, <see cref="PubSubClient.OnUserUnbanned"/>, <see cref="PubSubClient.OnUserTimedOut"/> and <see cref="PubSubClient.OnUserUntimedOut"/>
    /// </summary>
    /// <param name="moderatorId">ID of the moderator that wants to observe the notifications</param>
    /// <param name="channelId">ID of the channel to observe the notifications in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic ModerationNotifications(long moderatorId, long channelId, string? overrideToken = null) => new($"user-moderation-notifications.{moderatorId}.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnBanned"/>, <see cref="PubSubClient.OnUnbanned"/>, <see cref="PubSubClient.OnTimedOut"/>, <see cref="PubSubClient.OnUntimedOut"/> and <see cref="PubSubClient.OnAliasRestrictionUpdate"/>
    /// </summary>
    /// <param name="userId">ID of the user that wants to observe chatroom events</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic ChatroomsUser(long userId, string? overrideToken = null) => new($"chatrooms-user-v1.{userId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnPredictionStarted"/>, <see cref="PubSubClient.OnPredictionUpdate"/>, <see cref="PubSubClient.OnPredictionLocked"/>, <see cref="PubSubClient.OnPredictionWindowClosed"/>, <see cref="PubSubClient.OnPredictionCancelled"/> and <see cref="PubSubClient.OnPredictionEnded"/>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe predictions in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic ChannelPredictions(long channelId, string? overrideToken = null) => new($"predictions-channel-v1.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Triggers <see cref="PubSubClient.OnModPinnedMessage"/>, <see cref="PubSubClient.OnModPinnedMessageUpdated"/>  and <see cref="PubSubClient.OnModUnpinnedMessage"/>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe pin events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic PinnedChatUpdates(long channelId, string? overrideToken = null) => new($"pinned-chat-updates-v1.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnStreamUp"/></item>
    /// <item><see cref="PubSubClient.OnStreamDown"/></item>
    /// <item><see cref="PubSubClient.OnCommercialBreak"/></item>
    /// <item><see cref="PubSubClient.OnViewerCountUpdate"/></item>
    /// </list>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic VideoPlayback(long channelId, string? overrideToken = null) => new($"video-playback-by-id.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnTitleChange"/></item>
    /// <item><see cref="PubSubClient.OnGameChange"/></item>
    /// </list>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic BroadcastSettingsUpdate(long channelId, string? overrideToken = null) => new($"broadcast-settings-update.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnUserBanned"/></item>
    /// <item><see cref="PubSubClient.OnUserTimedOut"/></item>
    /// <item><see cref="PubSubClient.OnUserUnbanned"/></item>
    /// <item><see cref="PubSubClient.OnUserUnbanned"/></item>
    /// </list>
    /// </summary>
    /// <param name="userId">ID of the user observing the events</param>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic ModeratorActions(long userId, long channelId, string? overrideToken = null) => new($"chat_moderator_actions.{userId}.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnPollCreated"/></item>
    /// <item><see cref="PubSubClient.OnPollUpdate"/></item>
    /// <item><see cref="PubSubClient.OnPollCompleted"/></item>
    /// <item><see cref="PubSubClient.OnPollArchived"/></item>
    /// </list>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic Polls(long channelId, string? overrideToken = null) => new($"polls.{channelId}");
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnChannelPointsRedemption"/></item>
    /// </list>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic CommunityChannelPoints(long channelId, string? overrideToken = null) => new($"community-points-channel-v1.{channelId}");
}
