using Microsoft.Extensions.Logging;
using MiniTwitch.Common;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix;

/// <summary>
/// Wraps all Helix endpoints and exposes them directly as methods.
/// </summary>
public class HelixWrapper
{
    /// <summary>
    /// The default logger for <see cref="HelixWrapper"/>, only used when <see cref="ILogger"/> is not provided in the constructor
    /// <para>Can be toggled with <see cref="DefaultMiniTwitchLogger{T}.Enabled"/></para>
    /// </summary>
    public DefaultMiniTwitchLogger<HelixWrapper> DefaultLogger => _all.ApiClient.Logger;
    /// <summary>
    /// Gets the user ID associated with this <see cref="HelixWrapper"/> instance
    /// </summary>
    public long UserId { get; }

    private readonly AllCategories _all;

    public HelixWrapper(
        string accessToken, 
        long userId,
        ILogger? logger = null, 
        string helixBaseUrl = "https://api.twitch.tv/helix", 
        string tokenValidationUrl = "https://id.twitch.tv/oauth2/validate")
    {
        _all = new(new HelixApiClient(accessToken, userId, logger, tokenValidationUrl), helixBaseUrl);
        this.UserId = userId;
    }

    public Task<HelixResult<Commercial>> StartCommercial(
        NewCommercial body,
        CancellationToken cancellationToken = default)
    => _all.StartCommercial(body, cancellationToken);

