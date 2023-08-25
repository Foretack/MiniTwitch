using Microsoft.Extensions.Logging;

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
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnSub"/></item>
    /// <item><see cref="PubSubClient.OnSubGift"/></item>
    /// <item><see cref="PubSubClient.OnAnonSubGift"/></item>
    /// </list>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic SubscribeEvents(long channelId, string? overrideToken = null) => new($"channel-subscribe-events-v1.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnAutoModMessageCaught"/></item>
    /// </list>
    /// </summary>
    /// <param name="moderatorId">ID of the moderator observing the events</param>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic AutomodQueue(long moderatorId, long channelId, string? overrideToken = null) => new($"automod-queue.{moderatorId}.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnLowTrustChatMessage"/></item>
    /// <item><see cref="PubSubClient.OnLowTrustTreatmentUpdate"/></item>
    /// </list>
    /// </summary>
    /// <param name="moderatorId">ID of the moderator observing the events</param>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic LowTrustUsers(long moderatorId, long channelId, string? overrideToken = null) => new($"low-trust-users.{moderatorId}.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnUserTimedOut"/></item>
    /// <item><see cref="PubSubClient.OnUserBanned"/></item>
    /// <item><see cref="PubSubClient.OnUserUntimedOut"/></item>
    /// <item><see cref="PubSubClient.OnUserUnbanned"/></item>
    /// <item><see cref="PubSubClient.OnAliasRestrictionUpdate"/></item>
    /// </list>
    /// </summary>
    /// <param name="moderatorId">ID of the moderator observing the events</param>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic ModerationNotifications(long moderatorId, long channelId, string? overrideToken = null) => new($"user-moderation-notifications.{moderatorId}.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnTimedOut"/></item>
    /// <item><see cref="PubSubClient.OnBanned"/></item>
    /// <item><see cref="PubSubClient.OnUntimedOut"/></item>
    /// <item><see cref="PubSubClient.OnUnbanned"/></item>
    /// <item><see cref="PubSubClient.OnAliasRestrictionUpdate"/></item>
    /// </list>
    /// </summary>
    /// <param name="userId">ID of the user observing the events</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic ChatroomsUser(long userId, string? overrideToken = null) => new($"chatrooms-user-v1.{userId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnPredictionStarted"/></item>
    /// <item><see cref="PubSubClient.OnPredictionUpdate"/></item>
    /// <item><see cref="PubSubClient.OnPredictionWindowClosed"/></item>
    /// <item><see cref="PubSubClient.OnPredictionLocked"/></item>
    /// <item><see cref="PubSubClient.OnPredictionCancelled"/></item>
    /// <item><see cref="PubSubClient.OnPredictionEnded"/></item>
    /// </list>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the events in</param>
    /// <param name="overrideToken">Optional: An access token to override the provided token in <see cref="PubSubClient"/></param>
    public static Topic ChannelPredictions(long channelId, string? overrideToken = null) => new($"predictions-channel-v1.{channelId}") { OverrideToken = overrideToken };
    /// <summary>
    /// Events that can be triggered by this topic:
    /// <list type="bullet">
    /// <item><see cref="PubSubClient.OnModPinnedMessage"/></item>
    /// <item><see cref="PubSubClient.OnModPinnedMessageUpdated"/></item>
    /// <item><see cref="PubSubClient.OnModUnpinnedMessage"/></item>
    /// <item><see cref="PubSubClient.OnHypeChatMessagePinned"/></item>
    /// </list>
    /// </summary>
    /// <param name="channelId">ID of the channel to observe the events in</param>
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
