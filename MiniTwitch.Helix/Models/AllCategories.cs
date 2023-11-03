using System.Web;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Internal.Models;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class AllCategories
{
    internal HelixApiClient ApiClient { get; }
    private long UserId => ApiClient.UserId;

    private readonly string _baseUrl;

    internal AllCategories(HelixApiClient client, string baseUrl)
    {
        this.ApiClient = client;
        _baseUrl = baseUrl;
    }


    public Task<HelixResult<Commercial>> StartCommercial(
        NewCommercial body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.StartCommercial;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };

        return HelixResultFactory.Create<Commercial>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionAnalytics>> GetExtensionAnalytics(
        string? extensionId = null,
        AnalyticsType? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionAnalytics;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Type, type?.ToString().ToLower())
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ExtensionAnalytics>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GameAnalytics>> GetGameAnalytics(
        string? gameId = null,
        AnalyticsType? type = null,
        DateTime? startedAt = null,
        DateTime? endedAt = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGameAnalytics;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Type, type?.ToString().ToLower())
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<GameAnalytics>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BitsLeaderboard>> GetBitsLeaderboard(
        int? count = null,
        BitsLeaderboardPeriod? period = null,
        DateTime? startedAt = null,
        long? UserId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBitsLeaderboard;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Count, count)
            .AddParam(QueryParams.Period, period?.ToString().ToLower())
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.UserId, UserId);

        return HelixResultFactory.Create<BitsLeaderboard>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Cheermotes>> GetCheermotes(
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCheermotes;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Cheermotes>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionTransactions>> GetExtensionTransactions(
        string extensionId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionTransactions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ExtensionTransactions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionTransactions>> GetExtensionTransactions(
        string extensionId,
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionTransactions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ExtensionTransactions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelsInformation>> GetChannelInformation(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelInformation;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<ChannelsInformation>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelsInformation>> GetChannelInformation(
        IEnumerable<long> broadcasterIds,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelInformation;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.BroadcasterId, broadcasterIds);

        return HelixResultFactory.Create<ChannelsInformation>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> ModifyChannelInformation(
        NewChannelInformation body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.ModifyChannelInformation;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        request.Body = body;
        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelEditors>> GetChannelEditors(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelEditors;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        return HelixResultFactory.Create<ChannelEditors>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<FollowedChannels>> GetFollowedChannels(
        long? broadcasterId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetFollowedChannels;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, this.UserId)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<FollowedChannels>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelFollowers>> GetChannelFollowers(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelFollowers;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ChannelFollowers>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomReward>> CreateCustomReward(
        NewCustomReward body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateCustomRewards;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        request.Body = body;
        return HelixResultFactory.Create<CustomReward>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteCustomReward(
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteCustomReward;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomReward>> GetCustomReward(
        string? id = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomReward;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.OnlyManageableRewards, onlyManageableRewards);

        return HelixResultFactory.Create<CustomReward>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomReward>> GetCustomReward(
        IEnumerable<string>? ids = null,
        bool onlyManageableRewards = false,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomReward;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.OnlyManageableRewards, onlyManageableRewards);

        return HelixResultFactory.Create<CustomReward>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        string rewardId,
        RewardRedemptionStatus status,
        string? id = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomRewardRedemption;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.RewardId, rewardId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Status, status.ToString())
            .AddParam(QueryParams.Sort, sort?.ToString())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<CustomRewardRedemptions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomRewardRedemptions>> GetCustomRewardRedemption(
        string rewardId,
        RewardRedemptionStatus status,
        IEnumerable<string>? ids = null,
        SortMethod? sort = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCustomRewardRedemption;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.RewardId, rewardId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.Status, status.ToString())
            .AddParam(QueryParams.Sort, sort?.ToString())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<CustomRewardRedemptions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomReward>> UpdateCustomReward(
        string id,
        UpdatedCustomReward body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateCustomReward;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.Id, id);

        request.Body = body;
        return HelixResultFactory.Create<CustomReward>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomRewardRedemption>> UpdateRedemptionStatus(
        string id,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateRedemptionStatus;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.RewardId, rewardId);

        request.Body = new
        {
            status = status.ToString()
        };

        return HelixResultFactory.Create<CustomRewardRedemption>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CustomRewardRedemptions>> UpdateRedemptionStatus(
        IEnumerable<string> ids,
        string rewardId,
        RewardRedemptionStatus status,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateRedemptionStatus;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.RewardId, rewardId);

        request.Body = new
        {
            status = status.ToString()
        };

        return HelixResultFactory.Create<CustomRewardRedemptions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CharityCampaign>> GetCharityCampaign(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCharityCampaign;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        return HelixResultFactory.Create<CharityCampaign>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CharityCampaignDonations>> GetCharityCampaignDonations(
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCharityCampaignDonations;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<CharityCampaignDonations>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Chatters>> GetChatters(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChatters;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Chatters>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Emotes>> GetChannelEmotes(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelEmotes;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<Emotes>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Emotes>> GetGlobalEmotes(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGlobalEmotes;
        var request = new RequestData(_baseUrl, endpoint);
        return HelixResultFactory.Create<Emotes>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EmoteSets>> GetEmoteSets(
        string emoteSetId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEmoteSets;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam("emote_set_id", emoteSetId);

        return HelixResultFactory.Create<EmoteSets>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EmoteSets>> GetEmoteSets(
        IEnumerable<string> emoteSetIds,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEmoteSets;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam("emote_set_id", emoteSetIds);

        return HelixResultFactory.Create<EmoteSets>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChatSettings>> GetChatSettings(
        long broadcasterId,
        long? moderatorId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChatSettings;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, moderatorId);

        return HelixResultFactory.Create<ChatSettings>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChatSettings>> UpdateChatSettings(
        long broadcasterId,
        NewChatSettings body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChatSettings;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        request.Body = body;
        return HelixResultFactory.Create<ChatSettings>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BlockList>> GetUserBlockList(
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserBlockList;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BlockList>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendChatAnnouncement(
        long broadcasterId,
        Announcement body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendChatAnnouncement;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        request.Body = body;
        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendAShoutout(
        long fromBroadcasterId,
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendAShoutout;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.FromBroadcasterId, fromBroadcasterId)
            .AddParam(QueryParams.ToBroadcasterId, toBroadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UsersChatColor>> GetUserChatColor(
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserChatColor;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<UsersChatColor>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UsersChatColor>> GetUserChatColor(
        IEnumerable<long> userIds,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserChatColor;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.UserId, userIds);

        return HelixResultFactory.Create<UsersChatColor>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateUserChatColor(
        ChatColor color,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUserChatColor;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, this.UserId)
            .AddParam(QueryParams.Color, SnakeCase.Instance.ConvertToCase(color.ToString()));

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateUserChatColor(
        string hexColor,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUserChatColor;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, this.UserId)
            .AddParam(QueryParams.Color, HttpUtility.UrlEncode(hexColor));

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Clip>> CreateClip(
        long broadcasterId,
        bool? hasDelay = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateClip;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.HasDelay, hasDelay);

        return HelixResultFactory.Create<Clip>(this.ApiClient, request, endpoint, cancellationToken);
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
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first)
            .AddParam(QueryParams.IsFeatured, isFeatured);

        return HelixResultFactory.Create<Clips>(this.ApiClient, request, endpoint, cancellationToken);
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
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.GameId, gameId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.StartedAt, startedAt)
            .AddParam(QueryParams.EndedAt, endedAt)
            .AddParam(QueryParams.First, first)
            .AddParam(QueryParams.IsFeatured, isFeatured);

        return HelixResultFactory.Create<Clips>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ContentClassificationLabels>> GetContentClassificationLabels(
        LabelLocale? locale = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetContentClassificationLabels;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Locale, locale?.ToString().Replace('_', '-'));

        return HelixResultFactory.Create<ContentClassificationLabels>(this.ApiClient, request, endpoint, cancellationToken);
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
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<DropsEntitlements>(this.ApiClient, request, endpoint, cancellationToken);
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
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<DropsEntitlements>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdatedDropsEntitlements>> UpdateDropsEntitlements(
        IEnumerable<string>? entitlementIds = null,
        FulfillmentStatus? fulfillmentStatus = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateDropsEntitlements;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.EntitlementIds, entitlementIds)
            .AddParam(QueryParams.FulfillmentStatus, fulfillmentStatus?.ToString());


        return HelixResultFactory.Create<UpdatedDropsEntitlements>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.ExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        ConfigSegmentType segment,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionConfigurationSegment;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Segment, segment.ToString().ToLower())
            .AddParam(QueryParams.BroadcasterId, broadcasterId);


        return HelixResultFactory.Create<Responses.ExtensionConfigurationSegment>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.ExtensionConfigurationSegment>> GetExtensionConfigurationSegment(
        string extensionId,
        IEnumerable<ConfigSegmentType> segments,
        long? broadcasterId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionConfigurationSegment;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddMultiParam(QueryParams.Segment, segments.Select(x => x.ToString().ToLower()))
            .AddParam(QueryParams.BroadcasterId, broadcasterId);


        return HelixResultFactory.Create<Responses.ExtensionConfigurationSegment>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SetExtensionConfigurationSegment(
        ConfigurationSegment body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SetExtensionConfigurationSegment;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };
        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SetExtensionRequiredConfiguration(
        long broadcasterId,
        ExtensionRequiredConfiguration body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SetExtensionRequiredConfiguration;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };
        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendExtensionPubSubMessage(
        ExtensionPubSubMessage body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendExtensionPubSubMessage;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };
        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionLiveChannels>> GetExtensionLiveChannels(
        string extensionId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionLiveChannels;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<ExtensionLiveChannels>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionSecrets>> GetExtensionSecrets(
        string extensionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionSecrets;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId);

        return HelixResultFactory.Create<ExtensionSecrets>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionSecrets>> CreateExtensionSecret(
        string extensionId,
        int? delay = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateExtensionSecret;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.Delay, delay);

        return HelixResultFactory.Create<ExtensionSecrets>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendExtensionChatMessage(
        long broadcasterId,
        ExtensionChatMessage body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendExtensionChatMessage;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        request.Body = body;
        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelExtensions>> GetExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.ExtensionVersion, extensionVersion);

        return HelixResultFactory.Create<ChannelExtensions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ReleasedExtensions>> GetReleasedExtensions(
        string extensionId,
        string? extensionVersion = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetReleasedExtensions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ExtensionId, extensionId)
            .AddParam(QueryParams.ExtensionVersion, extensionVersion);

        return HelixResultFactory.Create<ReleasedExtensions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionBitsProducts>> GetExtensionBitsProducts(
        bool? shouldIncludeAll = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetExtensionBitsProducts;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.ShouldIncludeAll, shouldIncludeAll);

        return HelixResultFactory.Create<ExtensionBitsProducts>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ExtensionBitsProducts>> UpdateExtensionBitsProduct(
        UpdatedBitsProduct body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateExtensionBitsProduct;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };
        return HelixResultFactory.Create<ExtensionBitsProducts>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreatedSubscription>> CreateEventSubSubscription(
        NewSubscription body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateEventSubSubscription;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };
        return HelixResultFactory.Create<CreatedSubscription>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteEventSubSubscription(
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteEventSubSubscription;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<EventSubSubscriptions>> GetEventSubSubscriptions(
        EventSubStatus? status = null,
        string? type = null,
        long? userId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetEventSubSubscriptions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Status, SnakeCase.Instance.ConvertToCase(status.ToString()))
            .AddParam(QueryParams.Type, type)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create<EventSubSubscriptions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Games>> GetTopGames(
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetTopGames;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Games>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Games>> GetGames(
        string? id = null,
        string? name = null,
        string? igdbId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGames;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Name, name)
            .AddParam(QueryParams.IgdbId, igdbId);

        return HelixResultFactory.Create<Games>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Games>> GetGames(
        IEnumerable<string>? ids = null,
        IEnumerable<string>? names = null,
        IEnumerable<string>? igdbIds = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGames;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, ids)
            .AddMultiParam(QueryParams.Name, names)
            .AddMultiParam(QueryParams.IgdbId, igdbIds);

        return HelixResultFactory.Create<Games>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<CreatorGoals>> GetCreatorGoals(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetCreatorGoals;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        return HelixResultFactory.Create<CreatorGoals>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelGuestStarSettings>> GetChannelGuestStarSettings(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelGuestStarSettings;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        return HelixResultFactory.Create<ChannelGuestStarSettings>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateChannelGuestStarSettings(
        NewGuestStarSettings body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChannelGuestStarSettings;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        }.AddParam(QueryParams.BroadcasterId, this.UserId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GuestStarSession>> GetGuestStarSession(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGuestStarSession;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        return HelixResultFactory.Create<GuestStarSession>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GuestStarSession>> CreateGuestStarSession(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateGuestStarSession;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        return HelixResultFactory.Create<GuestStarSession>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GuestStarSession>> EndGuestStarSession(
        string sessionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndGuestStarSession;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.SessionId, sessionId);

        return HelixResultFactory.Create<GuestStarSession>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<GuestStarInvites>> GetGuestStarInvites(
        long broadcasterId,
        string sessionId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGuestStarInvites;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(sessionId, sessionId);

        return HelixResultFactory.Create<GuestStarInvites>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendGuestStarInvite(
        long broadcasterId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendGuestStarInvite;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.GuestId, guestId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteGuestStarInvite(
        long broadcasterId,
        string sessionId,
        long guestId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteGuestStarInvite;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.GuestId, guestId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> AssignGuestStarSlot(
        long broadcasterId,
        string sessionId,
        long guestId,
        string slotId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AssignGuestStarSlot;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.GuestId, guestId)
            .AddParam(QueryParams.SlotId, slotId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateGuestStarSlot(
        long broadcasterId,
        string sessionId,
        string sourceSlotId,
        string? destinationSlotId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateGuestStarSlot;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.SourceSlotId, sourceSlotId)
            .AddParam(QueryParams.DestinationSlotId, destinationSlotId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteGuestStarSlot(
        long broadcasterId,
        string sessionId,
        long guestId,
        string slotId,
        string? shouldReinviteGuest = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteGuestStarSlot;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.GuestId, guestId)
            .AddParam(QueryParams.SlotId, slotId)
            .AddParam(QueryParams.ShouldReinviteGuest, shouldReinviteGuest);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateGuestStarSlotSettings(
        long broadcasterId,
        string sessionId,
        string slotId,
        bool? isAudioEnabled = null,
        bool? isVideoEnabled = null,
        bool? isLive = null,
        int? volume = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateGuestStarSlotSettings;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.SessionId, sessionId)
            .AddParam(QueryParams.SlotId, slotId)
            .AddParam(QueryParams.IsAudioEnabled, isAudioEnabled)
            .AddParam(QueryParams.IsVideoEnabled, isVideoEnabled)
            .AddParam(QueryParams.IsLive, isLive)
            .AddParam(QueryParams.Volume, volume);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<HypeTrainEvents>> GetHypeTrainEvents(
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetHypeTrainEvents;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<HypeTrainEvents>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AutoModStatus>> CheckAutoModStatus(
        MessageToCheck body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CheckAutoModStatus;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        request.Body = body;
        return HelixResultFactory.Create<AutoModStatus>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> ManageHeldAutoModMessages(
        string msgId,
        string action,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.ManageHeldAutoModMessages;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, this.UserId)
            .AddParam(QueryParams.MsgId, msgId)
            .AddParam(QueryParams.Action, action);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AutoModSettings>> GetAutoModSettings(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetAutoModSettings;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        return HelixResultFactory.Create<AutoModSettings>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AutoModSettings>> UpdateAutoModSettings(
        long broadcasterId,
        NewAutoModSettings body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateAutoModSettings;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        request.Body = body;
        return HelixResultFactory.Create<AutoModSettings>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBannedUsers;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BannedUsers>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BannedUsers>> GetBannedUsers(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBannedUsers;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BannedUsers>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BannedUser>> BanUser(
        long broadcasterId,
        UserToBan body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.BanUser;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        request.Body = body;
        return HelixResultFactory.Create<BannedUser>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UnbanUser(
        long broadcasterId,
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UnbanUser;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BlockedTerms>> GetBlockedTerms(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBlockedTerms;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BlockedTerms>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BlockedTerms>> AddBlockedTerm(
        long broadcasterId,
        string text,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddBlockedTerm;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        request.Body = new { text };
        return HelixResultFactory.Create<BlockedTerms>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> RemoveBlockedTerm(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.RemoveBlockedTerm;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteChatMessages(
        long broadcasterId,
        string? messageId = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteChatMessages;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId)
            .AddParam(QueryParams.MessageId, messageId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Moderators>> GetModerators(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetModerators;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Moderators>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Moderators>> GetModerators(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetModerators;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Moderators>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> AddChannelModerator(
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddChannelModerator;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> RemoveChannelModerator(
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.RemoveChannelModerator;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<VIPs>> GetVIPs(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVIPs;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<VIPs>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<VIPs>> GetVIPs(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetVIPs;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<VIPs>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> AddChannelVIP(
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.AddChannelVIP;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> RemoveChannelVIP(
        long userId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.RemoveChannelVIP;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ShieldModeStatus>> UpdateShieldModeStatus(
        long broadcasterId,
        bool isActive,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateShieldModeStatus;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        request.Body = new { is_active = isActive };
        return HelixResultFactory.Create<ShieldModeStatus>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ShieldModeStatus>> GetShieldModeStatus(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetShieldModeStatus;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.ModeratorId, this.UserId);

        return HelixResultFactory.Create<ShieldModeStatus>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Polls>> GetPolls(
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPolls;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Polls>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Polls>> GetPolls(
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPolls;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Polls>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Poll>> CreatePoll(
        NewPoll body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreatePoll;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };

        return HelixResultFactory.Create<Poll>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Poll>> EndPoll(
        string id,
        string status,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndPoll;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Status, status);

        return HelixResultFactory.Create<Poll>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Predictions>> GetPredictions(
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPredictions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Predictions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Predictions>> GetPredictions(
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetPredictions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Predictions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Prediction>> CreatePrediction(
        NewPrediction body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreatePrediction;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };

        return HelixResultFactory.Create<Prediction>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Prediction>> EndPrediction(
        PredictionToEnd body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.EndPrediction;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        };

        return HelixResultFactory.Create<Prediction>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Raid>> StartRaid(
        long toBroadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.StartARaid;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.FromBroadcasterId, this.UserId)
            .AddParam(QueryParams.ToBroadcasterId, toBroadcasterId);

        return HelixResultFactory.Create<Raid>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> CancelRaid(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CancelARaid;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        string? id = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelStreamSchedule;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.StartTime, startTime)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<StreamSchedule>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelStreamSchedule;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.StartTime, startTime)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<StreamSchedule>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UpdateChannelStreamSchedule(
        bool? isVacationEnabled = null,
        DateTime? vacationStartTime = null,
        DateTime? vacationEndTime = null,
        string? timezone = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChannelStreamSchedule;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.IsVacationEnabled, isVacationEnabled)
            .AddParam(QueryParams.VacationStartTime, vacationStartTime)
            .AddParam(QueryParams.VacationEndTime, vacationEndTime)
            .AddParam(QueryParams.Timezone, timezone);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ScheduleSegment>> CreateChannelStreamScheduleSegment(
        NewScheduleSegment body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateChannelStreamScheduleSegment;
        RequestData request = new RequestData(_baseUrl, endpoint)
        {
            Body = body
        }.AddParam(QueryParams.BroadcasterId, this.UserId);

        return HelixResultFactory.Create<ScheduleSegment>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Responses.UpdatedScheduleSegment>> UpdateChannelStreamScheduleSegment(
        string id,
        Requests.UpdatedScheduleSegment Body,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateChannelStreamScheduleSegment;
        RequestData request = new RequestData(_baseUrl, endpoint)
        {
            Body = Body
        }
        .AddParam(QueryParams.BroadcasterId, this.UserId)
        .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create<Responses.UpdatedScheduleSegment>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteChannelStreamScheduleSegment(
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteChannelStreamScheduleSegment;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Categories>> SearchCategories(
        string query,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SearchCategories;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Query, HttpUtility.UrlEncode(query))
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Categories>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Channels>> SearchChannels(
        string query,
        bool? liveOnly = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SearchChannels;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Query, query)
            .AddParam(QueryParams.LiveOnly, liveOnly)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Channels>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamKey>> GetStreamKey(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreamKey;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId);

        return HelixResultFactory.Create<StreamKey>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Streams>> GetStreams(
        long? userId = null,
        string? userLogin = null,
        string? gameId = null,
        StreamTypes? type = null,
        string? language = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreams;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.UserLogin, userLogin)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Type, type?.ToString().ToLower())
            .AddParam(QueryParams.Language, language)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Streams>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Streams>> GetStreams(
        IEnumerable<long>? userIds = null,
        IEnumerable<string>? userLogins = null,
        IEnumerable<string>? gameIds = null,
        StreamTypes? type = null,
        IEnumerable<string>? languages = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreams;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddMultiParam(QueryParams.UserLogin, userLogins)
            .AddMultiParam(QueryParams.GameId, gameIds)
            .AddParam(QueryParams.Type, type?.ToString().ToLower())
            .AddMultiParam(QueryParams.Language, languages)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Streams>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<FollowedStreams>> GetFollowedStreams(
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetFollowedStreams;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, this.UserId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<FollowedStreams>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamMarker>> CreateStreamMarker(
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CreateStreamMarker;
        var request = new RequestData(_baseUrl, endpoint)
        {
            Body = new
            {
                user_id = this.UserId,
                description
            }
        };

        return HelixResultFactory.Create<StreamMarker>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<StreamMarkers>> GetStreamMarkers(
        string? videoId,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetStreamMarkers;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, this.UserId)
            .AddParam(QueryParams.VideoId, videoId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<StreamMarkers>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBroadcasterSubscriptions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BroadcasterSubscriptions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<BroadcasterSubscriptions>> GetBroadcasterSubscriptions(
        IEnumerable<long>? userIds = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetBroadcasterSubscriptions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, this.UserId)
            .AddMultiParam(QueryParams.UserId, userIds)
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<BroadcasterSubscriptions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UserSubscription>> CheckUserSubscription(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.CheckUserSubscription;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId)
            .AddParam(QueryParams.UserId, this.UserId);

        return HelixResultFactory.Create<UserSubscription>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChannelTeams>> GetChannelTeams(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelTeams;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<ChannelTeams>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Teams>> GetTeams(
        string name,
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetTeams;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Name, name)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create<Teams>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Users>> GetUsers(
        long? id = null,
        string? login = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUsers;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.Login, login);

        return HelixResultFactory.Create<Users>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<Users>> GetUsers(
        IEnumerable<long>? id = null,
        IEnumerable<string>? login = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUsers;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, id)
            .AddMultiParam(QueryParams.Login, login);

        return HelixResultFactory.Create<Users>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UpdatedUser>> UpdateUser(
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UpdateUser;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam("description", description);

        return HelixResultFactory.Create<UpdatedUser>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> BlockUser(
        long targetUserId,
        string? sourceContext = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.BlockUser;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.TargetUserId, targetUserId)
            .AddParam(QueryParams.SourceContext, sourceContext)
            .AddParam(QueryParams.Reason, reason);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> UnblockUser(
        long targetUserId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.UnblockUser;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.TargetUserId, targetUserId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<UserExtensions>> GetUserExtensions(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserExtensions;
        var request = new RequestData(_baseUrl, endpoint);
        return HelixResultFactory.Create<UserExtensions>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ActiveExtensions>> GetUserActiveExtensions(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetUserActiveExtensions;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.UserId, this.UserId);

        return HelixResultFactory.Create<ActiveExtensions>(this.ApiClient, request, endpoint, cancellationToken);
    }

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
    {
        HelixEndpoint endpoint = Endpoints.GetVideos;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Language, language)
            .AddParam(QueryParams.Period, period?.ToString().ToLower())
            .AddParam(QueryParams.Sort, sort?.ToString().ToLower())
            .AddParam(QueryParams.Type, type?.ToString().ToLower())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Videos>(this.ApiClient, request, endpoint, cancellationToken);
    }

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
    {
        HelixEndpoint endpoint = Endpoints.GetVideos;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, ids)
            .AddParam(QueryParams.UserId, userId)
            .AddParam(QueryParams.GameId, gameId)
            .AddParam(QueryParams.Language, language)
            .AddParam(QueryParams.Period, period?.ToString().ToLower())
            .AddParam(QueryParams.Sort, sort?.ToString().ToLower())
            .AddParam(QueryParams.Type, type?.ToString().ToLower())
            .AddParam(QueryParams.First, first);

        return HelixResultFactory.Create<Videos>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteVideos(
        string id,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteVideos;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.Id, id);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> DeleteVideos(
        IEnumerable<string> ids,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.DeleteVideos;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddMultiParam(QueryParams.Id, ids);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult> SendWhisper(
        long toUserId,
        string message,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SendWhisper;
        RequestData request = new RequestData(_baseUrl, endpoint)
        {
            Body = new
            {
                message
            }
        }
        .AddParam(QueryParams.FromUserId, this.UserId)
        .AddParam(QueryParams.ToUserId, toUserId);

        return HelixResultFactory.Create(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<AdSchedule>> GetAdSchedule(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetAdSchedule;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<AdSchedule>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<SnoozedAd>> SnoozeNextAd(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.SnoozeNextAd;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<SnoozedAd>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChatBadges>> GetGlobalChatBadges(CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetGlobalChatBadges;
        var request = new RequestData(_baseUrl, endpoint);
        return HelixResultFactory.Create<ChatBadges>(this.ApiClient, request, endpoint, cancellationToken);
    }

    public Task<HelixResult<ChatBadges>> GetChannelChatBadges(
        long broadcasterId,
        CancellationToken cancellationToken = default)
    {
        HelixEndpoint endpoint = Endpoints.GetChannelChatBadges;
        RequestData request = new RequestData(_baseUrl, endpoint)
            .AddParam(QueryParams.BroadcasterId, broadcasterId);

        return HelixResultFactory.Create<ChatBadges>(this.ApiClient, request, endpoint, cancellationToken);
    }
}
