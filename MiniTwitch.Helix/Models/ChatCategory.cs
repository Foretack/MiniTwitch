using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class ChatCategory
{
    private readonly AllCategories _all;

    internal ChatCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Chatters>> GetChatters(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChatters(broadcasterId, first, cancellationToken);

    public Task<HelixResult<Emotes>> GetChannelEmotes(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelEmotes(broadcasterId, cancellationToken);

    public Task<HelixResult<Emotes>> GetGlobalEmotes(
        CancellationToken cancellationToken = default)
    => _all.GetGlobalEmotes(cancellationToken);

    public Task<HelixResult<EmoteSets>> GetEmoteSets(
        string emoteSetId,
        CancellationToken cancellationToken = default)
    => _all.GetEmoteSets(emoteSetId, cancellationToken);

    public Task<HelixResult<EmoteSets>> GetEmoteSets(
        IEnumerable<string> emoteSetIds,
        CancellationToken cancellationToken = default)
    => _all.GetEmoteSets(emoteSetIds, cancellationToken);

    public Task<HelixResult<ChatBadges>> GetChannelChatBadges(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelChatBadges(broadcasterId, cancellationToken);

    public Task<HelixResult<ChatBadges>> GetGlobalChatBadges(
        CancellationToken cancellationToken = default)
    => _all.GetGlobalChatBadges(cancellationToken);

    public Task<HelixResult<ChatSettings>> GetChatSettings(
        long broadcasterId,
        long? moderatorId = null,
        CancellationToken cancellationToken = default)
    => _all.GetChatSettings(broadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult<ChatSettings>> UpdateChatSettings(
        long broadcasterId,
        NewChatSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChatSettings(broadcasterId, body, cancellationToken);

    public Task<HelixResult> SendChatAnnouncement(
        long broadcasterId,
        Announcement body,
        CancellationToken cancellationToken = default)
    => _all.SendChatAnnouncement(broadcasterId, body, cancellationToken);

    public Task<HelixResult> SendAShoutout(
        long fromBroadcasterId,
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    => _all.SendAShoutout(fromBroadcasterId, toBroadcasterId, cancellationToken);

    public Task<HelixResult<UsersChatColor>> GetUserChatColor(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.GetUserChatColor(userId, cancellationToken);

    public Task<HelixResult<UsersChatColor>> GetUserChatColor(
        IEnumerable<long> userIds,
        CancellationToken cancellationToken = default)
    => _all.GetUserChatColor(userIds, cancellationToken);

    public Task<HelixResult> UpdateUserChatColor(
        ChatColor color,
        CancellationToken cancellationToken = default)
    => _all.UpdateUserChatColor(color, cancellationToken);

    public Task<HelixResult> UpdateUserChatColor(
        string hexColor,
        CancellationToken cancellationToken = default)
    => _all.UpdateUserChatColor(hexColor, cancellationToken);

    public Task<HelixResult<SentMessage>> SendChatMessage(
        ChatMessage message,
        CancellationToken cancellationToken = default)
    => _all.SendChatMessage(message, cancellationToken);

    public Task<HelixResult<UserEmotes>> GetUserEmotes(
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    => _all.GetUserEmotes(broadcasterId, cancellationToken);
}
