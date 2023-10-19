using System.Web;
using Microsoft.Extensions.Logging;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Internal.Models;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Requests;

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

    public Task<HelixResult<Responses.StartCommercial>> StartCommercial(
        StartCommercialBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.StartCommercial;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        };

        return HelixResultFactory.Create<Responses.StartCommercial>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetExtensionAnalytics>> GetExtensionAnalytics(
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

        return HelixResultFactory.Create<Responses.GetExtensionAnalytics>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetGameAnalytics>> GetGameAnalytics(
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

        return HelixResultFactory.Create<Responses.GetGameAnalytics>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetBitsLeaderboard>> GetBitsLeaderboard(
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

        return HelixResultFactory.Create<Responses.GetBitsLeaderboard>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetCheermotes>> GetCheermotes(
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCheermotes;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.GetCheermotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetExtensionTransactions>> GetExtensionTransactions(
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

        return HelixResultFactory.Create<Responses.GetExtensionTransactions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetChannelInformation>> GetChannelInformation(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelInformation;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.GetChannelInformation>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetChannelEditors>> GetChannelEditors(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelEditors;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.GetChannelEditors>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetFollowedChannels>> GetFollowedChannels(
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

        return HelixResultFactory.Create<Responses.GetFollowedChannels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetChannelFollowers>> GetChannelFollowers(
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

        return HelixResultFactory.Create<Responses.GetChannelFollowers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CreateCustomRewards>> CreateCustomReward(
        long broadcasterId,
        CreateCustomRewardBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateCustomRewards;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create<Responses.CreateCustomRewards>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetCustomReward>> GetCustomReward(
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

        return HelixResultFactory.Create<Responses.GetCustomReward>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetCustomRewardRedemption>> GetCustomRewardRedemption(
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

        return HelixResultFactory.Create<Responses.GetCustomRewardRedemption>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdateCustomReward>> UpdateCustomReward(
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
        return HelixResultFactory.Create<Responses.UpdateCustomReward>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdateRedemptionStatus>> UpdateRedemptionStatus(
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

        return HelixResultFactory.Create<Responses.UpdateRedemptionStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetCharityCampaign>> GetCharityCampaign(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCharityCampaign;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.GetCharityCampaign>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetCharityCampaignDonations>> GetCharityCampaignDonations(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCharityCampaignDonations;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Responses.GetCharityCampaignDonations>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetChatters>> GetChatters(
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

        return HelixResultFactory.Create<Responses.GetChatters>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetChannelEmotes>> GetChannelEmotes(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelEmotes;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.GetChannelEmotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetGlobalEmotes>> GetGlobalEmotes(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGlobalEmotes;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        return HelixResultFactory.Create<Responses.GetGlobalEmotes>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetEmoteSets>> GetEmoteSets(
        string emoteSetId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEmoteSets;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam("emote_set_id", emoteSetId);

        return HelixResultFactory.Create<Responses.GetEmoteSets>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetChatSettings>> GetChatSettings(
        long broadcasterId,
        long? moderatorId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChatSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<Responses.GetChatSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdateChatSettings>> UpdateChatSettings(
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
        return HelixResultFactory.Create<Responses.UpdateChatSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetUserBlockList>> GetUserBlockList(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserBlockList;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Responses.GetUserBlockList>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetUserChatColor>> GetUserChatColor(
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserChatColor;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<Responses.GetUserChatColor>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.CreateClip>> CreateClip(
        long broadcasterId,
        bool? hasDelay = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateClip;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.HasDelay, hasDelay);

        return HelixResultFactory.Create<Responses.CreateClip>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetClips>> GetClips(
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

        return HelixResultFactory.Create<Responses.GetClips>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetContentClassificationLabels>> GetContentClassificationLabels(
        LabelLocale? locale = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetContentClassificationLabels;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Locale, locale?.ToString().Replace('_', '-'));

        return HelixResultFactory.Create<Responses.GetContentClassificationLabels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetDropsEntitlements>> GetDropsEntitlements(
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

        return HelixResultFactory.Create<Responses.GetDropsEntitlements>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdateDropsEntitlements>> UpdateDropsEntitlements(
        IEnumerable<string>? entitlementIds = null,
        FulfillmentStatus? fulfillmentStatus = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateDropsEntitlements;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.EntitlementIds, entitlementIds)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString());


        return HelixResultFactory.Create<Responses.UpdateDropsEntitlements>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
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


        return HelixResultFactory.Create<Responses.GetExtensionConfigurationSegment>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetExtensionLiveChannels>> GetExtensionLiveChannels(
        string extensionId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionLiveChannels;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Responses.GetExtensionLiveChannels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetExtensionSecrets>> GetExtensionSecrets(
        string extensionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionSecrets;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId);

        return HelixResultFactory.Create<Responses.GetExtensionSecrets>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CreateExtensionSecret>> CreateExtensionSecret(
        string extensionId,
        int? delay = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateExtensionSecret;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Delay, delay);

        return HelixResultFactory.Create<Responses.CreateExtensionSecret>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetExtensions>> GetExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.ExtensionVersion, extensionVersion);

        return HelixResultFactory.Create<Responses.GetExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetReleasedExtensions>> GetReleasedExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetReleasedExtensions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.ExtensionVersion, extensionVersion);

        return HelixResultFactory.Create<Responses.GetReleasedExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetExtensionBitsProducts>> GetExtensionBitsProducts(
        bool? shouldIncludeAll = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionBitsProducts;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.ShouldIncludeAll, shouldIncludeAll);

        return HelixResultFactory.Create<Responses.GetExtensionBitsProducts>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdateExtensionBitsProduct>> UpdateExtensionBitsProduct(
        UpdateExtensionBitsProductBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateExtensionBitsProduct;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        request.Body = body;
        return HelixResultFactory.Create<Responses.UpdateExtensionBitsProduct>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CreateEventSubSubscription>> CreateEventSubSubscription(
        CreateEventSubSubscriptionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateEventSubSubscription;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        request.Body = body;
        return HelixResultFactory.Create<Responses.CreateEventSubSubscription>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetEventSubSubscriptions>> GetEventSubSubscriptions(
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

        return HelixResultFactory.Create<Responses.GetEventSubSubscriptions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetTopGames>> GetTopGames(
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetTopGames;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Responses.GetTopGames>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetGames>> GetGames(
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

        return HelixResultFactory.Create<Responses.GetGames>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetCreatorGoals>> GetCreatorGoals(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCreatorGoals;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.GetCreatorGoals>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetChannelGuestStarSettings>> GetChannelGuestStarSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelGuestStarSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<Responses.GetChannelGuestStarSettings>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetGuestStarSession>> GetGuestStarSession(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGuestStarSession;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<Responses.GetGuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CreateGuestStarSession>> CreateGuestStarSession(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateGuestStarSession;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.CreateGuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.EndGuestStarSession>> EndGuestStarSession(
        long broadcasterId,
        string sessionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndGuestStarSession;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.SessionId, sessionId);

        return HelixResultFactory.Create<Responses.EndGuestStarSession>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetGuestStarInvites>> GetGuestStarInvites(
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

        return HelixResultFactory.Create<Responses.GetGuestStarInvites>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetHypeTrainEvents>> GetHypeTrainEvents(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetHypeTrainEvents;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Responses.GetHypeTrainEvents>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CheckAutoModStatus>> CheckAutoModStatus(
        long broadcasterId,
        CheckAutoModStatusBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CheckAutoModStatus;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create<Responses.CheckAutoModStatus>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetAutoModSettings>> GetAutoModSettings(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetAutoModSettings;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<Responses.GetAutoModSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdateAutoModSettings>> UpdateAutoModSettings(
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
        return HelixResultFactory.Create<Responses.UpdateAutoModSettings>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetBannedUsers>> GetBannedUsers(
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

        return HelixResultFactory.Create<Responses.GetBannedUsers>(_client, request, endpoint, cancellationToken);
    }

    // TODO: fix this
    public Task<HelixResult<Responses.BanUser>> BanUser(
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

        return HelixResultFactory.Create<Responses.BanUser>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetBlockedTerms>> GetBlockedTerms(
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

        return HelixResultFactory.Create<Responses.GetBlockedTerms>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.AddBlockedTerm>> AddBlockedTerm(
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
        return HelixResultFactory.Create<Responses.AddBlockedTerm>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetModerators>> GetModerators(
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

        return HelixResultFactory.Create<Responses.GetModerators>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetVIPs>> GetVIPs(
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

        return HelixResultFactory.Create<Responses.GetVIPs>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.UpdateShieldModeStatus>> UpdateShieldModeStatus(
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
        return HelixResultFactory.Create<Responses.UpdateShieldModeStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetShieldModeStatus>> GetShieldModeStatus(
        long broadcasterId,
        long moderatorId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetShieldModeStatus;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<Responses.GetShieldModeStatus>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetPolls>> GetPolls(
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

        return HelixResultFactory.Create<Responses.GetPolls>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CreatePoll>> CreatePoll(
        CreatePollBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreatePoll;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        };

        return HelixResultFactory.Create<Responses.CreatePoll>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.EndPoll>> EndPoll(
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

        return HelixResultFactory.Create<Responses.EndPoll>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetPredictions>> GetPredictions(
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

        return HelixResultFactory.Create<Responses.GetPredictions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CreatePrediction>> CreatePrediction(
        CreatePredictionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreatePrediction;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        };

        return HelixResultFactory.Create<Responses.CreatePrediction>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.EndPrediction>> EndPrediction(
        EndPredictionBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndPrediction;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        };

        return HelixResultFactory.Create<Responses.EndPrediction>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.StartARaid>> StartARaid(
        long fromBroadcasterId,
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.StartARaid;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.FromBroadcasterId, fromBroadcasterId)
            .AddParam(QueryParams.ToBroadcasterId, toBroadcasterId);

        return HelixResultFactory.Create<Responses.StartARaid>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetChannelStreamSchedule>> GetChannelStreamSchedule(
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

        return HelixResultFactory.Create<Responses.GetChannelStreamSchedule>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.CreateChannelStreamScheduleSegment>> CreateChannelStreamScheduleSegment(
        long broadcasterId,
        ChannelStreamScheduleSegmentBody body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateChannelStreamScheduleSegment;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
        {
            Body = body
        }.AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.CreateChannelStreamScheduleSegment>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdateChannelStreamScheduleSegment>> UpdateChannelStreamScheduleSegment(
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

        return HelixResultFactory.Create<Responses.UpdateChannelStreamScheduleSegment>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.SearchCategories>> SearchCategories(
        string query,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SearchCategories;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Query, HttpUtility.UrlEncode(query))
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Responses.SearchCategories>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.SearchChannels>> SearchChannels(
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

        return HelixResultFactory.Create<Responses.SearchChannels>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetStreamKey>> GetStreamKey(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreamKey;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.GetStreamKey>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetStreams>> GetStreams(
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

        return HelixResultFactory.Create<Responses.GetStreams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetFollowedStreams>> GetFollowedStreams(
        long userId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetFollowedStreams;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Responses.GetFollowedStreams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CreateStreamMarker>> CreateStreamMarker(
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

        return HelixResultFactory.Create<Responses.CreateStreamMarker>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetStreamMarkers>> GetStreamMarkers(
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

        return HelixResultFactory.Create<Responses.GetStreamMarkers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetBroadcasterSubscriptions>> GetBroadcasterSubscriptions(
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

        return HelixResultFactory.Create<Responses.GetBroadcasterSubscriptions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.CheckUserSubscription>> CheckUserSubscription(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CheckUserSubscription;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<Responses.CheckUserSubscription>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetChannelTeams>> GetChannelTeams(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelTeams;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Responses.GetChannelTeams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetTeams>> GetTeams(
        string name,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetTeams;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Name, name)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create<Responses.GetTeams>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetUsers>> GetUsers(
        long id,
        string login,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUsers;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Login, login);

        return HelixResultFactory.Create<Responses.GetUsers>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdateUser>> UpdateUser(
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUser;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        return HelixResultFactory.Create<Responses.UpdateUser>(_client, request, endpoint, cancellationToken);
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

    public Task<HelixResult<Responses.GetUserExtensions>> GetUserExtensions(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserExtensions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        return HelixResultFactory.Create<Responses.GetUserExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetUserActiveExtensions>> GetUserActiveExtensions(
        long? userId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserActiveExtensions;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<Responses.GetUserActiveExtensions>(_client, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.GetVideos>> GetVideos(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVideos;
        var request = new RequestData(_baseUrl + endpoint.Route, endpoint.Method);
        return HelixResultFactory.Create<Responses.GetVideos>(_client, request, endpoint, cancellationToken);
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
}