    public Task<HelixResult<ExtensionAnalytics>> GetExtensionAnalytics(
        string? extensionId = null,
        AnalyticsType? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionAnalytics(extensionId, type, startedAt, endedAt, first, cancellationToken);

    public Task<HelixResult<GameAnalytics>> GetGameAnalytics(
        string? gameId = null,
        AnalyticsType? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetGameAnalytics(gameId, type, startedAt, endedAt, first, cancellationToken);

    public Task<HelixResult<BitsLeaderboard>> GetBitsLeaderboard(
        int? count = null,
        BitsLeaderboardPeriod? period = null,
        DateTime? startedAt = null,
        long? UserId = null,
        CancellationToken cancellationToken = default)
    => _all.GetBitsLeaderboard(count, period, startedAt, UserId, cancellationToken);

    public Task<HelixResult<Cheermotes>> GetCheermotes(
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    => _all.GetCheermotes(broadcasterId, cancellationToken);

    public Task<HelixResult<ExtensionTransactions>> GetExtensionTransactions(
        string extensionId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionTransactions(extensionId, id, first, cancellationToken);

    public Task<HelixResult<ExtensionTransactions>> GetExtensionTransactions(
        string extensionId,
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionTransactions(extensionId, ids, first, cancellationToken);

    public Task<HelixResult<ChannelsInformation>> GetChannelInformation(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelInformation(broadcasterId, cancellationToken);

    public Task<HelixResult<ChannelsInformation>> GetChannelInformation(
        IEnumerable<long> broadcasterIds,
        CancellationToken cancellationToken = default)
    => _all.GetChannelInformation(broadcasterIds, cancellationToken);

    public Task<HelixResult> ModifyChannelInformation(
        NewChannelInformation body,
        CancellationToken cancellationToken = default)
    => _all.ModifyChannelInformation(body, cancellationToken);

    public Task<HelixResult<ChannelEditors>> GetChannelEditors(
        CancellationToken cancellationToken = default)
    => _all.GetChannelEditors(cancellationToken);

    public Task<HelixResult<FollowedChannels>> GetFollowedChannels(
        long? broadcasterId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetFollowedChannels(broadcasterId, first, cancellationToken);

    public Task<HelixResult<ChannelFollowers>> GetChannelFollowers(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChannelFollowers(userId, first, cancellationToken);

    public Task<HelixResult<CustomReward>> CreateCustomReward(NewCustomReward body, CancellationToken cancellationToken = default) => _all.CreateCustomReward(body, cancellationToken);

    public Task<HelixResult> DeleteCustomReward(
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteCustomReward(id, cancellationToken);

    public Task<HelixResult<CustomReward>> GetCustomReward(
        string? id = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    => _all.GetCustomReward(id, onlyManageableRewards, cancellationToken);

    public Task<HelixResult<CustomReward>> GetCustomReward(
        IEnumerable<string>? ids = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    => _all.GetCustomReward(ids, onlyManageableRewards, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        string rewardId,
        RewardRedemptionStatus status,
        string? id = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCustomRewardRedemption(rewardId, status, id, sort, first, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        string rewardId,
        RewardRedemptionStatus status,
        IEnumerable<string>? ids = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCustomRewardRedemption(rewardId, status, ids, sort, first, cancellationToken);

    public Task<HelixResult<CustomReward>> UpdateCustomReward(
        string id,
        UpdatedCustomReward body,
        CancellationToken cancellationToken = default)
    => _all.UpdateCustomReward(id, body, cancellationToken);

    public Task<HelixResult<CustomRewardRedemption>> UpdateRedemptionStatus(
        string id,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    => _all.UpdateRedemptionStatus(id, rewardId, status, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> UpdateRedemptionStatus(
        IEnumerable<string> ids,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    => _all.UpdateRedemptionStatus(ids, rewardId, status, cancellationToken);

    public Task<HelixResult<CharityCampaign>> GetCharityCampaign(CancellationToken cancellationToken = default)
    => _all.GetCharityCampaign(cancellationToken);

    public Task<HelixResult<CharityCampaignDonations>> GetCharityCampaignDonations(
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCharityCampaignDonations(first, cancellationToken);

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

    public Task<HelixResult<BlockList>> GetUserBlockList(
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetUserBlockList(first, cancellationToken);

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

    public Task<HelixResult<Clip>> CreateClip(
        long broadcasterId,
        bool? hasDelay = null,
        CancellationToken cancellationToken = default)
    => _all.CreateClip(broadcasterId, hasDelay, cancellationToken);

    public Task<HelixResult<Clips>> GetClips(
        long broadcasterId,
        long gameId,
        string id,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        bool? isFeatured = null,
        CancellationToken cancellationToken = default)
    => _all.GetClips(broadcasterId, gameId, id, startedAt, endedAt, first, isFeatured, cancellationToken);

    public Task<HelixResult<Clips>> GetClips(
        long broadcasterId,
        long gameId,
        IEnumerable<string> ids,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        bool? isFeatured = null,
        CancellationToken cancellationToken = default)
    => _all.GetClips(broadcasterId, gameId, ids, startedAt, endedAt, first, isFeatured, cancellationToken);

    public Task<HelixResult<ContentClassificationLabels>> GetContentClassificationLabels(
        LabelLocale? locale = null,
        CancellationToken cancellationToken = default)
    => _all.GetContentClassificationLabels(locale, cancellationToken);

    public Task<HelixResult<DropsEntitlements>> GetDropsEntitlements(
        string? id = null,
        long? userId = null,
        string? gameId = null,
        FulfillmentStatus? fulfillmentStatus = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetDropsEntitlements(id, userId, gameId, fulfillmentStatus, first, cancellationToken);

    public Task<HelixResult<DropsEntitlements>> GetDropsEntitlements(
        IEnumerable<string>? ids = null,
        long? userId = null,
        string? gameId = null,
        FulfillmentStatus? fulfillmentStatus = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetDropsEntitlements(ids, userId, gameId, fulfillmentStatus, first, cancellationToken);

    public Task<HelixResult<UpdatedDropsEntitlements>> UpdateDropsEntitlements(
        IEnumerable<string>? entitlementIds = null,
        FulfillmentStatus? fulfillmentStatus = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateDropsEntitlements(entitlementIds, fulfillmentStatus, cancellationToken);

    public Task<HelixResult<Responses.ExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        ConfigSegmentType segment,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionConfigurationSegment(extensionId, segment, broadcasterId, cancellationToken);

    public Task<HelixResult<Responses.ExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        IEnumerable<ConfigSegmentType> segments,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionConfigurationSegment(extensionId, segments, broadcasterId, cancellationToken);

    public Task<HelixResult> SetExtensionConfigurationSegment(
        ConfigurationSegment body,
        CancellationToken cancellationToken = default)
    => _all.SetExtensionConfigurationSegment(body, cancellationToken);

    public Task<HelixResult> SetExtensionRequiredConfiguration(
        long broadcasterId,
        ExtensionRequiredConfiguration body,
        CancellationToken cancellationToken = default)
    => _all.SetExtensionRequiredConfiguration(broadcasterId, body, cancellationToken);

    public Task<HelixResult> SendExtensionPubSubMessage(
        ExtensionPubSubMessage body,
        CancellationToken cancellationToken = default)
    => _all.SendExtensionPubSubMessage(body, cancellationToken);

    public Task<HelixResult<ExtensionLiveChannels>> GetExtensionLiveChannels(
        string extensionId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionLiveChannels(extensionId, first, cancellationToken);

    public Task<HelixResult<ExtensionSecrets>> GetExtensionSecrets(
        string extensionId,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionSecrets(extensionId, cancellationToken);

    public Task<HelixResult<ExtensionSecrets>> CreateExtensionSecret(
        string extensionId,
        int? delay = null,
        CancellationToken cancellationToken = default)
    => _all.CreateExtensionSecret(extensionId, delay, cancellationToken);

    public Task<HelixResult> SendExtensionChatMessage(
        long broadcasterId,
        ExtensionChatMessage body,
        CancellationToken cancellationToken = default)
    => _all.SendExtensionChatMessage(broadcasterId, body, cancellationToken);

    public Task<HelixResult<ChannelExtensions>> GetExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensions(extensionId, extensionVersion, cancellationToken);

    public Task<HelixResult<ReleasedExtensions>> GetReleasedExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    => _all.GetReleasedExtensions(extensionId, extensionVersion, cancellationToken);

    public Task<HelixResult<ExtensionBitsProducts>> GetExtensionBitsProducts(
        bool? shouldIncludeAll = null,
        CancellationToken cancellationToken = default)
    => _all.GetExtensionBitsProducts(shouldIncludeAll, cancellationToken);

    public Task<HelixResult<ExtensionBitsProducts>> UpdateExtensionBitsProduct(
        UpdatedBitsProduct body,
        CancellationToken cancellationToken = default)
    => _all.UpdateExtensionBitsProduct(body, cancellationToken);

    public Task<HelixResult<CreatedSubscription>> CreateEventSubSubscription(
        NewSubscription body,
        CancellationToken cancellationToken = default)
    => _all.CreateEventSubSubscription(body, cancellationToken);

    public Task<HelixResult> DeleteEventSubSubscription(
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteEventSubSubscription(id, cancellationToken);

    public Task<HelixResult<EventSubSubscriptions>> GetEventSubSubscriptions(
        EventSubStatus? status = null,
        string? type = null,
        long? userId = null,
        CancellationToken cancellationToken = default)
    => _all.GetEventSubSubscriptions(status, type, userId, cancellationToken);

    public Task<HelixResult<Games>> GetTopGames(
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetTopGames(first, cancellationToken);

    public Task<HelixResult<Games>> GetGames(
        string? id = null,
        string? name = null,
        string? igdbId = null,
        CancellationToken cancellationToken = default)
    => _all.GetGames(id, name, igdbId, cancellationToken);

    public Task<HelixResult<Games>> GetGames(
        IEnumerable<string>? ids = null,
        IEnumerable<string>? names = null,
        IEnumerable<string>? igdbIds = null,
        CancellationToken cancellationToken = default)
    => _all.GetGames(ids, names, igdbIds, cancellationToken);

    public Task<HelixResult<CreatorGoals>> GetCreatorGoals(
        CancellationToken cancellationToken = default)
    => _all.GetCreatorGoals(cancellationToken);

    public Task<HelixResult<ChannelGuestStarSettings>> GetChannelGuestStarSettings(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelGuestStarSettings(broadcasterId, cancellationToken);

    public Task<HelixResult> UpdateChannelGuestStarSettings(
        NewGuestStarSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelGuestStarSettings(body, cancellationToken);

    public Task<HelixResult<GuestStarSession>> GetGuestStarSession(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetGuestStarSession(broadcasterId, cancellationToken);

    public Task<HelixResult<GuestStarSession>> CreateGuestStarSession(
        CancellationToken cancellationToken = default)
    => _all.CreateGuestStarSession(cancellationToken);

    public Task<HelixResult<GuestStarSession>> EndGuestStarSession(
        string sessionId,
        CancellationToken cancellationToken = default)
    => _all.EndGuestStarSession(sessionId, cancellationToken);

    public Task<HelixResult<GuestStarInvites>> GetGuestStarInvites(
        long broadcasterId,
        string sessionId,
        CancellationToken cancellationToken = default)
    => _all.GetGuestStarInvites(broadcasterId, sessionId, cancellationToken);

    public Task<HelixResult> SendGuestStarInvite(
        long broadcasterId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    => _all.SendGuestStarInvite(broadcasterId, sessionId, guestId, cancellationToken);

    public Task<HelixResult> DeleteGuestStarInvite(
        long broadcasterId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    => _all.DeleteGuestStarInvite(broadcasterId, sessionId, guestId, cancellationToken);

    public Task<HelixResult> AssignGuestStarSlot(
        long broadcasterId,
        string sessionId,
        long guestId,
        string slotId,
        CancellationToken cancellationToken = default)
    => _all.AssignGuestStarSlot(broadcasterId, sessionId, guestId, slotId, cancellationToken);

    public Task<HelixResult> UpdateGuestStarSlot(
        long broadcasterId,
        string sessionId,
        string sourceSlotId,
        string? destinationSlotId = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateGuestStarSlot(broadcasterId, sessionId, sourceSlotId, destinationSlotId, cancellationToken);

    public Task<HelixResult> DeleteGuestStarSlot(
        long broadcasterId,
        string sessionId,
        long guestId,
        string slotId,
        string? shouldReinviteGuest = null,
        CancellationToken cancellationToken = default)
    => _all.DeleteGuestStarSlot(broadcasterId, sessionId, guestId, slotId, shouldReinviteGuest, cancellationToken);

    public Task<HelixResult> UpdateGuestStarSlotSettings(
        long broadcasterId,
        string sessionId,
        string slotId,
        bool? isAudioEnabled = null,
        bool? isVideoEnabled = null,
        bool? isLive = null,
        int? volume = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateGuestStarSlotSettings(broadcasterId, sessionId, slotId, isAudioEnabled, isVideoEnabled, isLive, volume, cancellationToken);

    public Task<HelixResult<HypeTrainEvents>> GetHypeTrainEvents(
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetHypeTrainEvents(first, cancellationToken);

    public Task<HelixResult<AutoModStatus>> CheckAutoModStatus(
        MessageToCheck body,
        CancellationToken cancellationToken = default)
    => _all.CheckAutoModStatus(body, cancellationToken);

    public Task<HelixResult> ManageHeldAutoModMessages(
        string msgId,
        string action,
        CancellationToken cancellationToken = default)
    => _all.ManageHeldAutoModMessages(msgId, action, cancellationToken);

    public Task<HelixResult<AutoModSettings>> GetAutoModSettings(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetAutoModSettings(broadcasterId, cancellationToken);

    public Task<HelixResult<AutoModSettings>> UpdateAutoModSettings(
        long broadcasterId,
        NewAutoModSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateAutoModSettings(broadcasterId, body, cancellationToken);

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBannedUsers(userId, first, cancellationToken);

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBannedUsers(userIds, first, cancellationToken);

    public Task<HelixResult<BannedUser>> BanUser(
        long broadcasterId,
        UserToBan body,
        CancellationToken cancellationToken = default)
    => _all.BanUser(broadcasterId, body, cancellationToken);

    public Task<HelixResult> UnbanUser(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.UnbanUser(broadcasterId, userId, cancellationToken);

    public Task<HelixResult<BlockedTerms>> GetBlockedTerms(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBlockedTerms(broadcasterId, first, cancellationToken);

    public Task<HelixResult<BlockedTerms>> AddBlockedTerm(
        long broadcasterId,
        string text,
        CancellationToken cancellationToken = default)
    => _all.AddBlockedTerm(broadcasterId, text, cancellationToken);

    public Task<HelixResult> RemoveBlockedTerm(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    => _all.RemoveBlockedTerm(broadcasterId, id, cancellationToken);

    public Task<HelixResult> DeleteChatMessages(
        long broadcasterId,
        string? messageId = null,
        CancellationToken cancellationToken = default)
    => _all.DeleteChatMessages(broadcasterId, messageId, cancellationToken);

    public Task<HelixResult<Moderators>> GetModerators(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModerators(userId, first, cancellationToken);

    public Task<HelixResult<Moderators>> GetModerators(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModerators(userIds, first, cancellationToken);

    public Task<HelixResult> AddChannelModerator(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.AddChannelModerator(userId, cancellationToken);

    public Task<HelixResult> RemoveChannelModerator(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.RemoveChannelModerator(userId, cancellationToken);

    public Task<HelixResult<VIPs>> GetVIPs(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVIPs(userId, first, cancellationToken);

    public Task<HelixResult<VIPs>> GetVIPs(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVIPs(userIds, first, cancellationToken);

    public Task<HelixResult> AddChannelVIP(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.AddChannelVIP(userId, cancellationToken);

    public Task<HelixResult> RemoveChannelVIP(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.RemoveChannelVIP(userId, cancellationToken);

    public Task<HelixResult<ShieldModeStatus>> UpdateShieldModeStatus(
        long broadcasterId,
        bool isActive,
        CancellationToken cancellationToken = default)
    => _all.UpdateShieldModeStatus(broadcasterId, isActive, cancellationToken);

    public Task<HelixResult<ShieldModeStatus>> GetShieldModeStatus(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetShieldModeStatus(broadcasterId, cancellationToken);

    public Task<HelixResult<Polls>> GetPolls(
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPolls(id, first, cancellationToken);

    public Task<HelixResult<Polls>> GetPolls(
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPolls(ids, first, cancellationToken);

    public Task<HelixResult<Poll>> CreatePoll(
        NewPoll body,
        CancellationToken cancellationToken = default)
    => _all.CreatePoll(body, cancellationToken);

    public Task<HelixResult<Poll>> EndPoll(
        string id,
        string status,
        CancellationToken cancellationToken = default)
    => _all.EndPoll(id, status, cancellationToken);

    public Task<HelixResult<Predictions>> GetPredictions(
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPredictions(id, first, cancellationToken);

    public Task<HelixResult<Predictions>> GetPredictions(
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPredictions(ids, first, cancellationToken);

    public Task<HelixResult<Prediction>> CreatePrediction(
        NewPrediction body,
        CancellationToken cancellationToken = default)
    => _all.CreatePrediction(body, cancellationToken);

    public Task<HelixResult<Prediction>> EndPrediction(
        PredictionToEnd body,
        CancellationToken cancellationToken = default)
    => _all.EndPrediction(body, cancellationToken);

    public Task<HelixResult<Raid>> StartARaid(
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    => _all.StartRaid(toBroadcasterId, cancellationToken);

    public Task<HelixResult> CancelARaid(
        CancellationToken cancellationToken = default)
    => _all.CancelRaid(cancellationToken);

    public Task<HelixResult<StreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        string? id = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChannelStreamSchedule(broadcasterId, id, startTime, first, cancellationToken);

    public Task<HelixResult<StreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChannelStreamSchedule(broadcasterId, ids, startTime, first, cancellationToken);

    public Task<HelixResult> UpdateChannelStreamSchedule(
        bool? isVacationEnabled = null,
        DateTime? vacationStartTime = null,
        DateTime? vacationEndTime = null,
        string? timezone = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelStreamSchedule(isVacationEnabled, vacationStartTime, vacationEndTime, timezone, cancellationToken);

    public Task<HelixResult<ScheduleSegment>> CreateChannelStreamScheduleSegment(
        NewScheduleSegment body,
        CancellationToken cancellationToken = default)
    => _all.CreateChannelStreamScheduleSegment(body, cancellationToken);

    public Task<HelixResult<Responses.UpdatedScheduleSegment>> UpdateChannelStreamScheduleSegment(
        string id,
        Requests.UpdatedScheduleSegment Body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelStreamScheduleSegment(id, Body, cancellationToken);

    public Task<HelixResult> DeleteChannelStreamScheduleSegment(
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteChannelStreamScheduleSegment(id, cancellationToken);

    public Task<HelixResult<Categories>> SearchCategories(
        string query,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.SearchCategories(query, first, cancellationToken);

    public Task<HelixResult<Channels>> SearchChannels(
        string query,
        bool? liveOnly = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.SearchChannels(query, liveOnly, first, cancellationToken);

    public Task<HelixResult<StreamKey>> GetStreamKey(CancellationToken cancellationToken = default)
    => _all.GetStreamKey(cancellationToken);

    public Task<HelixResult<Streams>> GetStreams(
        long? userId = null,
        string? userLogin = null,
        string? gameId = null,
        StreamTypes? type = null,
        string? language = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetStreams(userId, userLogin, gameId, type, language, first, cancellationToken);

    public Task<HelixResult<Streams>> GetStreams(
        IEnumerable<long>? userIds = null,
        IEnumerable<string>? userLogins = null,
        IEnumerable<string>? gameIds = null,
        StreamTypes? type = null,
        IEnumerable<string>? languages = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetStreams(userIds, userLogins, gameIds, type, languages, first, cancellationToken);

    public Task<HelixResult<FollowedStreams>> GetFollowedStreams(
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetFollowedStreams(first, cancellationToken);

    public Task<HelixResult<StreamMarker>> CreateStreamMarker(
        string? description = null,
        CancellationToken cancellationToken = default)
    => _all.CreateStreamMarker(description, cancellationToken);

    public Task<HelixResult<StreamMarkers>> GetStreamMarkers(
        string? videoId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetStreamMarkers(videoId, first, cancellationToken);

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBroadcasterSubscriptions(userId, first, cancellationToken);

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBroadcasterSubscriptions(userIds, first, cancellationToken);

    public Task<HelixResult<UserSubscription>> CheckUserSubscription(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.CheckUserSubscription(broadcasterId, cancellationToken);

    public Task<HelixResult<ChannelTeams>> GetChannelTeams(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelTeams(broadcasterId, cancellationToken);

    public Task<HelixResult<Teams>> GetTeams(
        string name,
        string id,
        CancellationToken cancellationToken = default)
    => _all.GetTeams(name, id, cancellationToken);

    public Task<HelixResult<Users>> GetUsers(
        long? id = null,
        string? login = null,
        CancellationToken cancellationToken = default)
    => _all.GetUsers(id, login, cancellationToken);

    public Task<HelixResult<Users>> GetUsers(
        IEnumerable<long>? id = null,
        IEnumerable<string>? login = null,
        CancellationToken cancellationToken = default)
    => _all.GetUsers(id, login, cancellationToken);

    public Task<HelixResult<UpdatedUser>> UpdateUser(
        string? description = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateUser(description, cancellationToken);

    public Task<HelixResult> BlockUser(
        long targetUserId,
        string? sourceContext = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    => _all.BlockUser(targetUserId, sourceContext, reason, cancellationToken);

    public Task<HelixResult> UnblockUser(
        long targetUserId,
        CancellationToken cancellationToken = default)
    => _all.UnblockUser(targetUserId, cancellationToken);

    public Task<HelixResult<UserExtensions>> GetUserExtensions(
        CancellationToken cancellationToken = default)
    => _all.GetUserExtensions(cancellationToken);

    public Task<HelixResult<ActiveExtensions>> GetUserActiveExtensions(CancellationToken cancellationToken = default)
    => _all.GetUserActiveExtensions(cancellationToken);

    public Task<HelixResult<Videos>> GetVideos(
        string? id = null,
        long? userId = null,
        string? gameId = null,
        string? language = null,
        VideoPeriod? period = null,
        VideoSortMethod? sort = null,
        VideoType? type = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVideos(id, userId, gameId, language, period, sort, type, first, cancellationToken);

    public Task<HelixResult<Videos>> GetVideos(
        IEnumerable<string>? ids = null,
        long? userId = null,
        string? gameId = null,
        string? language = null,
        VideoPeriod? period = null,
        VideoSortMethod? sort = null,
        VideoType? type = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVideos(ids, userId, gameId, language, period, sort, type, first, cancellationToken);

    public Task<HelixResult> DeleteVideos(
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteVideos(id, cancellationToken);

    public Task<HelixResult> DeleteVideos(
        IEnumerable<string> ids,
        CancellationToken cancellationToken = default)
    => _all.DeleteVideos(ids, cancellationToken);

    public Task<HelixResult> SendWhisper(
        long toUserId,
        string message,
        CancellationToken cancellationToken = default)
    => _all.SendWhisper(toUserId, message, cancellationToken);

    public Task<HelixResult<AdSchedule>> GetAdSchedule(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetAdSchedule(broadcasterId, cancellationToken);

    public Task<HelixResult<SnoozedAd>> SnoozeNextAd(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.SnoozeNextAd(broadcasterId, cancellationToken);

    public Task<HelixResult<ChatBadges>> GetChannelChatBadges(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelChatBadges(broadcasterId, cancellationToken);

    public Task<HelixResult<ChatBadges>> GetGlobalChatBadges(
        CancellationToken cancellationToken = default)
    => _all.GetGlobalChatBadges(cancellationToken);

    public Task<HelixResult<ModeratedChannels>> GetModeratedChannels(
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModeratedChannels(first, cancellationToken);
    
    public Task<HelixResult<SentMessage>> SendChatMessage(
        ChatMessage message,
        CancellationToken cancellationToken = default)
    => _all.SendChatMessage(message, cancellationToken);
}
