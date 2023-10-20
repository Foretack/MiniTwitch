using System.Web;
using Microsoft.Extensions.Logging;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Internal.Models;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix;

public class HelixWrapper
{
    private readonly HelixApiClient _client;
    private readonly string _baseUrl;

    public HelixWrapper(string oauthToken, string clientId, ILogger? logger = null, string helixBaseUrl = "https://api.twitch.tv/helix")
    {
        _client = new HelixApiClient(oauthToken, clientId, logger);
        _baseUrl = helixBaseUrl;
    }

    // TODO: find suitable overloads

    public Task<HelixResult<Commercial>> StartCommercial(
        StartCommercialBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.StartCommercial;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };

        return HelixResultFactory.Create<Commercial>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionAnalytics>> GetExtensionAnalytics(
        string? extensionId = null,
        string? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionAnalytics;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ExtensionAnalytics>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GameAnalytics>> GetGameAnalytics(
        string? gameId = null,
        string? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGameAnalytics;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GameAnalytics>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BitsLeaderboard>> GetBitsLeaderboard(
        int? count = null,
        BitsLeaderboardPeriod? period = null,
        DateTime? startedAt = null,
        long? UserId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBitsLeaderboard;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Count, count)
            .AddParam(QueryParams.Period, period?.ToString()?.ToLower())
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.UserId, UserId);

        return HelixResultFactory.Create<BitsLeaderboard>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Cheermotes>> GetCheermotes(
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCheermotes;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Cheermotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionTransactions>> GetExtensionTransactions(
        string extensionId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionTransactions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ExtensionTransactions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionTransactions>> GetExtensionTransactions(
        string extensionId,
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionTransactions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ExtensionTransactions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelInformation>> GetChannelInformation(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelInformation;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<ChannelInformation>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelInformation>> GetChannelInformation(
        IEnumerable<long> broadcasterIds,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelInformation;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.BroadcasterId, broadcasterIds);

        return HelixResultFactory.Create<ChannelInformation>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> ModifyChannelInformation(
        long broadcasterId,
        ModifyChannelInformationBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.ModifyChannelInformation;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelEditors>> GetChannelEditors(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelEditors;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<ChannelEditors>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<FollowedChannels>> GetFollowedChannels(
        long userId,
        long? broadcasterId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetFollowedChannels;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<FollowedChannels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelFollowers>> GetChannelFollowers(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelFollowers;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ChannelFollowers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomReward>> CreateCustomReward(
        long broadcasterId,
        CreateCustomRewardBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateCustomRewards;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create<CustomReward>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteCustomReward(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteCustomReward;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomReward>> GetCustomReward(
        long broadcasterId,
        string? id = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomReward;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.OnlyManageableRewards, onlyManageableRewards);

        return HelixResultFactory.Create<CustomReward>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomReward>> GetCustomReward(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomReward;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.OnlyManageableRewards, onlyManageableRewards);

        return HelixResultFactory.Create<CustomReward>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomRewardRedemption>> GetCustomRewardRedemption(
        long broadcasterId,
        string rewardId,
        RewardRedemptionStatus status,
        string? id = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomRewardRedemption;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.RewardId, rewardId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Status, status.ToString().ToUpper())
            .AddParam(QueryParams.Sort, sort?.ToString().ToUpper())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<CustomRewardRedemption>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomRewardRedemption>> GetCustomRewardRedemption(
        long broadcasterId,
        string rewardId,
        RewardRedemptionStatus status,
        IEnumerable<string>? ids = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomRewardRedemption;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.RewardId, rewardId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.Status, status.ToString().ToUpper())
            .AddParam(QueryParams.Sort, sort?.ToString().ToUpper())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<CustomRewardRedemption>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomReward>> UpdateCustomReward(
        long broadcasterId,
        string id,
        UpdateCustomRewardBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateCustomReward;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id);

        request.Body = body;
        return HelixResultFactory.Create<CustomReward>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomRewardRedemption>> UpdateRedemptionStatus(
        long broadcasterId,
        string id,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateRedemptionStatus;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.RewardId, rewardId);

        request.Body = new
        {
            status = status.ToString()
        };

        return HelixResultFactory.Create<CustomRewardRedemption>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomRewardRedemption>> UpdateRedemptionStatus(
        long broadcasterId,
        IEnumerable<string> ids,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateRedemptionStatus;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.RewardId, rewardId);

        request.Body = new
        {
            status = status.ToString()
        };

        return HelixResultFactory.Create<CustomRewardRedemption>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CharityCampaign>> GetCharityCampaign(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCharityCampaign;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<CharityCampaign>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CharityCampaignDonations>> GetCharityCampaignDonations(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCharityCampaignDonations;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<CharityCampaignDonations>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Chatters>> GetChatters(
        long broadcasterId,
        long moderatorId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChatters;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Chatters>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Emotes>> GetChannelEmotes(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelEmotes;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Emotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Emotes>> GetGlobalEmotes(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGlobalEmotes;
        var request = new RequestData(_baseUrl, endpoint);
        return HelixResultFactory.Create<Emotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EmoteSets>> GetEmoteSets(
        string emoteSetId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEmoteSets;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam("emote_set_id", emoteSetId);

        return HelixResultFactory.Create<EmoteSets>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EmoteSets>> GetEmoteSets(
        IEnumerable<string> emoteSetIds,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEmoteSets;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam("emote_set_id", emoteSetIds);

        return HelixResultFactory.Create<EmoteSets>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChatSettings>> GetChatSettings(
        long broadcasterId,
        long? moderatorId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChatSettings;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<ChatSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChatSettings>> UpdateChatSettings(
        long broadcasterId,
        long moderatorId,
        UpdateChatSettingsBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChatSettings;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = body;
        return HelixResultFactory.Create<ChatSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BlockList>> GetUserBlockList(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserBlockList;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BlockList>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendChatAnnouncement(
        long broadcasterId,
        long moderatorId,
        SendChatAnnouncementBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendChatAnnouncement;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendAShoutout(
        long fromBroadcasterId,
        long toBroadcasterId, 
        long moderatorId, 
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendAShoutout;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.FromBroadcasterId, fromBroadcasterId)
            .AddParam(QueryParams.ToBroadcasterId, toBroadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UserChatColor>> GetUserChatColor(
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserChatColor;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<UserChatColor>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UserChatColor>> GetUserChatColor(
        IEnumerable<long> userIds,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserChatColor;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.UserId, userIds);

        return HelixResultFactory.Create<UserChatColor>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateUserChatColor(
        long userId,
        ChatColor color,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUserChatColor;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.Color, color.ToString());

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateUserChatColor(
        long userId,
        string hexColor,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUserChatColor;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.Color, HttpUtility.UrlEncode(hexColor));

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Clip>> CreateClip(
        long broadcasterId,
        bool? hasDelay = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateClip;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.HasDelay, hasDelay);

        return HelixResultFactory.Create<Clip>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Clips>> GetClips(
        long broadcasterId,
        long gameId,
        string id,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        bool? isFeatured = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetClips;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first)
            .AddParam(QueryParams.IsFeatured, isFeatured);

        return HelixResultFactory.Create<Clips>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Clips>> GetClips(
        long broadcasterId,
        long gameId,
        IEnumerable<string> ids,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        bool? isFeatured = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetClips;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.GameId, gameId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first)
            .AddParam(QueryParams.IsFeatured, isFeatured);

        return HelixResultFactory.Create<Clips>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ContentClassificationLabels>> GetContentClassificationLabels(
        LabelLocale? locale = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetContentClassificationLabels;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Locale, locale?.ToString().Replace('_', '-'));

        return HelixResultFactory.Create<ContentClassificationLabels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<DropsEntitlements>> GetDropsEntitlements(
        string? id = null,
        long? userId = null,
        string? gameId = null,
        FulfillmentStatus? fulfillmentStatus = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetDropsEntitlements;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<DropsEntitlements>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<DropsEntitlements>> GetDropsEntitlements(
        IEnumerable<string>? ids = null,
        long? userId = null,
        string? gameId = null,
        FulfillmentStatus? fulfillmentStatus = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetDropsEntitlements;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<DropsEntitlements>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdatedDropsEntitlements>> UpdateDropsEntitlements(
        IEnumerable<string>? entitlementIds = null,
        FulfillmentStatus? fulfillmentStatus = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateDropsEntitlements;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.EntitlementIds, entitlementIds)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString());


        return HelixResultFactory.Create<UpdatedDropsEntitlements>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        string segment,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionConfigurationSegment;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Segment, segment)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);


        return HelixResultFactory.Create<ExtensionConfigurationSegment>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        IEnumerable<string> segments,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionConfigurationSegment;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddMultiParam(QueryParams.Segment, segments)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);


        return HelixResultFactory.Create<ExtensionConfigurationSegment>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SetExtensionConfigurationSegment(
        SetExtensionConfigurationSegmentBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SetExtensionConfigurationSegment;
        var request = new RequestData(_baseUrl, endpoint);
        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SetExtensionRequiredConfiguration(
        long broadcasterId,
        SetExtensionRequiredConfigurationBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SetExtensionRequiredConfiguration;
        var request = new RequestData(_baseUrl, endpoint);
        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendExtensionPubSubMessage(
        SendExtensionPubSubMessageBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendExtensionPubSubMessage;
        var request = new RequestData(_baseUrl, endpoint);
        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionLiveChannels>> GetExtensionLiveChannels(
        string extensionId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionLiveChannels;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ExtensionLiveChannels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionSecrets>> GetExtensionSecrets(
        string extensionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionSecrets;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId);

        return HelixResultFactory.Create<ExtensionSecrets>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionSecrets>> CreateExtensionSecret(
        string extensionId,
        int? delay = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateExtensionSecret;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Delay, delay);

        return HelixResultFactory.Create<ExtensionSecrets>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendExtensionChatMessage(
        long broadcasterId,
        SendExtensionChatMessageBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendExtensionChatMessage;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Extensions>> GetExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.ExtensionVersion, extensionVersion);

        return HelixResultFactory.Create<Extensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ReleasedExtensions>> GetReleasedExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetReleasedExtensions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.ExtensionVersion, extensionVersion);

        return HelixResultFactory.Create<ReleasedExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionBitsProducts>> GetExtensionBitsProducts(
        bool? shouldIncludeAll = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionBitsProducts;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ShouldIncludeAll, shouldIncludeAll);

        return HelixResultFactory.Create<ExtensionBitsProducts>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionBitsProducts>> UpdateExtensionBitsProduct(
        UpdateExtensionBitsProductBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateExtensionBitsProduct;
        var request = new RequestData(_baseUrl, endpoint);
        request.Body = body;
        return HelixResultFactory.Create<ExtensionBitsProducts>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreatedSubscription>> CreateEventSubSubscription(
        CreateEventSubSubscriptionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateEventSubSubscription;
        var request = new RequestData(_baseUrl, endpoint);
        request.Body = body;
        return HelixResultFactory.Create<CreatedSubscription>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteEventSubSubscription(
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteEventSubSubscription;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EventSubSubscriptions>> GetEventSubSubscriptions(
        string? status = null,
        string? type = null,
        long? userId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEventSubSubscriptions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Status, status)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<EventSubSubscriptions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Games>> GetTopGames(
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetTopGames;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Games>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Games>> GetGames(
        string? id = null,
        string? name = null,
        string? igdbId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGames;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Name, name)
            .AddParam(QueryParams.IgdbId, igdbId);

        return HelixResultFactory.Create<Games>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Games>> GetGames(
        IEnumerable<string>? ids = null,
        IEnumerable<string>? names = null,
        IEnumerable<string>? igdbIds = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGames;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, ids)
            .AddMultiParam(QueryParams.Name, names)
            .AddMultiParam(QueryParams.IgdbId, igdbIds);

        return HelixResultFactory.Create<Games>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreatorGoals>> GetCreatorGoals(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCreatorGoals;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<CreatorGoals>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelGuestStarSettings>> GetChannelGuestStarSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelGuestStarSettings;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<ChannelGuestStarSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateChannelGuestStarSettings(
        UpdateChannelGuestStarSettingsBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChannelGuestStarSettings;
        var request = new RequestData(_baseUrl, endpoint);
        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GuestStarSession>> GetGuestStarSession(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGuestStarSession;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<GuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GuestStarSession>> CreateGuestStarSession(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateGuestStarSession;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GuestStarSession>> EndGuestStarSession(
        long broadcasterId,
        string sessionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndGuestStarSession;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.SessionId, sessionId);

        return HelixResultFactory.Create<GuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GuestStarInvites>> GetGuestStarInvites(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGuestStarInvites;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(sessionId, sessionId);

        return HelixResultFactory.Create<GuestStarInvites>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendGuestStarInvite(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendGuestStarInvite;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.GuestId, guestId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteGuestStarInvite(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteGuestStarInvite;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.GuestId, guestId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> AssignGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        string slotId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AssignGuestStarSlot;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.GuestId, guestId)
            .AddParam(QueryParams.SlotId, slotId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        string sourceSlotId,
        string? destinationSlotId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateGuestStarSlot;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.SourceSlotId, sourceSlotId)
            .AddParam(QueryParams.DestinationSlotId, destinationSlotId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteGuestStarSlot(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        string slotId,
        string? shouldReinviteGuest = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteGuestStarSlot;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.GuestId, guestId)
            .AddParam(QueryParams.SlotId, slotId)
            .AddParam(QueryParams.ShouldReinviteGuest, shouldReinviteGuest);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

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
    {
        HelixEndpoint endpoint = Endpoints.UpdateGuestStarSlotSettings;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.SlotId, slotId)
            .AddParam(QueryParams.IsAudioEnabled, isAudioEnabled)
            .AddParam(QueryParams.IsVideoEnabled, isVideoEnabled)
            .AddParam(QueryParams.IsLive, isLive)
            .AddParam(QueryParams.Volume, volume);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<HypeTrainEvents>> GetHypeTrainEvents(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetHypeTrainEvents;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<HypeTrainEvents>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AutoModStatus>> CheckAutoModStatus(
        long broadcasterId,
        CheckAutoModStatusBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CheckAutoModStatus;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create<AutoModStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> ManageHeldAutoModMessages(
        long userId,
        string msgId,
        string action,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.ManageHeldAutoModMessages;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.MsgId, msgId)
            .AddParam(QueryParams.Action, action);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AutoModSettings>> GetAutoModSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetAutoModSettings;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<AutoModSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AutoModSettings>> UpdateAutoModSettings(
        long broadcasterId,
        long moderatorId,
        UpdateAutoModSettingsBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateAutoModSettings;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = body;
        return HelixResultFactory.Create<AutoModSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBannedUsers;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BannedUsers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBannedUsers;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BannedUsers>(_client, request, endpoint, cancellationToken);
    }

    // TODO: fix this
    public Task<HelixResult<BannedUser>> BanUser(
        long broadcasterId,
        long moderatorId,
        long userId,
        TimeSpan? duration = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.BanUser;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = new
        {
            data = new
            {
                user_id = userId.ToString(),
                duration = duration?.TotalSeconds,
                reason
            }
        };

        return HelixResultFactory.Create<BannedUser>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UnbanUser(
        long broadcasterId,
        long moderatorId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UnbanUser;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BlockedTerms>> GetBlockedTerms(
        long broadcasterId,
        long moderatorId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBlockedTerms;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BlockedTerms>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BlockedTerm>> AddBlockedTerm(
        long broadcasterId,
        long moderatorId,
        string text,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddBlockedTerm;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = new { text };
        return HelixResultFactory.Create<BlockedTerm>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> RemoveBlockedTerm(
        long broadcasterId,
        long moderatorId,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.RemoveBlockedTerm;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteChatMessages(
        long broadcasterId,
        long moderatorId,
        string? messageId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteChatMessages;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.MessageId, messageId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Moderators>> GetModerators(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetModerators;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Moderators>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Moderators>> GetModerators(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetModerators;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Moderators>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> AddChannelModerator(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddChannelModerator;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> RemoveChannelModerator(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.RemoveChannelModerator;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<VIPs>> GetVIPs(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVIPs;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<VIPs>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<VIPs>> GetVIPs(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVIPs;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<VIPs>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> AddChannelVIP(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddChannelVIP;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> RemoveChannelVIP(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.RemoveChannelVIP;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ShieldModeStatus>> UpdateShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        bool isActive,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateShieldModeStatus;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = new { is_active =  isActive };
        return HelixResultFactory.Create<ShieldModeStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ShieldModeStatus>> GetShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetShieldModeStatus;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<ShieldModeStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Polls>> GetPolls(
        long broadcasterId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPolls;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Polls>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Polls>> GetPolls(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPolls;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Polls>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Poll>> CreatePoll(
        CreatePollBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreatePoll;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };

        return HelixResultFactory.Create<Poll>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Poll>> EndPoll(
        long broadcasterId,
        string id,
        string status,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndPoll;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Status, status);

        return HelixResultFactory.Create<Poll>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Predictions>> GetPredictions(
        long broadcasterId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPredictions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Predictions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Predictions>> GetPredictions(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPredictions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Predictions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Prediction>> CreatePrediction(
        CreatePredictionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreatePrediction;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };

        return HelixResultFactory.Create<Prediction>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Prediction>> EndPrediction(
        EndPredictionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndPrediction;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };

        return HelixResultFactory.Create<Prediction>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Raid>> StartARaid(
        long fromBroadcasterId,
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.StartARaid;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.FromBroadcasterId, fromBroadcasterId)
            .AddParam(QueryParams.ToBroadcasterId, toBroadcasterId);

        return HelixResultFactory.Create<Raid>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> CancelARaid(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CancelARaid;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        string? id = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelStreamSchedule;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.StartTime, startTime)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<StreamSchedule>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelStreamSchedule;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.StartTime, startTime)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<StreamSchedule>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateChannelStreamSchedule(
        long broadcasterId,
        bool? isVacationEnabled = null,
        DateTime? vacationStartTime = null,
        DateTime? vacationEndTime = null,
        string? timezone = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChannelStreamSchedule;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.IsVacationEnabled, isVacationEnabled)
            .AddParam(QueryParams.VacationStartTime, vacationStartTime)
            .AddParam(QueryParams.VacationEndTime, vacationEndTime)
            .AddParam(QueryParams.Timezone, timezone);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ScheduleSegment>> CreateChannelStreamScheduleSegment(
        long broadcasterId,
        ChannelStreamScheduleSegmentBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateChannelStreamScheduleSegment;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        }.AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<ScheduleSegment>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdatedScheduleSegment>> UpdateChannelStreamScheduleSegment(
        long broadcasterId,
        string id,
        UpdateChannelStreamScheduleSegmentBody Body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChannelStreamScheduleSegment;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = Body
        }
        .AddParam(QueryParams.BroadcasterId, broadcasterId)
        .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create<UpdatedScheduleSegment>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteChannelStreamScheduleSegment(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteChannelStreamScheduleSegment;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Categories>> SearchCategories(
        string query,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SearchCategories;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Query, HttpUtility.UrlEncode(query))
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Categories>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Channels>> SearchChannels(
        string query,
        bool? liveOnly = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SearchChannels;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Query, query)
            .AddParam(QueryParams.LiveOnly, liveOnly)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Channels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamKey>> GetStreamKey(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreamKey;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<StreamKey>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Streams>> GetStreams(
        long? userId = null,
        string? userLogin = null,
        string? gameId = null,
        string? type = null,
        string? language = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreams;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.UserLogin, userLogin)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.Language, language)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Streams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Streams>> GetStreams(
        IEnumerable<long>? userIds = null,
        IEnumerable<string>? userLogins = null,
        IEnumerable<string>? gameIds = null,
        string? type = null,
        IEnumerable<string>? languages = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreams;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddMultiParam(QueryParams.UserLogin, userLogins)
            .AddMultiParam(QueryParams.GameId, gameIds)
            .AddParam(QueryParams.Type, type)
            .AddMultiParam(QueryParams.Language, languages)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Streams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<FollowedStreams>> GetFollowedStreams(
        long userId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetFollowedStreams;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<FollowedStreams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamMarker>> CreateStreamMarker(
        long userId,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateStreamMarker;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = new
            {
                user_id = userId,
                description
            }
        };

        return HelixResultFactory.Create<StreamMarker>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamMarkers>> GetStreamMarkers(
        long userId,
        string? videoId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreamMarkers;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.VideoId, videoId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<StreamMarkers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBroadcasterSubscriptions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BroadcasterSubscriptions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        long broadcasterId,
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBroadcasterSubscriptions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BroadcasterSubscriptions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UserSubscription>> CheckUserSubscription(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CheckUserSubscription;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<UserSubscription>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelTeams>> GetChannelTeams(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelTeams;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<ChannelTeams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Teams>> GetTeams(
        string name,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetTeams;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Name, name)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create<Teams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Users>> GetUsers(
        long? id = null,
        string? login = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUsers;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Login, login);

        return HelixResultFactory.Create<Users>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Users>> GetUsers(
        IEnumerable<long>? id = null,
        IEnumerable<string>? login = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUsers;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, id)
            .AddMultiParam(QueryParams.Login, login);

        return HelixResultFactory.Create<Users>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdatedUser>> UpdateUser(
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUser;
        var request = new RequestData(_baseUrl, endpoint);
        return HelixResultFactory.Create<UpdatedUser>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> BlockUser(
        long targetUserId,
        string? sourceContext = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.BlockUser;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.TargetUserId, targetUserId)
            .AddParam(QueryParams.SourceContext, sourceContext)
            .AddParam(QueryParams.Reason, reason);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UnblockUser(
        long targetUserId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UnblockUser;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.TargetUserId, targetUserId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UserExtensions>> GetUserExtensions(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserExtensions;
        var request = new RequestData(_baseUrl, endpoint);
        return HelixResultFactory.Create<UserExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ActiveExtensions>> GetUserActiveExtensions(
        long? userId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserActiveExtensions;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<ActiveExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Videos>> GetVideos(
        string? id = null,
        long? userId = null,
        string? gameId = null,
        string? language = null,
        string? period = null,
        string? sort = null,
        string? type = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVideos;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Language, language)
            .AddParam(QueryParams.Period, period)
            .AddParam(QueryParams.Sort, sort)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Videos>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Videos>> GetVideos(
        IEnumerable<string>? ids = null,
        long? userId = null,
        string? gameId = null,
        string? language = null,
        string? period = null,
        string? sort = null,
        string? type = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVideos;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Language, language)
            .AddParam(QueryParams.Period, period)
            .AddParam(QueryParams.Sort, sort)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Videos>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteVideos(
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteVideos;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteVideos(
        IEnumerable<string> ids,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteVideos;
        var request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, ids);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendWhisper(
        long fromUserId,
        long toUserId,
        string message,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendWhisper;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = new
            {
                message
            }
        }
        .AddParam(QueryParams.FromUserId, fromUserId)
        .AddParam(QueryParams.ToUserId, toUserId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AdSchedule>> GetAdSchedule(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetAdSchedule;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<AdSchedule>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<SnoozedAd>> SnoozeNextAd(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SnoozeNextAd;
        var request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<SnoozedAd>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChatBadges>> GetGlobalChatBadges(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGlobalChatBadges;
        var request = new RequestData(_baseUrl, endpoint);
        return HelixResultFactory.Create<ChatBadges>(_client, request, endpoint, cancellationToken);
    }
}
