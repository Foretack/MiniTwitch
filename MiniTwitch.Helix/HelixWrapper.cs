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

    public Task<HelixResult<StartCommercial>> StartCommercial(
        StartCommercialBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.StartCommercial;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        };

        return HelixResultFactory.Create<StartCommercial>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetExtensionAnalytics>> GetExtensionAnalytics(
        string? extensionId = null,
        string? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionAnalytics;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetExtensionAnalytics>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetGameAnalytics>> GetGameAnalytics(
        string? gameId = null,
        string? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGameAnalytics;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetGameAnalytics>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetBitsLeaderboard>> GetBitsLeaderboard(
        int? count = null,
        BitsLeaderboardPeriod? period = null,
        DateTime? startedAt = null,
        long? UserId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBitsLeaderboard;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Count, count)
            .AddParam(QueryParams.Period, period?.ToString()?.ToLower())
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.UserId, UserId);

        return HelixResultFactory.Create<GetBitsLeaderboard>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetCheermotes>> GetCheermotes(
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCheermotes;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GetCheermotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetExtensionTransactions>> GetExtensionTransactions(
        string extensionId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionTransactions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetExtensionTransactions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChannelInformation>> GetChannelInformation(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelInformation;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GetChannelInformation>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> ModifyChannelInformation(
        long broadcasterId,
        ModifyChannelInformationBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.ModifyChannelInformation;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChannelEditors>> GetChannelEditors(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelEditors;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GetChannelEditors>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetFollowedChannels>> GetFollowedChannels(
        long userId,
        long? broadcasterId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetFollowedChannels;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetFollowedChannels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChannelFollowers>> GetChannelFollowers(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelFollowers;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetChannelFollowers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreateCustomRewards>> CreateCustomReward(
        long broadcasterId,
        CreateCustomRewardBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateCustomRewards;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create<CreateCustomRewards>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteCustomReward(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteCustomReward;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetCustomReward>> GetCustomReward(
        long broadcasterId,
        string? id = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomReward;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.OnlyManageableRewards, onlyManageableRewards);

        return HelixResultFactory.Create<GetCustomReward>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetCustomRewardRedemption>> GetCustomRewardRedemption(
        long broadcasterId,
        string rewardId,
        RewardRedemptionStatus status,
        string? id = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomRewardRedemption;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.RewardId, rewardId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Status, status.ToString().ToUpper())
            .AddParam(QueryParams.Sort, sort?.ToString().ToUpper())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetCustomRewardRedemption>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateCustomReward>> UpdateCustomReward(
        long broadcasterId,
        string id,
        UpdateCustomRewardBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateCustomReward;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id);

        request.Body = body;
        return HelixResultFactory.Create<UpdateCustomReward>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateRedemptionStatus>> UpdateRedemptionStatus(
        long broadcasterId,
        string id,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateRedemptionStatus;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.RewardId, rewardId);

        request.Body = new
        {
            status = status.ToString()
        };

        return HelixResultFactory.Create<UpdateRedemptionStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetCharityCampaign>> GetCharityCampaign(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCharityCampaign;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GetCharityCampaign>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetCharityCampaignDonations>> GetCharityCampaignDonations(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCharityCampaignDonations;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetCharityCampaignDonations>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChatters>> GetChatters(
        long broadcasterId,
        long moderatorId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChatters;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetChatters>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChannelEmotes>> GetChannelEmotes(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelEmotes;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GetChannelEmotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetGlobalEmotes>> GetGlobalEmotes(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGlobalEmotes;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        return HelixResultFactory.Create<GetGlobalEmotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetEmoteSets>> GetEmoteSets(
        string emoteSetId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEmoteSets;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam("emote_set_id", emoteSetId);

        return HelixResultFactory.Create<GetEmoteSets>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChatSettings>> GetChatSettings(
        long broadcasterId,
        long? moderatorId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChatSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<GetChatSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateChatSettings>> UpdateChatSettings(
        long broadcasterId,
        long moderatorId,
        UpdateChatSettingsBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChatSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = body;
        return HelixResultFactory.Create<UpdateChatSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetUserBlockList>> GetUserBlockList(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserBlockList;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetUserBlockList>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendChatAnnouncement(
        long broadcasterId,
        long moderatorId,
        SendChatAnnouncementBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendChatAnnouncement;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.FromBroadcasterId, fromBroadcasterId)
            .AddParam(QueryParams.ToBroadcasterId, toBroadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetUserChatColor>> GetUserChatColor(
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserChatColor;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<GetUserChatColor>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateUserChatColor(
        long userId,
        ChatColor color,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUserChatColor;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.Color, HttpUtility.UrlEncode(hexColor));

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreateClip>> CreateClip(
        long broadcasterId,
        bool? hasDelay = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateClip;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.HasDelay, hasDelay);

        return HelixResultFactory.Create<CreateClip>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetClips>> GetClips(
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first)
            .AddParam(QueryParams.IsFeatured, isFeatured);

        return HelixResultFactory.Create<GetClips>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetContentClassificationLabels>> GetContentClassificationLabels(
        LabelLocale? locale = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetContentClassificationLabels;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Locale, locale?.ToString().Replace('_', '-'));

        return HelixResultFactory.Create<GetContentClassificationLabels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetDropsEntitlements>> GetDropsEntitlements(
        string? id = null,
        long? userId = null,
        string? gameId = null,
        FulfillmentStatus? fulfillmentStatus = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetDropsEntitlements;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetDropsEntitlements>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateDropsEntitlements>> UpdateDropsEntitlements(
        IEnumerable<string>? entitlementIds = null,
        FulfillmentStatus? fulfillmentStatus = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateDropsEntitlements;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.EntitlementIds, entitlementIds)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString());


        return HelixResultFactory.Create<UpdateDropsEntitlements>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        string segment,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionConfigurationSegment;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Segment, segment)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);


        return HelixResultFactory.Create<GetExtensionConfigurationSegment>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SetExtensionConfigurationSegment(
        SetExtensionConfigurationSegmentBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SetExtensionConfigurationSegment;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SetExtensionRequiredConfiguration(
        long broadcasterId,
        SetExtensionRequiredConfigurationBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SetExtensionRequiredConfiguration;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendExtensionPubSubMessage(
        SendExtensionPubSubMessageBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendExtensionPubSubMessage;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetExtensionLiveChannels>> GetExtensionLiveChannels(
        string extensionId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionLiveChannels;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetExtensionLiveChannels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetExtensionSecrets>> GetExtensionSecrets(
        string extensionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionSecrets;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId);

        return HelixResultFactory.Create<GetExtensionSecrets>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreateExtensionSecret>> CreateExtensionSecret(
        string extensionId,
        int? delay = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateExtensionSecret;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Delay, delay);

        return HelixResultFactory.Create<CreateExtensionSecret>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendExtensionChatMessage(
        long broadcasterId,
        SendExtensionChatMessageBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendExtensionChatMessage;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetExtensions>> GetExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.ExtensionVersion, extensionVersion);

        return HelixResultFactory.Create<GetExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetReleasedExtensions>> GetReleasedExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetReleasedExtensions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.ExtensionVersion, extensionVersion);

        return HelixResultFactory.Create<GetReleasedExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetExtensionBitsProducts>> GetExtensionBitsProducts(
        bool? shouldIncludeAll = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionBitsProducts;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ShouldIncludeAll, shouldIncludeAll);

        return HelixResultFactory.Create<GetExtensionBitsProducts>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateExtensionBitsProduct>> UpdateExtensionBitsProduct(
        UpdateExtensionBitsProductBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateExtensionBitsProduct;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        request.Body = body;
        return HelixResultFactory.Create<UpdateExtensionBitsProduct>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreateEventSubSubscription>> CreateEventSubSubscription(
        CreateEventSubSubscriptionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateEventSubSubscription;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        request.Body = body;
        return HelixResultFactory.Create<CreateEventSubSubscription>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteEventSubSubscription(
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteEventSubSubscription;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetEventSubSubscriptions>> GetEventSubSubscriptions(
        string? status = null,
        string? type = null,
        long? userId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEventSubSubscriptions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Status, status)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<GetEventSubSubscriptions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetTopGames>> GetTopGames(
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetTopGames;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetTopGames>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetGames>> GetGames(
        string? id = null,
        string? name = null,
        string? igdbId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGames;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Name, name)
            .AddParam(QueryParams.IgdbId, igdbId);

        return HelixResultFactory.Create<GetGames>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetCreatorGoals>> GetCreatorGoals(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCreatorGoals;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GetCreatorGoals>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChannelGuestStarSettings>> GetChannelGuestStarSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelGuestStarSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<GetChannelGuestStarSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateChannelGuestStarSettings(
        UpdateChannelGuestStarSettingsBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChannelGuestStarSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        request.Body = body;
        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetGuestStarSession>> GetGuestStarSession(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGuestStarSession;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<GetGuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreateGuestStarSession>> CreateGuestStarSession(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateGuestStarSession;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<CreateGuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EndGuestStarSession>> EndGuestStarSession(
        long broadcasterId,
        string sessionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndGuestStarSession;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.SessionId, sessionId);

        return HelixResultFactory.Create<EndGuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetGuestStarInvites>> GetGuestStarInvites(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGuestStarInvites;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(sessionId, sessionId);

        return HelixResultFactory.Create<GetGuestStarInvites>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendGuestStarInvite(
        long broadcasterId,
        long moderatorId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendGuestStarInvite;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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

    public Task<HelixResult<GetHypeTrainEvents>> GetHypeTrainEvents(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetHypeTrainEvents;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetHypeTrainEvents>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CheckAutoModStatus>> CheckAutoModStatus(
        long broadcasterId,
        CheckAutoModStatusBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CheckAutoModStatus;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create<CheckAutoModStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> ManageHeldAutoModMessages(
        long userId,
        string msgId,
        string action,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.ManageHeldAutoModMessages;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.MsgId, msgId)
            .AddParam(QueryParams.Action, action);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetAutoModSettings>> GetAutoModSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetAutoModSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<GetAutoModSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateAutoModSettings>> UpdateAutoModSettings(
        long broadcasterId,
        long moderatorId,
        UpdateAutoModSettingsBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateAutoModSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = body;
        return HelixResultFactory.Create<UpdateAutoModSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetBannedUsers>> GetBannedUsers(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBannedUsers;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetBannedUsers>(_client, request, endpoint, cancellationToken);
    }

    // TODO: fix this
    public Task<HelixResult<BanUser>> BanUser(
        long broadcasterId,
        long moderatorId,
        long userId,
        TimeSpan? duration = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.BanUser;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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

        return HelixResultFactory.Create<BanUser>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UnbanUser(
        long broadcasterId,
        long moderatorId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UnbanUser;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetBlockedTerms>> GetBlockedTerms(
        long broadcasterId,
        long moderatorId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBlockedTerms;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetBlockedTerms>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AddBlockedTerm>> AddBlockedTerm(
        long broadcasterId,
        long moderatorId,
        string text,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddBlockedTerm;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = new { text };
        return HelixResultFactory.Create<AddBlockedTerm>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> RemoveBlockedTerm(
        long broadcasterId,
        long moderatorId,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.RemoveBlockedTerm;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId)
            .AddParam(QueryParams.MessageId, messageId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetModerators>> GetModerators(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetModerators;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetModerators>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> AddChannelModerator(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddChannelModerator;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetVIPs>> GetVIPs(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVIPs;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetVIPs>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> AddChannelVIP(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddChannelVIP;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateShieldModeStatus>> UpdateShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        bool isActive,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateShieldModeStatus;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        request.Body = new { is_active =  isActive };
        return HelixResultFactory.Create<UpdateShieldModeStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetShieldModeStatus>> GetShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetShieldModeStatus;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<GetShieldModeStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetPolls>> GetPolls(
        long broadcasterId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPolls;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetPolls>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreatePoll>> CreatePoll(
        CreatePollBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreatePoll;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        };

        return HelixResultFactory.Create<CreatePoll>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EndPoll>> EndPoll(
        long broadcasterId,
        string id,
        string status,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndPoll;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Status, status);

        return HelixResultFactory.Create<EndPoll>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetPredictions>> GetPredictions(
        long broadcasterId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPredictions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetPredictions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreatePrediction>> CreatePrediction(
        CreatePredictionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreatePrediction;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        };

        return HelixResultFactory.Create<CreatePrediction>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EndPrediction>> EndPrediction(
        EndPredictionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndPrediction;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        };

        return HelixResultFactory.Create<EndPrediction>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StartARaid>> StartARaid(
        long fromBroadcasterId,
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.StartARaid;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.FromBroadcasterId, fromBroadcasterId)
            .AddParam(QueryParams.ToBroadcasterId, toBroadcasterId);

        return HelixResultFactory.Create<StartARaid>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> CancelARaid(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CancelARaid;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChannelStreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        string? id = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelStreamSchedule;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.StartTime, startTime)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetChannelStreamSchedule>(_client, request, endpoint, cancellationToken);
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.IsVacationEnabled, isVacationEnabled)
            .AddParam(QueryParams.VacationStartTime, vacationStartTime)
            .AddParam(QueryParams.VacationEndTime, vacationEndTime)
            .AddParam(QueryParams.Timezone, timezone);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreateChannelStreamScheduleSegment>> CreateChannelStreamScheduleSegment(
        long broadcasterId,
        ChannelStreamScheduleSegmentBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateChannelStreamScheduleSegment;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        }.AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<CreateChannelStreamScheduleSegment>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateChannelStreamScheduleSegment>> UpdateChannelStreamScheduleSegment(
        long broadcasterId,
        string id,
        UpdateChannelStreamScheduleSegmentBody Body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChannelStreamScheduleSegment;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = Body
        }
        .AddParam(QueryParams.BroadcasterId, broadcasterId)
        .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create<UpdateChannelStreamScheduleSegment>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteChannelStreamScheduleSegment(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteChannelStreamScheduleSegment;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<SearchCategories>> SearchCategories(
        string query,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SearchCategories;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Query, HttpUtility.UrlEncode(query))
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<SearchCategories>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<SearchChannels>> SearchChannels(
        string query,
        bool? liveOnly = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SearchChannels;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Query, query)
            .AddParam(QueryParams.LiveOnly, liveOnly)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<SearchChannels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetStreamKey>> GetStreamKey(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreamKey;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GetStreamKey>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetStreams>> GetStreams(
        long? userId = null,
        string? userLogin = null,
        string? gameId = null,
        string? type = null,
        string? language = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreams;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.UserLogin, userLogin)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.Language, language)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetStreams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetFollowedStreams>> GetFollowedStreams(
        long userId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetFollowedStreams;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetFollowedStreams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreateStreamMarker>> CreateStreamMarker(
        long userId,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateStreamMarker;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = new
            {
                user_id = userId,
                description
            }
        };

        return HelixResultFactory.Create<CreateStreamMarker>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetStreamMarkers>> GetStreamMarkers(
        long userId,
        string? videoId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreamMarkers;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.VideoId, videoId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetStreamMarkers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetBroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        long broadcasterId,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBroadcasterSubscriptions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GetBroadcasterSubscriptions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CheckUserSubscription>> CheckUserSubscription(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CheckUserSubscription;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<CheckUserSubscription>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetChannelTeams>> GetChannelTeams(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelTeams;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<GetChannelTeams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetTeams>> GetTeams(
        string name,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetTeams;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Name, name)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create<GetTeams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetUsers>> GetUsers(
        long id,
        string login,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUsers;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Login, login);

        return HelixResultFactory.Create<GetUsers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdateUser>> UpdateUser(
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUser;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        return HelixResultFactory.Create<UpdateUser>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> BlockUser(
        long targetUserId,
        string? sourceContext = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.BlockUser;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.TargetUserId, targetUserId);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetUserExtensions>> GetUserExtensions(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserExtensions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        return HelixResultFactory.Create<GetUserExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetUserActiveExtensions>> GetUserActiveExtensions(
        long? userId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserActiveExtensions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<GetUserActiveExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GetVideos>> GetVideos(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVideos;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        return HelixResultFactory.Create<GetVideos>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteVideos(
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteVideos;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendWhisper(
        long fromUserId,
        long toUserId,
        string message,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendWhisper;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
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
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<AdSchedule>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AdSnoozeResponse>> SnoozeNextAd(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SnoozeNextAd;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<AdSnoozeResponse>(_client, request, endpoint, cancellationToken);
    }
}
