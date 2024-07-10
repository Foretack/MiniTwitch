using System.Net;

namespace MiniTwitch.Helix.Internal.Models;

// Values scraped from https://dev.twitch.tv/docs/api/reference/
// If you see anything wrong, please open an issue!
internal static class Endpoints
{
    public static readonly HelixEndpoint StartCommercial = new()
    {
        Method = HttpMethod.Post,
        Route = "/channels/commercial",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetExtensionAnalytics = new()
    {
        Method = HttpMethod.Get,
        Route = "/analytics/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetGameAnalytics = new()
    {
        Method = HttpMethod.Get,
        Route = "/analytics/games",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetBitsLeaderboard = new()
    {
        Method = HttpMethod.Get,
        Route = "/bits/leaderboard",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetCheermotes = new()
    {
        Method = HttpMethod.Get,
        Route = "/bits/cheermotes",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetExtensionTransactions = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/transactions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChannelInformation = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint ModifyChannelInformation = new()
    {
        Method = HttpMethod.Patch,
        Route = "/channels",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetChannelEditors = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/editors",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetFollowedChannels = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/followed",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChannelFollowers = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/followers",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CreateCustomRewards = new()
    {
        Method = HttpMethod.Post,
        Route = "/channel_points/custom_rewards",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint DeleteCustomReward = new()
    {
        Method = HttpMethod.Delete,
        Route = "/channel_points/custom_rewards",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetCustomReward = new()
    {
        Method = HttpMethod.Get,
        Route = "/channel_points/custom_rewards",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetCustomRewardRedemption = new()
    {
        Method = HttpMethod.Get,
        Route = "/channel_points/custom_rewards/redemptions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateCustomReward = new()
    {
        Method = HttpMethod.Patch,
        Route = "/channel_points/custom_rewards",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateRedemptionStatus = new()
    {
        Method = HttpMethod.Patch,
        Route = "/channel_points/custom_rewards/redemptions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetCharityCampaign = new()
    {
        Method = HttpMethod.Get,
        Route = "/charity/campaigns",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetCharityCampaignDonations = new()
    {
        Method = HttpMethod.Get,
        Route = "/charity/donations",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChatters = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/chatters",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChannelEmotes = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/emotes",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetGlobalEmotes = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/emotes/global",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetEmoteSets = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/emotes/set",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChannelChatBadges = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/badges",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetGlobalChatBadges = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/badges/global",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChatSettings = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/settings",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateChatSettings = new()
    {
        Method = HttpMethod.Patch,
        Route = "/chat/settings",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint SendChatAnnouncement = new()
    {
        Method = HttpMethod.Post,
        Route = "/chat/announcements",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint SendAShoutout = new()
    {
        Method = HttpMethod.Post,
        Route = "/chat/shoutouts",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetUserChatColor = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/color",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateUserChatColor = new()
    {
        Method = HttpMethod.Put,
        Route = "/chat/color",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint CreateClip = new()
    {
        Method = HttpMethod.Post,
        Route = "/clips",
        SuccessStatusCode = HttpStatusCode.Accepted,
    };

    public static readonly HelixEndpoint GetClips = new()
    {
        Method = HttpMethod.Get,
        Route = "/clips",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetConduits = new()
    {
        Method = HttpMethod.Get,
        Route = "/eventsub/conduits",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CreateConduits = new()
    {
        Method = HttpMethod.Post,
        Route = "/eventsub/conduits",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateConduits = new()
    {
        Method = HttpMethod.Patch,
        Route = "/eventsub/conduits",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint DeleteConduits = new()
    {
        Method = HttpMethod.Delete,
        Route = "/eventsub/conduits",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetConduitShards = new()
    {
        Method = HttpMethod.Get,
        Route = "/eventsub/conduits/shards",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateConduitShards = new()
    {
        Method = HttpMethod.Patch,
        Route = "/eventsub/conduits/shards",
        SuccessStatusCode = HttpStatusCode.Accepted,
    };

    public static readonly HelixEndpoint GetContentClassificationLabels = new()
    {
        Method = HttpMethod.Get,
        Route = "/content_classification_labels",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetDropsEntitlements = new()
    {
        Method = HttpMethod.Get,
        Route = "/entitlements/drops",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateDropsEntitlements = new()
    {
        Method = HttpMethod.Patch,
        Route = "/entitlements/drops",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetExtensionConfigurationSegment = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/configurations",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint SetExtensionConfigurationSegment = new()
    {
        Method = HttpMethod.Put,
        Route = "/extensions/configurations",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint SetExtensionRequiredConfiguration = new()
    {
        Method = HttpMethod.Put,
        Route = "/extensions/required_configuration",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint SendExtensionPubSubMessage = new()
    {
        Method = HttpMethod.Post,
        Route = "/extensions/pubsub",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetExtensionLiveChannels = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/live",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetExtensionSecrets = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/jwt/secrets",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CreateExtensionSecret = new()
    {
        Method = HttpMethod.Post,
        Route = "/extensions/jwt/secrets",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint SendExtensionChatMessage = new()
    {
        Method = HttpMethod.Post,
        Route = "/extensions/chat",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetExtensions = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetReleasedExtensions = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/released",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetExtensionBitsProducts = new()
    {
        Method = HttpMethod.Get,
        Route = "/bits/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateExtensionBitsProduct = new()
    {
        Method = HttpMethod.Put,
        Route = "/bits/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CreateEventSubSubscription = new()
    {
        Method = HttpMethod.Post,
        Route = "/eventsub/subscriptions",
        SuccessStatusCode = HttpStatusCode.Accepted,
    };

    public static readonly HelixEndpoint DeleteEventSubSubscription = new()
    {
        Method = HttpMethod.Delete,
        Route = "/eventsub/subscriptions",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetEventSubSubscriptions = new()
    {
        Method = HttpMethod.Get,
        Route = "/eventsub/subscriptions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetTopGames = new()
    {
        Method = HttpMethod.Get,
        Route = "/games/top",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetGames = new()
    {
        Method = HttpMethod.Get,
        Route = "/games",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetCreatorGoals = new()
    {
        Method = HttpMethod.Get,
        Route = "/goals",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChannelGuestStarSettings = new()
    {
        Method = HttpMethod.Get,
        Route = "/guest_star/channel_settings",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateChannelGuestStarSettings = new()
    {
        Method = HttpMethod.Put,
        Route = "/guest_star/channel_settings",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetGuestStarSession = new()
    {
        Method = HttpMethod.Get,
        Route = "/guest_star/session",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CreateGuestStarSession = new()
    {
        Method = HttpMethod.Post,
        Route = "/guest_star/session",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint EndGuestStarSession = new()
    {
        Method = HttpMethod.Delete,
        Route = "/guest_star/session",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetGuestStarInvites = new()
    {
        Method = HttpMethod.Get,
        Route = "/guest_star/invites",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint SendGuestStarInvite = new()
    {
        Method = HttpMethod.Post,
        Route = "/guest_star/invites",
    };

    public static readonly HelixEndpoint DeleteGuestStarInvite = new()
    {
        Method = HttpMethod.Delete,
        Route = "/guest_star/invites",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint AssignGuestStarSlot = new()
    {
        Method = HttpMethod.Post,
        Route = "/guest_star/slot",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint UpdateGuestStarSlot = new()
    {
        Method = HttpMethod.Patch,
        Route = "/guest_star/slot",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint DeleteGuestStarSlot = new()
    {
        Method = HttpMethod.Delete,
        Route = "/guest_star/slot",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint UpdateGuestStarSlotSettings = new()
    {
        Method = HttpMethod.Patch,
        Route = "/guest_star/slot_settings",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetHypeTrainEvents = new()
    {
        Method = HttpMethod.Get,
        Route = "/hypetrain/events",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CheckAutoModStatus = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/enforcements/status",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint ManageHeldAutoModMessages = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/automod/message",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetAutoModSettings = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/automod/settings",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateAutoModSettings = new()
    {
        Method = HttpMethod.Put,
        Route = "/moderation/automod/settings",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetBannedUsers = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/banned",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint BanUser = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/bans",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UnbanUser = new()
    {
        Method = HttpMethod.Delete,
        Route = "/moderation/bans",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetBlockedTerms = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/blocked_terms",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint AddBlockedTerm = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/blocked_terms",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint RemoveBlockedTerm = new()
    {
        Method = HttpMethod.Delete,
        Route = "/moderation/blocked_terms",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint DeleteChatMessages = new()
    {
        Method = HttpMethod.Delete,
        Route = "/moderation/chat",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetModerators = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/moderators",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint AddChannelModerator = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/moderators",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint RemoveChannelModerator = new()
    {
        Method = HttpMethod.Delete,
        Route = "/moderation/moderators",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetVIPs = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/vips",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint AddChannelVIP = new()
    {
        Method = HttpMethod.Post,
        Route = "/channels/vips",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint RemoveChannelVIP = new()
    {
        Method = HttpMethod.Delete,
        Route = "/channels/vips",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint UpdateShieldModeStatus = new()
    {
        Method = HttpMethod.Put,
        Route = "/moderation/shield_mode",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetShieldModeStatus = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/shield_mode",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetPolls = new()
    {
        Method = HttpMethod.Get,
        Route = "/polls",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CreatePoll = new()
    {
        Method = HttpMethod.Post,
        Route = "/polls",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint EndPoll = new()
    {
        Method = HttpMethod.Patch,
        Route = "/polls",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetPredictions = new()
    {
        Method = HttpMethod.Get,
        Route = "/predictions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CreatePrediction = new()
    {
        Method = HttpMethod.Post,
        Route = "/predictions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint EndPrediction = new()
    {
        Method = HttpMethod.Patch,
        Route = "/predictions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint StartARaid = new()
    {
        Method = HttpMethod.Post,
        Route = "/raids",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CancelARaid = new()
    {
        Method = HttpMethod.Delete,
        Route = "/raids",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetChannelStreamSchedule = new()
    {
        Method = HttpMethod.Get,
        Route = "/schedule",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChannelICalendar = new()
    {
        Method = HttpMethod.Get,
        Route = "/schedule/icalendar",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateChannelStreamSchedule = new()
    {
        Method = HttpMethod.Patch,
        Route = "/schedule/settings",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint CreateChannelStreamScheduleSegment = new()
    {
        Method = HttpMethod.Post,
        Route = "/schedule/segment",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateChannelStreamScheduleSegment = new()
    {
        Method = HttpMethod.Patch,
        Route = "/schedule/segment",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint DeleteChannelStreamScheduleSegment = new()
    {
        Method = HttpMethod.Delete,
        Route = "/schedule/segment",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint SearchCategories = new()
    {
        Method = HttpMethod.Get,
        Route = "/search/categories",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint SearchChannels = new()
    {
        Method = HttpMethod.Get,
        Route = "/search/channels",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetSoundtrackCurrentTrack = new()
    {
        Method = HttpMethod.Get,
        Route = "/soundtrack/current_track",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetSoundtrackPlaylist = new()
    {
        Method = HttpMethod.Get,
        Route = "/soundtrack/playlist",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetSoundtrackPlaylists = new()
    {
        Method = HttpMethod.Get,
        Route = "/soundtrack/playlists",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetStreamKey = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams/key",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetStreams = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetFollowedStreams = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams/followed",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CreateStreamMarker = new()
    {
        Method = HttpMethod.Post,
        Route = "/streams/markers",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetStreamMarkers = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams/markers",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetBroadcasterSubscriptions = new()
    {
        Method = HttpMethod.Get,
        Route = "/subscriptions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint CheckUserSubscription = new()
    {
        Method = HttpMethod.Get,
        Route = "/subscriptions/user",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetAllStreamTags = new()
    {
        Method = HttpMethod.Get,
        Route = "/tags/streams",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetStreamTags = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams/tags",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetChannelTeams = new()
    {
        Method = HttpMethod.Get,
        Route = "/teams/channel",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetTeams = new()
    {
        Method = HttpMethod.Get,
        Route = "/teams",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetUsers = new()
    {
        Method = HttpMethod.Get,
        Route = "/users",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateUser = new()
    {
        Method = HttpMethod.Put,
        Route = "/users",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetUsersFollows = new()
    {
        Method = HttpMethod.Get,
        Route = "/users/follows",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetUserBlockList = new()
    {
        Method = HttpMethod.Get,
        Route = "/users/blocks",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint BlockUser = new()
    {
        Method = HttpMethod.Put,
        Route = "/users/blocks",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint UnblockUser = new()
    {
        Method = HttpMethod.Delete,
        Route = "/users/blocks",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint GetUserExtensions = new()
    {
        Method = HttpMethod.Get,
        Route = "/users/extensions/list",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetUserActiveExtensions = new()
    {
        Method = HttpMethod.Get,
        Route = "/users/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint UpdateUserExtensions = new()
    {
        Method = HttpMethod.Put,
        Route = "/users/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetVideos = new()
    {
        Method = HttpMethod.Get,
        Route = "/videos",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint DeleteVideos = new()
    {
        Method = HttpMethod.Delete,
        Route = "/videos",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint SendWhisper = new()
    {
        Method = HttpMethod.Post,
        Route = "/whispers",
        SuccessStatusCode = HttpStatusCode.NoContent,
    };

    public static readonly HelixEndpoint SnoozeNextAd = new()
    {
        Method = HttpMethod.Post,
        Route = "/channels/ads/schedule/snooze",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetAdSchedule = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/ads",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetModeratedChannels = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/channels",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint SendChatMessage = new()
    {
        Method = HttpMethod.Post,
        Route = "/chat/messages",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetUserEmotes = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/emotes/user",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint GetUnbanRequests = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/unban_requests",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint ResolveUnbanRequests = new()
    {
        Method = HttpMethod.Patch,
        Route = "/moderation/unban_requests",
        SuccessStatusCode = HttpStatusCode.OK,
    };

    public static readonly HelixEndpoint WarnChatUser = new()
    {
        Method = HttpMethod.Post,
        Route = "moderation/warnings",
        SuccessStatusCode = HttpStatusCode.OK,
    };
}
