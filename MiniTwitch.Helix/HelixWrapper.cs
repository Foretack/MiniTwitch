using Microsoft.Extensions.Logging;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix;

public class HelixWrapper
{
    private readonly AllCategories _all;

    public HelixWrapper(string bearerToken, string clientId, ILogger? logger = null,
        string helixBaseUrl = "https://api.twitch.tv/helix", string tokenValidationUrl = "https://id.twitch.tv/oauth2/validate")
    {
        _all = new(new HelixApiClient(bearerToken, clientId, logger, tokenValidationUrl), helixBaseUrl);
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

    public Task<HelixResult<ChannelInformation>> GetChannelInformation(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelInformation(broadcasterId, cancellationToken);

    public Task<HelixResult<ChannelsInformation>> GetChannelInformation(
        IEnumerable<long> broadcasterIds,
        CancellationToken cancellationToken = default)
    => _all.GetChannelInformation(broadcasterIds, cancellationToken);

    public Task<HelixResult> ModifyChannelInformation(
        long broadcasterId,
        NewChannelInformation body,
        CancellationToken cancellationToken = default)
    => _all.ModifyChannelInformation(broadcasterId, body, cancellationToken);

    public Task<HelixResult<ChannelEditors>> GetChannelEditors(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelEditors(broadcasterId, cancellationToken);

    public Task<HelixResult<FollowedChannels>> GetFollowedChannels(
        long userId,
        long? broadcasterId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetFollowedChannels(userId, broadcasterId, first, cancellationToken);

    public Task<HelixResult<ChannelFollowers>> GetChannelFollowers(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChannelFollowers(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<CustomReward>> CreateCustomReward(
        long broadcasterId,
        NewCustomReward body,
        CancellationToken cancellationToken = default)
    => _all.CreateCustomReward(broadcasterId, body, cancellationToken);

    public Task<HelixResult> DeleteCustomReward(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteCustomReward(broadcasterId, id, cancellationToken);

    public Task<HelixResult<CustomReward>> GetCustomReward(
        long broadcasterId,
        string? id = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    => _all.GetCustomReward(broadcasterId, id, onlyManageableRewards, cancellationToken);

    public Task<HelixResult<CustomReward>> GetCustomReward(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    => _all.GetCustomReward(broadcasterId, ids, onlyManageableRewards, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        long broadcasterId,
        string rewardId,
        RewardRedemptionStatus status,
        string? id = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCustomRewardRedemption(broadcasterId, rewardId, status, id, sort, first, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        long broadcasterId,
        string rewardId,
        RewardRedemptionStatus status,
        IEnumerable<string>? ids = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCustomRewardRedemption(broadcasterId, rewardId, status, ids, sort, first, cancellationToken);

    public Task<HelixResult<CustomReward>> UpdateCustomReward(
        long broadcasterId,
        string id,
        UpdatedCustomReward body,
        CancellationToken cancellationToken = default)
    => _all.UpdateCustomReward(broadcasterId, id, body, cancellationToken);

    public Task<HelixResult<CustomRewardRedemption>> UpdateRedemptionStatus(
        long broadcasterId,
        string id,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    => _all.UpdateRedemptionStatus(broadcasterId, id, rewardId, status, cancellationToken);

    public Task<HelixResult<CustomRewardRedemptions>> UpdateRedemptionStatus(
        long broadcasterId,
        IEnumerable<string> ids,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    => _all.UpdateRedemptionStatus(broadcasterId, ids, rewardId, status, cancellationToken);

    public Task<HelixResult<CharityCampaign>> GetCharityCampaign(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetCharityCampaign(broadcasterId, cancellationToken);

    public Task<HelixResult<CharityCampaignDonations>> GetCharityCampaignDonations(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetCharityCampaignDonations(broadcasterId, first, cancellationToken);

    public Task<HelixResult<Chatters>> GetChatters(
        long broadcasterId,
        long moderatorId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChatters(broadcasterId, moderatorId, first, cancellationToken);

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
        long moderatorId,
        NewChatSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChatSettings(broadcasterId, moderatorId, body, cancellationToken);

    public Task<HelixResult<BlockList>> GetUserBlockList(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetUserBlockList(broadcasterId, first, cancellationToken);

    public Task<HelixResult> SendChatAnnouncement(
        long broadcasterId,
        long moderatorId,
        Announcement body,
        CancellationToken cancellationToken = default)
    => _all.SendChatAnnouncement(broadcasterId, moderatorId, body, cancellationToken);

    public Task<HelixResult> SendAShoutout(
        long fromBroadcasterId,
        long toBroadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.SendAShoutout(fromBroadcasterId, toBroadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult<UserChatColor>> GetUserChatColor(
        long userId,
        CancellationToken cancellationToken = default)
    => _all.GetUserChatColor(userId, cancellationToken);

    public Task<HelixResult<UsersChatColor>> GetUserChatColor(
        IEnumerable<long> userIds,
        CancellationToken cancellationToken = default)
    => _all.GetUserChatColor(userIds, cancellationToken);

    public Task<HelixResult> UpdateUserChatColor(
        long userId,
        ChatColor color,
        CancellationToken cancellationToken = default)
    => _all.UpdateUserChatColor(userId, color, cancellationToken);

    public Task<HelixResult> UpdateUserChatColor(
        long userId,
        string hexColor,
        CancellationToken cancellationToken = default)
    => _all.UpdateUserChatColor(userId, hexColor, cancellationToken);

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

    public Task<HelixResult<Extensions>> GetExtensions(
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

    public Task<HelixResult<Game>> GetGames(
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
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetCreatorGoals(broadcasterId, cancellationToken);

    public Task<HelixResult<ChannelGuestStarSettings>> GetChannelGuestStarSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelGuestStarSettings(broadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult> UpdateChannelGuestStarSettings(
        NewGuestStarSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelGuestStarSettings(body, cancellationToken);

    public Task<HelixResult<GuestStarSession>> GetGuestStarSession(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.GetGuestStarSession(broadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult<GuestStarSession>> CreateGuestStarSession(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.CreateGuestStarSession(broadcasterId, cancellationToken);

    public Task<HelixResult<GuestStarSession>> EndGuestStarSession(
        long broadcasterId,
        string sessionId,
        CancellationToken cancellationToken = default)
    => _all.EndGuestStarSession(broadcasterId, sessionId, cancellationToken);

    public Task<HelixResult<GuestStarInvites>> GetGuestStarInvites(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        CancellationToken cancellationToken = default)
    => _all.GetGuestStarInvites(broadcasterId, moderatorId, sessionId, cancellationToken);

    public Task<HelixResult> SendGuestStarInvite(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    => _all.SendGuestStarInvite(broadcasterId, moderatorId, sessionId, guestId, cancellationToken);

    public Task<HelixResult> DeleteGuestStarInvite(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    => _all.DeleteGuestStarInvite(broadcasterId, moderatorId, sessionId, guestId, cancellationToken);

    public Task<HelixResult> AssignGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        string slotId,
        CancellationToken cancellationToken = default)
    => _all.AssignGuestStarSlot(broadcasterId, moderatorId, sessionId, guestId, slotId, cancellationToken);

    public Task<HelixResult> UpdateGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        string sourceSlotId,
        string? destinationSlotId = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateGuestStarSlot(broadcasterId, moderatorId, sessionId, sourceSlotId, destinationSlotId, cancellationToken);

    public Task<HelixResult> DeleteGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        string slotId,
        string? shouldReinviteGuest = null,
        CancellationToken cancellationToken = default)
    => _all.DeleteGuestStarSlot(broadcasterId, moderatorId, sessionId, guestId, slotId, shouldReinviteGuest, cancellationToken);

    public Task<HelixResult> UpdateGuestStarSlotSettings(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        string slotId,
        bool? isAudioEnabled = null,
        bool? isVideoEnabled = null,
        bool? isLive = null,
        int? volume = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateGuestStarSlotSettings(broadcasterId, moderatorId, sessionId, slotId, isAudioEnabled, isVideoEnabled, isLive, volume, cancellationToken);

    public Task<HelixResult<HypeTrainEvents>> GetHypeTrainEvents(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetHypeTrainEvents(broadcasterId, first, cancellationToken);

    public Task<HelixResult<AutoModStatus>> CheckAutoModStatus(
        long broadcasterId,
        MessageToCheck body,
        CancellationToken cancellationToken = default)
    => _all.CheckAutoModStatus(broadcasterId, body, cancellationToken);

    public Task<HelixResult> ManageHeldAutoModMessages(
        long userId,
        string msgId,
        string action,
        CancellationToken cancellationToken = default)
    => _all.ManageHeldAutoModMessages(userId, msgId, action, cancellationToken);

    public Task<HelixResult<AutoModSettings>> GetAutoModSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.GetAutoModSettings(broadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult<AutoModSettings>> UpdateAutoModSettings(
        long broadcasterId,
        long moderatorId,
        NewAutoModSettings body,
        CancellationToken cancellationToken = default)
    => _all.UpdateAutoModSettings(broadcasterId, moderatorId, body, cancellationToken);

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBannedUsers(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBannedUsers(broadcasterId, userIds, first, cancellationToken);

    public Task<HelixResult<BannedUser>> BanUser(
        long broadcasterId,
        long moderatorId,
        UserToBan body,
        CancellationToken cancellationToken = default)
    => _all.BanUser(broadcasterId, moderatorId, body, cancellationToken);

    public Task<HelixResult> UnbanUser(
        long broadcasterId,
        long moderatorId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.UnbanUser(broadcasterId, moderatorId, userId, cancellationToken);

    public Task<HelixResult<BlockedTerms>> GetBlockedTerms(
        long broadcasterId,
        long moderatorId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBlockedTerms(broadcasterId, moderatorId, first, cancellationToken);

    public Task<HelixResult<BlockedTerm>> AddBlockedTerm(
        long broadcasterId,
        long moderatorId,
        string text,
        CancellationToken cancellationToken = default)
    => _all.AddBlockedTerm(broadcasterId, moderatorId, text, cancellationToken);

    public Task<HelixResult> RemoveBlockedTerm(
        long broadcasterId,
        long moderatorId,
        string id,
        CancellationToken cancellationToken = default)
    => _all.RemoveBlockedTerm(broadcasterId, moderatorId, id, cancellationToken);

    public Task<HelixResult> DeleteChatMessages(
        long broadcasterId,
        long moderatorId,
        string? messageId = null,
        CancellationToken cancellationToken = default)
    => _all.DeleteChatMessages(broadcasterId, moderatorId, messageId, cancellationToken);

    public Task<HelixResult<Moderators>> GetModerators(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModerators(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<Moderators>> GetModerators(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetModerators(broadcasterId, userIds, first, cancellationToken);

    public Task<HelixResult> AddChannelModerator(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.AddChannelModerator(broadcasterId, userId, cancellationToken);

    public Task<HelixResult> RemoveChannelModerator(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.RemoveChannelModerator(broadcasterId, userId, cancellationToken);

    public Task<HelixResult<VIPs>> GetVIPs(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVIPs(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<VIPs>> GetVIPs(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetVIPs(broadcasterId, userIds, first, cancellationToken);

    public Task<HelixResult> AddChannelVIP(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.AddChannelVIP(broadcasterId, userId, cancellationToken);

    public Task<HelixResult> RemoveChannelVIP(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.RemoveChannelVIP(broadcasterId, userId, cancellationToken);

    public Task<HelixResult<ShieldModeStatus>> UpdateShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        bool isActive,
        CancellationToken cancellationToken = default)
    => _all.UpdateShieldModeStatus(broadcasterId, moderatorId, isActive, cancellationToken);

    public Task<HelixResult<ShieldModeStatus>> GetShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    => _all.GetShieldModeStatus(broadcasterId, moderatorId, cancellationToken);

    public Task<HelixResult<Polls>> GetPolls(
        long broadcasterId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPolls(broadcasterId, id, first, cancellationToken);

    public Task<HelixResult<Polls>> GetPolls(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPolls(broadcasterId, ids, first, cancellationToken);

    public Task<HelixResult<Poll>> CreatePoll(
        NewPoll body,
        CancellationToken cancellationToken = default)
    => _all.CreatePoll(body, cancellationToken);

    public Task<HelixResult<Poll>> EndPoll(
        long broadcasterId,
        string id,
        string status,
        CancellationToken cancellationToken = default)
    => _all.EndPoll(broadcasterId, id, status, cancellationToken);

    public Task<HelixResult<Predictions>> GetPredictions(
        long broadcasterId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPredictions(broadcasterId, id, first, cancellationToken);

    public Task<HelixResult<Predictions>> GetPredictions(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPredictions(broadcasterId, ids, first, cancellationToken);

    public Task<HelixResult<Prediction>> CreatePrediction(
        NewPrediction body,
        CancellationToken cancellationToken = default)
    => _all.CreatePrediction(body, cancellationToken);

    public Task<HelixResult<Prediction>> EndPrediction(
        PredictionToEnd body,
        CancellationToken cancellationToken = default)
    => _all.EndPrediction(body, cancellationToken);

    public Task<HelixResult<Raid>> StartARaid(
        long fromBroadcasterId,
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    => _all.StartARaid(fromBroadcasterId, toBroadcasterId, cancellationToken);

    public Task<HelixResult> CancelARaid(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.CancelARaid(broadcasterId, cancellationToken);

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
        long broadcasterId,
        bool? isVacationEnabled = null,
        DateTime? vacationStartTime = null,
        DateTime? vacationEndTime = null,
        string? timezone = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelStreamSchedule(broadcasterId, isVacationEnabled, vacationStartTime, vacationEndTime, timezone, cancellationToken);

    public Task<HelixResult<ScheduleSegment>> CreateChannelStreamScheduleSegment(
        long broadcasterId,
        NewScheduleSegment body,
        CancellationToken cancellationToken = default)
    => _all.CreateChannelStreamScheduleSegment(broadcasterId, body, cancellationToken);

    public Task<HelixResult<Responses.UpdatedScheduleSegment>> UpdateChannelStreamScheduleSegment(
        long broadcasterId,
        string id,
        Requests.UpdatedScheduleSegment Body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelStreamScheduleSegment(broadcasterId, id, Body, cancellationToken);

    public Task<HelixResult> DeleteChannelStreamScheduleSegment(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteChannelStreamScheduleSegment(broadcasterId, id, cancellationToken);

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

    public Task<HelixResult<StreamKey>> GetStreamKey(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetStreamKey(broadcasterId, cancellationToken);

    public Task<HelixResult<SingleStream>> GetStreams(
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
        long userId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetFollowedStreams(userId, first, cancellationToken);

    public Task<HelixResult<StreamMarker>> CreateStreamMarker(
        long userId,
        string? description = null,
        CancellationToken cancellationToken = default)
    => _all.CreateStreamMarker(userId, description, cancellationToken);

    public Task<HelixResult<StreamMarkers>> GetStreamMarkers(
        long userId,
        string? videoId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetStreamMarkers(userId, videoId, first, cancellationToken);

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBroadcasterSubscriptions(broadcasterId, userId, first, cancellationToken);

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetBroadcasterSubscriptions(broadcasterId, userIds, first, cancellationToken);

    public Task<HelixResult<UserSubscription>> CheckUserSubscription(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    => _all.CheckUserSubscription(broadcasterId, userId, cancellationToken);

    public Task<HelixResult<ChannelTeams>> GetChannelTeams(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    => _all.GetChannelTeams(broadcasterId, cancellationToken);

    public Task<HelixResult<Teams>> GetTeams(
        string name,
        string id,
        CancellationToken cancellationToken = default)
    => _all.GetTeams(name, id, cancellationToken);

    public Task<HelixResult<User>> GetUsers(
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

    public Task<HelixResult<ActiveExtensions>> GetUserActiveExtensions(
        long? userId = null,
        CancellationToken cancellationToken = default)
    => _all.GetUserActiveExtensions(userId, cancellationToken);

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
        long fromUserId,
        long toUserId,
        string message,
        CancellationToken cancellationToken = default)
    => _all.SendWhisper(fromUserId, toUserId, message, cancellationToken);

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

}
