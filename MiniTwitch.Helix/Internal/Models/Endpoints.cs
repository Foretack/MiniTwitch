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
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully started the commercial.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe length query parameter is required.\r\nThe ID in broadcaster_id is not valid.\r\nTo start a commercial, the broadcaster must be streaming live.\r\nThe broadcaster may not run another commercial until the cooldown period expires.\r\n The retry_after field in the previous start commercial response specifies the amount of time the broadcaster must wait between running commercials.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID found in the request's OAuth token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:edit:commercial scope.\r\nThe OAuth token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            HttpStatusCode.NotFound => "The ID in broadcaster_id was not found.",
            HttpStatusCode.TooManyRequests => "The broadcaster may not run another commercial until the cooldown period expires.\r\n The retry_after field in the previous start commercial response specifies the amount of time the broadcaster must wait between running commercials.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetExtensionAnalytics = new()
    {
        Method = HttpMethod.Get,
        Route = "/analytics/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's analytics reports.",
            HttpStatusCode.BadRequest => "The start and end dates are optional but if you specify one, you must specify the other.\r\nThe end date must be equal to or later than the start date.\r\nThe cursor specified in the after query parameter is not valid.\r\nThe resource supports only forward pagination (use the after query parameter).\r\nThe first query parameter is outside the allowed range of values.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the analytics:read:extensions scope.\r\nThe OAuth token is not valid.\r\nThe Client-Id header is required.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            HttpStatusCode.NotFound => "The extension specified in the extension_id query parameter was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetGameAnalytics = new()
    {
        Method = HttpMethod.Get,
        Route = "/analytics/games",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's analytics reports.",
            HttpStatusCode.BadRequest => "The start and end dates are optional but if you specify one, you must specify the other.\r\nThe end date must be equal to or later than the start date.\r\nThe cursor specified in the after query parameter is not valid.\r\nThe resource supports only forward pagination (use the after query parameter).\r\nThe first query parameter is outside the allowed range of values.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the analytics:read:games scope.\r\nThe OAuth token is not valid.\r\nThe Client-Id header is required.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            HttpStatusCode.NotFound => "The game specified in the game_id query parameter was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetBitsLeaderboard = new()
    {
        Method = HttpMethod.Get,
        Route = "/bits/leaderboard",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's Bits leaderboard.",
            HttpStatusCode.BadRequest => "The time period specified in the period query parameter is not valid.\r\nThe started_at query parameter is required if period is not set to all.\r\nThe value in the count query parameter is outside the range of allowed values.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a user access token.\r\nThe user access token must include the the bits:read scope.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetCheermotes = new()
    {
        Method = HttpMethod.Get,
        Route = "/bits/cheermotes",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the Cheermotes.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetExtensionTransactions = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/transactions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of transactions.",
            HttpStatusCode.BadRequest => "The extension_id query parameter is required.\r\nThe request specified too many id query parameters.\r\nThe pagination cursor is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token.\r\nThe access token is not valid.\r\nThe ID in the extension_id query parameter must match the client ID in the access token.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.NotFound => "One or more of the transaction IDs specified using the id query parameter were not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelInformation = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of channels.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe broadcaster ID is not valid.\r\nThe number of broadcaster_id query parameters exceeds the maximum allowed.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            HttpStatusCode.TooManyRequests => "The application exceeded the number of calls it may make per minute.\r\n For details, see Rate Limits.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint ModifyChannelInformation = new()
    {
        Method = HttpMethod.Patch,
        Route = "/channels",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully updated the channel's properties.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe request must update at least one property.\r\nThe title field may not contain an empty string.\r\nThe ID in game_id is not valid.\r\nTo update the delay field, the broadcaster must have partner status.\r\nThe list in the tags field exceeds the maximum number of tags allowed.\r\nA tag in the tags field exceeds the maximum length allowed.\r\nA tag in the tags field is empty.\r\nA tag in the tags field contains special characters or spaces.\r\nOne or more tags in the tags field failed AutoMod review.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID found in the OAuth token.\r\nThe Authorization header is required and must specify a user access token.\r\nThe OAuth token must include the channel:manage:broadcast scope.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelEditors = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/editors",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's list of editors.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in the broadcaster_id query parameter must match the user ID found in the OAuth token.\r\nThe Authorization header is required and must specify a user access token.\r\nThe OAuth token must include the channel:read:editors scope.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetFollowedChannels = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/followed",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's list of followers.",
            HttpStatusCode.BadRequest => "Possible reasons:The user_id query parameter is required.\r\nThe broadcaster_id query parameter is not valid.\r\nThe user_id query parameter is required.",
            HttpStatusCode.Unauthorized => "Possible reasons:The ID in the user_id query parameter must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token is missing the user:read:follows scope.\r\nThe OAuth token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelFollowers = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/followers",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's list of followers.",
            HttpStatusCode.BadRequest => "Possible reasons:The broadcaster_id query parameter is required.\r\nThe broadcaster_id query parameter is not valid.\r\nThe user_id query parameter is required.",
            HttpStatusCode.Unauthorized => "Possible reasons:The ID in the broadcaster_id query parameter must match the user ID in the access token or the user must be a moderator for the specified broadcaster.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token is missing the moderator:read:followers scope.\r\nThe OAuth token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreateCustomRewards = new()
    {
        Method = HttpMethod.Post,
        Route = "/channel_points/custom_rewards",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully created the custom reward.",
            HttpStatusCode.BadRequest => "The request exceeds the maximum number of rewards allowed per channel.\r\nThe broadcaster_id query parameter is required.\r\nThe title field is required.\r\nThe title must contain a minimum of 1 character and a maximum of 45 characters.\r\nThe title must be unique amongst all of the broadcaster's custom rewards.\r\nThe cost field is required.\r\nThe cost field must contain a minimum of 1 point.\r\nThe prompt field is limited to a maximum of 200 characters.\r\nIf is_max_per_stream_enabled is true, the minimum value for max_per_stream is 1.\r\nIf is_max_per_user_per_stream_enabled is true, the minimum value for max_per_user_per_stream is 1.\r\nIf is_global_cooldown_enabled is true, the minimum value for global_cooldown_seconds is 1.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a user access token.\r\nThe user access token is missing the channel:manage:redemptions scope.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            HttpStatusCode.Forbidden => "The broadcaster is not a partner or affiliate.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint DeleteCustomReward = new()
    {
        Method = HttpMethod.Delete,
        Route = "/channel_points/custom_rewards",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully deleted the custom reward.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a user access token.\r\nThe user access token must include the channel:manage:redemptions scope.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            HttpStatusCode.Forbidden => "The ID in the Client-Id header must match the client ID used to create the custom reward.\r\nThe broadcaster is not a partner or affiliate.",
            HttpStatusCode.NotFound => "The custom reward specified in the id query parameter was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetCustomReward = new()
    {
        Method = HttpMethod.Get,
        Route = "/channel_points/custom_rewards",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's list of custom rewards.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe request exceeds the maximum number of id query parameters that you may specify.",
            HttpStatusCode.Unauthorized => "The Authorization header must specify a user access token.\r\nThe user access token must include the channel:read:redemptions scope.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            HttpStatusCode.Forbidden => "The broadcaster is not a partner or affiliate.",
            HttpStatusCode.NotFound => "All of the custom rewards specified using the id query parameter were not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetCustomRewardRedemption = new()
    {
        Method = HttpMethod.Get,
        Route = "/channel_points/custom_rewards/redemptions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of redeemed custom rewards.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe reward_id query parameter is required.\r\nThe status query parameter is required if you didn't specify the id query parameter.\r\nThe value in the status query parameter is not valid.\r\nThe value in the sort query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a user access token.\r\nThe user access token must include the channel:read:redemptions scope.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            HttpStatusCode.Forbidden => "The ID in the Client-Id header must match the client ID used to create the custom reward.\r\nThe broadcaster is not a partner or affiliate.",
            HttpStatusCode.NotFound => "All of the redemptions specified using the id query parameter were not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateCustomReward = new()
    {
        Method = HttpMethod.Patch,
        Route = "/channel_points/custom_rewards",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully updated the custom reward.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe id query parameter is required.\r\nThe title must contain a minimum of 1 character and a maximum of 45 characters.\r\nThe title must be unique amongst all of the broadcaster's custom rewards.\r\nThe cost field must contain a minimum of 1 point.\r\nThe prompt field is limited to a maximum of 200 characters.\r\nIf is_max_per_stream_enabled is true, the minimum value for max_per_stream is 1.\r\nIf is_max_per_user_per_stream_enabled is true, the minimum value for max_per_user_per_stream is 1.\r\nIf is_global_cooldown_enabled is true, the minimum value for global_cooldown_seconds is 1 and the maximum is 604800.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a user access token.\r\nThe user access token must include the channel:manage:redemptions scope.\r\nThe OAuth token is not valide.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            HttpStatusCode.Forbidden => "The ID in the Client-Id header must match the client ID used to create the custom reward.\r\nThe broadcaster is not a partner or affiliate.",
            HttpStatusCode.NotFound => "The custom reward specified in the id query parameter was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateRedemptionStatus = new()
    {
        Method = HttpMethod.Patch,
        Route = "/channel_points/custom_rewards/redemptions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully updated the redemption's status.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe reward_id query parameter is required.\r\nThe id query parameter is required.\r\nThe value in the status query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a user access token.\r\nThe user access token must include the channel:manage:redemptions scope.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            HttpStatusCode.Forbidden => "The ID in the Client-Id header must match the client ID used to create the custom reward.\r\nThe broadcaster is not a partner or affiliate.",
            HttpStatusCode.NotFound => "The custom reward specified in the reward_id query parameter was not found.\r\nThe redemptions specified using the id query parameter were not found or their statuses weren't marked as UNFULFILLED.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetCharityCampaign = new()
    {
        Method = HttpMethod.Get,
        Route = "/charity/campaigns",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved information about the broadcaster's active charity campaign.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe broadcaster_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in the broadcaster_id query parameter must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:read:charity scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header must match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The broadcaster is not a partner or affiliate.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetCharityCampaignDonations = new()
    {
        Method = HttpMethod.Get,
        Route = "/charity/donations",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of donations that users contributed to the broadcaster's charity campaign.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe broadcaster_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in the broadcaster_id query parameter must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:read:charity scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header must match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The broadcaster is not a partner or affiliate.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChatters = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/chatters",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's list of chatters.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe moderator_id query parameter is required.\r\nThe ID in the moderator_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in the moderator_id query parameter must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:read:chatters scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in the moderator_id query parameter is not one of the broadcaster's moderators.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelEmotes = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/emotes",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved broadcaster's list of custom emotes.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a valid app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetGlobalEmotes = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/emotes/global",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved Twitch's list of global emotes.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a valid app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetEmoteSets = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/emotes/set",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the emotes for the specified emote sets.",
            HttpStatusCode.BadRequest => "The emote_set_id query parameter is required.\r\nThe number of emote_set_id query parameters exceeds the maximum allowed.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a valid app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelChatBadges = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/badges",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's custom chat badges.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a valid app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetGlobalChatBadges = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/badges/global",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of global chat badges.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a valid app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChatSettings = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/settings",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's chat settings.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a valid app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateChatSettings = new()
    {
        Method = HttpMethod.Patch,
        Route = "/chat/settings",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully updated the broadcaster's chat settings.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe moderator_id query parameter is required.\r\nIf slow_mode is true, the slow_mode_wait_time field must be set to a valid value.\r\nIf follower_mode is true, the follower_mode_duration field must be set to a valid value.\r\nIf non_moderator_chat_delay is true, the non_moderator_chat_delay_duration field must be set to a valid value.",
            HttpStatusCode.Unauthorized => "The ID in the moderator_id query parameter must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:chat_settings scope.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.Forbidden => "The user in the moderator_id query parameter must have moderator privileges in the broadcaster's channel.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SendChatAnnouncement = new()
    {
        Method = HttpMethod.Post,
        Route = "/chat/announcements",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully sent the announcement.",
            HttpStatusCode.BadRequest => "The message field in the request's body is required.\r\nThe message field may not contain an empty string.\r\nThe message field may not contain an empty string.\r\nThe string in the message field failed review.\r\nThe specified color is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token is missing the moderator:manage:announcements scope.\r\nThe OAuth token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SendAShoutout = new()
    {
        Method = HttpMethod.Post,
        Route = "/chat/shoutouts",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully sent the specified broadcaster a Shoutout.",
            HttpStatusCode.BadRequest => "The from_broadcaster_id query parameter is required.\r\nThe ID in the from_broadcaster_id query parameter is not valid.\r\nThe to_broadcaster_id query parameter is required.\r\nThe ID in the to_broadcaster_id query parameter is not valid.\r\nThe broadcaster may not give themselves a Shoutout.\r\nThe broadcaster is not streaming live or does not have one or more viewers.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:shoutouts scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.\r\nThe broadcaster may not send the specified broadcaster a Shoutout.",
            HttpStatusCode.TooManyRequests => "The broadcaster exceeded the number of Shoutouts they may send within a given window.\r\n See the endpoint's Rate Limits.\r\nThe broadcaster exceeded the number of Shoutouts they may send the same broadcaster within a given window.\r\n See the endpoint's Rate Limits.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetUserChatColor = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/color",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the chat color used by the specified users.",
            HttpStatusCode.BadRequest => "The ID in the user_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain an app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateUserChatColor = new()
    {
        Method = HttpMethod.Put,
        Route = "/chat/color",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully updated the user's chat color.",
            HttpStatusCode.BadRequest => "The ID in the user_id query parameter is not valid.\r\nThe color query parameter is required.\r\nThe named color in the color query parameter is not valid.\r\nTo specify a Hex color code, the user must be a Turbo or Prime user.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:manage:chat_color scope.\r\nThe OAuth token is not valid.\r\nThe ID in the user_id query parameter must match the user ID in the access token.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreateClip = new()
    {
        Method = HttpMethod.Post,
        Route = "/clips",
        SuccessStatusCode = HttpStatusCode.Accepted,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.Accepted => "Successfully started the clip process.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter was not found.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify user access token.\r\nThe user access token must include the clips:edit scope.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            HttpStatusCode.Forbidden => "The broadcaster has restricted the ability to capture clips to followers and/or subscribers only.\r\nThe specified broadcaster has not enabled clips on their channel.",
            HttpStatusCode.NotFound => "The broadcaster in the broadcaster_id query parameter must be broadcasting live.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetClips = new()
    {
        Method = HttpMethod.Get,
        Route = "/clips",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of video clips.",
            HttpStatusCode.BadRequest => "The id or game_id or broadcaster_id query parameter is required.\r\nThe id, game_id, and broadcaster_id query parameters are mutually exclusive; you may specify only one of them.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain an app access token or user access token.\r\nThe OAuth token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            HttpStatusCode.NotFound => "The ID in game_id was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetConduits = new()
    {
        Method = HttpMethod.Get,
        Route = "/eventsub/conduits",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved conduits",
            HttpStatusCode.Unauthorized => "Authorization header required with an app access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreateConduits = new()
    {
        Method = HttpMethod.Post,
        Route = "/eventsub/conduits",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Conduit created.",
            HttpStatusCode.BadRequest => "Invalid shard count.",
            HttpStatusCode.Unauthorized => "Authorization header required with an app access token.",
            HttpStatusCode.TooManyRequests => "Conduit limit reached.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateConduits = new()
    {
        Method = HttpMethod.Patch,
        Route = "/eventsub/conduits",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Conduit updated.",
            HttpStatusCode.BadRequest => "Invalid shard count.\r\nThe id query parameter is required.",
            HttpStatusCode.Unauthorized => "Authorization header required with an app access token.",
            HttpStatusCode.NotFound => "Conduit not found.\r\nConduit’s owner must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint DeleteConduits = new()
    {
        Method = HttpMethod.Delete,
        Route = "/eventsub/conduits",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully deleted the conduit.",
            HttpStatusCode.BadRequest => "The id query parameter is required.",
            HttpStatusCode.Unauthorized => "Authorization header required with an app access token.",
            HttpStatusCode.NotFound => "Conduit not found.\r\nConduit’s owner must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetConduitShards = new()
    {
        Method = HttpMethod.Get,
        Route = "/eventsub/conduits/shards",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved shards.",
            HttpStatusCode.BadRequest => "The id query parameter is required.",
            HttpStatusCode.Unauthorized => "Authorization header required with an app access token.",
            HttpStatusCode.NotFound => "Conduit not found.\r\nConduit’s owner must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateConduitShards = new()
    {
        Method = HttpMethod.Patch,
        Route = "/eventsub/conduits/shards",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.Accepted => "Successfully retrieved shards.",
            HttpStatusCode.BadRequest => "The id query parameter is required.",
            HttpStatusCode.Unauthorized => "Authorization header required with an app access token.",
            HttpStatusCode.NotFound => "Conduit not found.\r\nConduit’s owner must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetContentClassificationLabels = new()
    {
        Method = HttpMethod.Get,
        Route = "/content_classification_labels",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code.ToString()
    };

    public static readonly HelixEndpoint GetDropsEntitlements = new()
    {
        Method = HttpMethod.Get,
        Route = "/entitlements/drops",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the entitlements.",
            HttpStatusCode.BadRequest => "The value in the fulfillment_status query parameter is not valid.\r\nThe ID in the user_id query parameter must match the user ID in the user access token.\r\nThe client in the access token is not associated with a known organization.\r\nThe owner of the client in the access token is not a member of the organization.",
            HttpStatusCode.Unauthorized => "The ID in the Client-Id header must match the Client ID in the access token.\r\nThe Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.",
            HttpStatusCode.Forbidden => "The organization associated with the client in the access token must own the game specified in the game_id query parameter.\r\nThe organization associated with the client in the access token must own the entitlements specified in the id query parameter.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateDropsEntitlements = new()
    {
        Method = HttpMethod.Patch,
        Route = "/entitlements/drops",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully requested the updates.\r\n Check the response to determine which updates succeeded.",
            HttpStatusCode.BadRequest => "The value in the fulfillment_status field is not valid.\r\nThe client in the access token is not associated with a known organization.\r\nThe owner of the client in the access token is not a member of the organization.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetExtensionConfigurationSegment = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/configurations",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the configurations.",
            HttpStatusCode.BadRequest => "The extension_id query parameter is required.\r\nThe value in the segment query parameter is not valid.\r\nThe broadcaster_id query parameter is required if the segment query parameter is set to broadcaster or developer.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a JWT token.\r\nThe JWT token is not valid.\r\nThe Client-Id header is required.",
            HttpStatusCode.TooManyRequests => "The app exceeded the number of requests that it may make per minute.\r\n See Rate Limits above.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SetExtensionConfigurationSegment = new()
    {
        Method = HttpMethod.Put,
        Route = "/extensions/configurations",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully updated the configuration.",
            HttpStatusCode.BadRequest => "The broadcaster_id field is required if segment is set to developer or broadcaster.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a JWT token.\r\nThe JWT token is not valid.\r\nThe Client-Id header is required.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SetExtensionRequiredConfiguration = new()
    {
        Method = HttpMethod.Put,
        Route = "/extensions/required_configuration",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully updated the extension's required_configuration string.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe extension_id field is required.\r\nThe extension_version field is required.\r\nThe required_configuration field is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a JWT token.\r\nThe JWT token is not valid.\r\nThe Client-Id header is required.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SendExtensionPubSubMessage = new()
    {
        Method = HttpMethod.Post,
        Route = "/extensions/pubsub",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully sent the message.",
            HttpStatusCode.BadRequest => "The broadcaster_id field in the request's body may only be set if the is_global_broadcast field is set to false.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a JWT token.\r\nThe JWT token is not valid.\r\nThe Client-Id header is required.",
            HttpStatusCode.UnprocessableEntity => "The message is too large.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetExtensionLiveChannels = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/live",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of broadcasters.",
            HttpStatusCode.BadRequest => "The extension_id query parameter is required.\r\nThe pagination cursor is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.NotFound => "The extension specified in the extension_id query parameter was not found or it's not being used in a live stream.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetExtensionSecrets = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/jwt/secrets",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of secrets.",
            HttpStatusCode.BadRequest => "The extension_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a JWT token.\r\nThe JWT token is not valid.\r\nThe Client-Id header is required.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreateExtensionSecret = new()
    {
        Method = HttpMethod.Post,
        Route = "/extensions/jwt/secrets",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully created the new secret.",
            HttpStatusCode.BadRequest => "The extension_id query parameter is required.\r\nThe delay specified in the delay query parameter is too short.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a JWT token.\r\nThe JWT token is not valid.\r\nThe Client-Id header is required.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SendExtensionChatMessage = new()
    {
        Method = HttpMethod.Post,
        Route = "/extensions/chat",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully sent the chat message.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe extension_id field in the request's body is required.\r\nThe extension_version field in the request's body is required.\r\nThe text field in the request's body is required.\r\nThe message is too long.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a JWT token.\r\nThe ID in the broadcaster_id query parameter must match the channel_id claim in the JWT.\r\nThe JWT token is not valid.\r\nThe Client-Id header is required.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetExtensions = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of extensions.",
            HttpStatusCode.BadRequest => "The extension_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The request must specify the Authorization header.\r\nThe Authorization header is required and must specify a JWT token.\r\nThe JWT token is not valid.\r\nThe request must specify the Client-Id header.",
            HttpStatusCode.NotFound => "The extension in the extension_id query parameter was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetReleasedExtensions = new()
    {
        Method = HttpMethod.Get,
        Route = "/extensions/released",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the extension.",
            HttpStatusCode.BadRequest => "The extension_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.NotFound => "The extension specified in the extension_id query parameter was not found or is not released.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetExtensionBitsProducts = new()
    {
        Method = HttpMethod.Get,
        Route = "/bits/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of products.",
            HttpStatusCode.BadRequest => "The ID in the Client-Id header must belong to an extension.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token; you may not specify a user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateExtensionBitsProduct = new()
    {
        Method = HttpMethod.Put,
        Route = "/bits/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully created the product.",
            HttpStatusCode.BadRequest => "The sku field is required.\r\nThe value in the sku field is not valid.\r\n The SKU may contain only alphanumeric characters, dashes (-), underscores (_), and periods (.\r\n).\r\nThe cost object's amount field is required.\r\nThe value in the cost object's amount field is not valid.\r\nThe cost object's type field is required.\r\nThe value in the cost object's type field is not valid.\r\nThe display_name field is required.\r\nThe ID in the Client-Id header must belong to the extension.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token; you may not specify a user access token.\r\nThe OAuth token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreateEventSubSubscription = new()
    {
        Method = HttpMethod.Post,
        Route = "/eventsub/subscriptions",
        SuccessStatusCode = HttpStatusCode.Accepted,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.Accepted => "Successfully accepted the subscription request.",
            HttpStatusCode.BadRequest => "The condition field is required.\r\nThe user specified in the condition object does not exist.\r\nThe condition object is missing one or more required fields.\r\nThe combination of values in the version and type fields is not valid.\r\nThe length of the string in the secret field is not valid.\r\nThe URL in the transport's callback field is not valid.\r\n The URL must use the HTTPS protocol and the 443 port number.\r\nThe value specified in the method field is not valid.\r\nThe callback field is required if you specify the webhook transport method.\r\nThe session_id field is required if you specify the WebSocket transport method.\r\nThe combination of subscription type and version is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token if the transport method is webhook.\r\nThe Authorization header is required and must specify a user access token if the transport method is WebSocket.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.Forbidden => "The access token is missing the required scopes.",
            HttpStatusCode.Conflict => "A subscription already exists for the specified event type and condition combination.",
            HttpStatusCode.TooManyRequests => "The request exceeds the number of subscriptions that you may create with the same combination of type and condition values.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint DeleteEventSubSubscription = new()
    {
        Method = HttpMethod.Delete,
        Route = "/eventsub/subscriptions",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully deleted the subscription.",
            HttpStatusCode.BadRequest => "The id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.NotFound => "The subscription was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetEventSubSubscriptions = new()
    {
        Method = HttpMethod.Get,
        Route = "/eventsub/subscriptions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the subscriptions.",
            HttpStatusCode.BadRequest => "The request may specify only one filter query parameter.\r\n For example, either type or status or user_id.\r\nThe value in the type query parameter is not valid.\r\nThe value in the status query parameter is not valid.\r\nThe cursor specified in the after query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetTopGames = new()
    {
        Method = HttpMethod.Get,
        Route = "/games/top",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of broadcasts.",
            HttpStatusCode.BadRequest => "The value in the first query parameter is not valid.\r\nThe cursor in the after or before query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetGames = new()
    {
        Method = HttpMethod.Get,
        Route = "/games",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the specified games.",
            HttpStatusCode.BadRequest => "The request must specify the id or name or igdb_id query parameter.\r\nThe combined number of game IDs (id and igdb_id) and game names that you specify in the request must not exceed 100.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetCreatorGoals = new()
    {
        Method = HttpMethod.Get,
        Route = "/goals",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's goals.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:read:goals scope.\r\nThe ID in broadcaster_id must match the user ID in the user access token.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelGuestStarSettings = new()
    {
        Method = HttpMethod.Get,
        Route = "/guest_star/channel_settings",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing moderator_id",
            HttpStatusCode.Forbidden => "Insufficient authorization for viewing channel's Guest Star settings",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateChannelGuestStarSettings = new()
    {
        Method = HttpMethod.Put,
        Route = "/guest_star/channel_settings",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully updated channel settings",
            HttpStatusCode.BadRequest => "Missing broadcaster_id Invalid slot_count  Invalid group_layout",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetGuestStarSession = new()
    {
        Method = HttpMethod.Get,
        Route = "/guest_star/session",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing moderator_id",
            HttpStatusCode.Unauthorized => "moderator_id and user token do not match",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreateGuestStarSession = new()
    {
        Method = HttpMethod.Post,
        Route = "/guest_star/session",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.BadRequest => "Missing broadcaster_id Session limit reached (1 active call)",
            HttpStatusCode.Unauthorized => "Phone verification missing",
            HttpStatusCode.Forbidden => "Insufficient authorization for creating session",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint EndGuestStarSession = new()
    {
        Method = HttpMethod.Delete,
        Route = "/guest_star/session",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.BadRequest => "Missing or invalid broadcaster_id Missing or invalid session_id Session has already been ended",
            HttpStatusCode.Forbidden => "Insufficient authorization for ending session",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetGuestStarInvites = new()
    {
        Method = HttpMethod.Get,
        Route = "/guest_star/invites",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing session_id",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SendGuestStarInvite = new()
    {
        Method = HttpMethod.Post,
        Route = "/guest_star/invites",
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing moderator_id Missing session_id Missing guest_id Invalid session_id",
            HttpStatusCode.Forbidden => "Unauthorized guest invited Guest already invited",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint DeleteGuestStarInvite = new()
    {
        Method = HttpMethod.Delete,
        Route = "/guest_star/invites",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing session_id Missing guest_id Invalid session_id",
            HttpStatusCode.NotFound => "No invite exists for specified guest_id",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint AssignGuestStarSlot = new()
    {
        Method = HttpMethod.Post,
        Route = "/guest_star/slot",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfuly assigned guest to slot",
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing moderator_id Missing guest_id Missing or invalid session_id Missing or invalid slot_id",
            HttpStatusCode.Unauthorized => "moderator_id is not a guest star moderator",
            HttpStatusCode.Forbidden => "Cannot assign host slot Guest not invited to session Guest already assigned to slot Guest is not ready to join",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateGuestStarSlot = new()
    {
        Method = HttpMethod.Patch,
        Route = "/guest_star/slot",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfuly updated slot(s)",
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing or invalid session_id Missing or invalid slot_id",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint DeleteGuestStarSlot = new()
    {
        Method = HttpMethod.Delete,
        Route = "/guest_star/slot",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfuly removed user from slot",
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing moderator_id Missing or invalid session_id Missing or invalid slot_id",
            HttpStatusCode.Forbidden => "moderator_id is not a Guest Star moderator The request is attempting to modify a restricted slot",
            HttpStatusCode.NotFound => "guest_id or slot_id not found",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateGuestStarSlotSettings = new()
    {
        Method = HttpMethod.Patch,
        Route = "/guest_star/slot_settings",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfuly updated slot settings",
            HttpStatusCode.BadRequest => "Missing broadcaster_id Missing moderator_id Missing or invalid session_id Missing or invalid slot_id",
            HttpStatusCode.Forbidden => "moderator_id is not a Guest Star moderator The request is attempting to modify a restricted slot",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetHypeTrainEvents = new()
    {
        Method = HttpMethod.Get,
        Route = "/hypetrain/events",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's Hype Train events.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user_id in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:read:hype_train scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CheckAutoModStatus = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/enforcements/status",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully checked the messages.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe data field is required and the list must contain one or more messages to check.\r\nThe msg_id field is required.\r\nThe msg_text field is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderation:read scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The ID in broadcaster_id must match the user ID in the user access token.",
            HttpStatusCode.TooManyRequests => "The broadcaster exceeded the number of chat message checks that they may make.\r\n See the endpoint's rate limits.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint ManageHeldAutoModMessages = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/automod/message",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully approved or denied the message.",
            HttpStatusCode.BadRequest => "The value in the action field is not valid.\r\nThe user_id field is required.\r\nThe msg_id field is required.\r\nThe action field is required.",
            HttpStatusCode.Unauthorized => "The ID in user_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:automod scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in user_id is not one of the broadcaster's moderators.",
            HttpStatusCode.NotFound => "The message specified in the msg_id field was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetAutoModSettings = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/automod/settings",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's AutoMod settings.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe moderator_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:read:automod_settings scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateAutoModSettings = new()
    {
        Method = HttpMethod.Put,
        Route = "/moderation/automod/settings",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully updated the broadcaster's AutoMod settings.",
            HttpStatusCode.BadRequest => "The broadcaster_id is required.\r\nThe moderator_id is required.\r\nThe overall_level setting or one or more individual settings like aggression is required; the overall and individual settings are mutually exclusive, so don't set both.\r\nThe value of one or more AutoMod settings is not valid.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:automod_settings scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetBannedUsers = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/banned",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of banned users.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderation:read scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint BanUser = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/bans",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully banned the user or placed them in a timeout.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe moderator_id query parameter is required.\r\nThe user_id field is required.\r\nThe text in the reason field is too long.\r\nThe value in the duration field is not valid.\r\nThe user specified in the user_id field may not be banned.\r\nThe user specified in the user_id field may not be put in a timeout.\r\nThe user specified in the user_id field is already banned.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:banned_users scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            HttpStatusCode.Conflict => "You may not update the user's ban state while someone else is updating the state.\r\n For example, someone else is currently banning the user or putting them in a timeout, moving the user from a timeout to a ban, or removing the user from a ban or timeout.\r\n Please retry your request.",
            HttpStatusCode.TooManyRequests => "The app has exceeded the number of requests it may make per minute for this broadcaster.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UnbanUser = new()
    {
        Method = HttpMethod.Delete,
        Route = "/moderation/bans",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully removed the ban or timeout.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe moderator_id query parameter is required.\r\nThe user_id query parameter is required.\r\nThe user specified in the user_id query parameter is not banned.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:banned_users scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            HttpStatusCode.Conflict => "You may not update the user's ban state while someone else is updating the state.\r\n For example, someone else is currently removing the ban or timeout, or they're moving the user from a timeout to a ban.\r\n Please retry your request.",
            HttpStatusCode.TooManyRequests => "The app has exceeded the number of requests it may make per minute for this broadcaster.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetBlockedTerms = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/blocked_terms",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of blocked terms.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe moderator_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the user access token.\r\nThe Authorization header must contain a user access token.\r\nThe user access token must include the moderator:read:blocked_terms scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint AddBlockedTerm = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/blocked_terms",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of blocked terms.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe moderator_id query parameter is required.\r\nThe text field is required.\r\nThe length of the term in the text field is either too short or too long.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:blocked_terms scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint RemoveBlockedTerm = new()
    {
        Method = HttpMethod.Delete,
        Route = "/moderation/blocked_terms",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully removed the blocked term.\r\n Also returned if the ID is not found.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe moderator_id query parameter is required.\r\nThe id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:blocked_terms scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint DeleteChatMessages = new()
    {
        Method = HttpMethod.Delete,
        Route = "/moderation/chat",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully removed the specified messages.",
            HttpStatusCode.BadRequest => "You may not delete another moderator's messages.\r\nYou may not delete the broadcaster's messages.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token is missing the moderator:manage:chat_messages scope.\r\nThe OAuth token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            HttpStatusCode.NotFound => "The ID in message_id was not found.\r\nThe specified message was created more than 6 hours ago.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetModerators = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/moderators",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of moderators.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID found in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderation:read scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint AddChannelModerator = new()
    {
        Method = HttpMethod.Post,
        Route = "/moderation/moderators",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully added the moderator.",
            HttpStatusCode.BadRequest => "The ID in broadcaster_id was not found.\r\nThe ID in user_id was not found.\r\nThe user in user_id is already a moderator in the broadcaster's chat room.\r\nThe user in user_id cannot become a moderator because they're banned from the channel.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:moderators scope.\r\nThe access token is not valid.\r\nThe ID in the broadcaster_id query parameter must match the user ID in the access token.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.UnprocessableEntity => "The user in user_id is a VIP.\r\n To make them a moderator, you must first remove them as a VIP (see Remove Channel VIP).",
            HttpStatusCode.TooManyRequests => "The broadcaster has exceeded the number of requests allowed within a 10-second window.\r\n See this endpoint's rate limits.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint RemoveChannelModerator = new()
    {
        Method = HttpMethod.Delete,
        Route = "/moderation/moderators",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully removed the moderator.",
            HttpStatusCode.BadRequest => "The ID in broadcaster_id was not found.\r\nThe ID in user_id was not found.\r\nThe user in user_id is not a moderator in the broadcaster's chat room.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:moderators scope.\r\nThe access token is not valid.\r\nThe ID in the broadcaster_id query parameter must match the user ID in the access token.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.TooManyRequests => "The broadcaster has exceeded the number of requests allowed within a 10-second window.\r\n See this endpoint's rate limits.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetVIPs = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/vips",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's list of VIPs.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the user_id query parameter is not valid.\r\nThe number of user_id query parameters exceeds the maximum allowed.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:read:vips  or channel:manage:vips scope.\r\nThe OAuth token is not valid.\r\nThe ID in the broadcaster_id query parameter must match the user ID in the access token.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint AddChannelVIP = new()
    {
        Method = HttpMethod.Post,
        Route = "/channels/vips",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => (int)code switch
        {
            (int)HttpStatusCode.NoContent => "Successfully added the VIP.",
            (int)HttpStatusCode.BadRequest => "The user in the user_id query parameter is blocked from the broadcaster's channel.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe ID in the user_id query parameter is not valid.",
            (int)HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:vips scope.\r\nThe OAuth token is not valid.\r\nThe ID in the broadcaster_id query parameter must match the user ID in the access token.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            (int)HttpStatusCode.Forbidden => "The ID in the broadcaster_id query parameter must match the user ID in the access token.",
            (int)HttpStatusCode.NotFound => "The ID in broadcaster_id was not found.\r\nThe ID in user_id was not found.",
            (int)HttpStatusCode.Conflict => "The broadcaster doesn't have available VIP slots.\r\n Read More",
            (int)HttpStatusCode.UnprocessableEntity => "The user in user_id is a moderator.\r\n To make them a VIP, you must first remove them as a moderator (see Remove Channel Moderator).\r\nThe user in the user_id query parameter is already a VIP.",
            425 => "The broadcaster must complete the Build a Community requirement before they may assign VIPs.",
            (int)HttpStatusCode.TooManyRequests => "The broadcaster exceeded the number of VIP that they may add within a 10-second window.\r\n See Rate Limits for this endpoint above.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint RemoveChannelVIP = new()
    {
        Method = HttpMethod.Delete,
        Route = "/channels/vips",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully removed the VIP status from the user.",
            HttpStatusCode.BadRequest => "The ID in broadcaster_id is not valid.\r\nThe ID in user_id is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:vips scope.\r\nThe OAuth token is not valid.\r\nThe ID in the broadcaster_id query parameter must match the user ID in the access token.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the OAuth token.",
            HttpStatusCode.Forbidden => "The user in broadcaster_id doesn't have permission to remove the user's VIP status.",
            HttpStatusCode.NotFound => "The ID in broadcaster_id was not found.\r\nThe ID in user_id was not found.",
            HttpStatusCode.UnprocessableEntity => "The user in user_id is not a VIP in the broadcaster's channel.",
            HttpStatusCode.TooManyRequests => "The broadcaster exceeded the number of VIPs that they may remove within a 10-second window.\r\n See Rate Limits for this endpoint above.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateShieldModeStatus = new()
    {
        Method = HttpMethod.Put,
        Route = "/moderation/shield_mode",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully updated the broadcaster's Shield Mode status.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe is_active field is required.\r\nThe value in the is_active field is not valid.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:manage:shield_mode scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetShieldModeStatus = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/shield_mode",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's Shield Mode activation status.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in moderator_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the moderator:read:shield_mode or moderator:manage:shield_mode scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in moderator_id is not one of the broadcaster's moderators.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetPolls = new()
    {
        Method = HttpMethod.Get,
        Route = "/polls",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's polls.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token is missing the channel:read:polls scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header must match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "None of the IDs in the id query parameters were found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreatePoll = new()
    {
        Method = HttpMethod.Post,
        Route = "/polls",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully created the poll.",
            HttpStatusCode.BadRequest => "The broadcaster_id field is required.\r\nThe title field is required.\r\nThe choices field is required.\r\nThe duration field is required.\r\nThe value in duration is outside the allowed range of values.\r\nThe value in channel_points_per_vote is outside the allowed range of values.\r\nThe value in bits_per_vote is outside the allowed range of values.\r\nThe poll's title is too long.\r\nThe choice's title is too long.\r\nThe choice's title failed AutoMod checks.\r\nThe number of choices in the poll may not be less than 2 or greater that 5.\r\nThe broadcaster already has a poll that's running; you may not create another poll until the current poll completes.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token is missing the channel:manage:polls scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint EndPoll = new()
    {
        Method = HttpMethod.Patch,
        Route = "/polls",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully ended the poll.",
            HttpStatusCode.BadRequest => "The broadcaster_id field is required.\r\nThe id field is required.\r\nThe status field is required.\r\nThe value in the status field is not valid.\r\nThe poll must be active to terminate or archive it.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:polls scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header must match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetPredictions = new()
    {
        Method = HttpMethod.Get,
        Route = "/predictions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of predictions.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:read:predictions scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreatePrediction = new()
    {
        Method = HttpMethod.Post,
        Route = "/predictions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully created the Channel Points Prediction.",
            HttpStatusCode.BadRequest => "The broadcaster_id field is required.\r\nThe title field is required.\r\nThe outcomes field is required.\r\nThe prediction_window field is required.\r\nThe value in prediction_window is outside the allowed range of values.\r\nThe prediction's title is too long.\r\nThe outcome's title is too long.\r\nThe outcome's title failed AutoMod checks.\r\nThere must be 2 outcomes in the prediction.\r\nThe broadcaster already has a prediction that's running; you may not create another prediction until the current prediction is resolved or canceled.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:predictions scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint EndPrediction = new()
    {
        Method = HttpMethod.Patch,
        Route = "/predictions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully ended the prediction.",
            HttpStatusCode.BadRequest => "The broadcaster_id field is required.\r\nThe id field is required.\r\nThe status field is required.\r\nThe winning_outcome_id field is required if status is RESOLVED.\r\nThe value in the status field is not valid.\r\nTo update the prediction's status to RESOLVED or CANCELED, its current status must be ACTIVE or LOCKED.\r\nTo update the prediction's status to LOCKED, its current status must be ACTIVE.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID in the OAuth token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:predictions scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "The prediction in the id field was not found.\r\nThe outcome in the winning_outcome_id field was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint StartARaid = new()
    {
        Method = HttpMethod.Post,
        Route = "/raids",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully requested to start a raid.\r\n To determine whether the raid successfully occurred (that is, the broadcaster clicked Raid Now or the countdown expired), you must subscribe to the Channel Raid event.",
            HttpStatusCode.BadRequest => "The raiding broadcaster is blocked from the targeted channel.\r\nThe targeted channel doesn't accept raids from this broadcaster.\r\nThere are too many viewers in the raiding party.\r\nThe IDs in from_broadcaster_id and to_broadcaster_id cannot be the same ID.\r\nThe ID in the from_broadcaster_id query parameter is not valid.\r\nThe ID in the to_broadcaster_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in from_broadcaster_id must match the user ID found in the request's OAuth token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:raids scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "The targeted channel was not found.",
            HttpStatusCode.Conflict => "The broadcaster is already in the process of raiding another channel.",
            HttpStatusCode.TooManyRequests => "The broadcaster exceeded the number of raid requests that they may make.\r\n The limit is 10 requests within a 10-minute window.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CancelARaid = new()
    {
        Method = HttpMethod.Delete,
        Route = "/raids",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "The pending raid was successfully canceled.",
            HttpStatusCode.BadRequest => "The ID in the broadcaster_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID found in the request's OAuth token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:raids scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "The broadcaster doesn't have a pending raid to cancel.",
            HttpStatusCode.TooManyRequests => "The broadcaster exceeded the number of raid requests that they may make.\r\n The limit is 10 requests within a 10-minute window.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelStreamSchedule = new()
    {
        Method = HttpMethod.Get,
        Route = "/schedule",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's streaming schedule.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe ID in the id query parameter is not valid.\r\nThe format of the date and time in the start_time query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify a valid app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the access token.",
            HttpStatusCode.Forbidden => "Only partners and affiliates may add non-recurring broadcast segments.",
            HttpStatusCode.NotFound => "The broadcaster has not created a streaming schedule.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelICalendar = new()
    {
        Method = HttpMethod.Get,
        Route = "/schedule/icalendar",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's schedule as an iCalendar.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateChannelStreamSchedule = new()
    {
        Method = HttpMethod.Patch,
        Route = "/schedule/settings",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully updated the broadcaster's schedule settings.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe format of the string in vacation_start_time is not valid.\r\nThe format of the string in vacation_end_time is not valid.\r\nThe date in vacation_end_time must be later than the date in vacation_start_time.",
            HttpStatusCode.Unauthorized => "The ID in the broadcaster_id query parameter must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:schedule scope.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.NotFound => "The broadcaster's schedule was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreateChannelStreamScheduleSegment = new()
    {
        Method = HttpMethod.Post,
        Route = "/schedule/segment",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully added the broadcast segment.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe format of the date and time in the start_time field is not valid.\r\nThe value in the timezone field is not valid.\r\nThe value in the duration field is not valid.\r\nThe ID in the category_id field is not valid.\r\nThe string in the title field is too long.",
            HttpStatusCode.Unauthorized => "The ID in the broadcaster_id query parameter must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:schedule scope.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.Forbidden => "Only partners and affiliates may add non-recurring broadcast segments.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateChannelStreamScheduleSegment = new()
    {
        Method = HttpMethod.Patch,
        Route = "/schedule/segment",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully updated the broadcast segment.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe id query parameter is required.\r\nThe ID in the id query parameter is not valid.\r\nThe format of the date and time in the start_time field is not valid.\r\nThe value in the timezone field is not valid.\r\nThe value in the duration field is not valid.\r\nThe ID in the category_id field is not valid.\r\nThe string in the title field is too long.",
            HttpStatusCode.Unauthorized => "The ID in the broadcaster_id query parameter must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:schedule scope.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.NotFound => "The specified broadcast segment was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint DeleteChannelStreamScheduleSegment = new()
    {
        Method = HttpMethod.Delete,
        Route = "/schedule/segment",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully removed the broadcast segment.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe id query parameter is required.\r\nThe ID in the id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in the broadcaster_id query parameter must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:schedule scope.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the OAuth token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SearchCategories = new()
    {
        Method = HttpMethod.Get,
        Route = "/search/categories",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of category names that matched the specified query string.",
            HttpStatusCode.BadRequest => "The query query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain an app access token or user access token.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SearchChannels = new()
    {
        Method = HttpMethod.Get,
        Route = "/search/channels",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of category names that matched the specified query string.",
            HttpStatusCode.BadRequest => "The query query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain an app access token or user access token.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetSoundtrackCurrentTrack = new()
    {
        Method = HttpMethod.Get,
        Route = "/soundtrack/current_track",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the track that the broadcaster is playing.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.NotFound => "The broadcaster is not playing a track.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetSoundtrackPlaylist = new()
    {
        Method = HttpMethod.Get,
        Route = "/soundtrack/playlist",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the playlist.",
            HttpStatusCode.BadRequest => "The id query parameter is required.\r\nThe ID in the id query parameter is not a valid playlist ASIN.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            HttpStatusCode.NotFound => "The specified playlist was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetSoundtrackPlaylists = new()
    {
        Method = HttpMethod.Get,
        Route = "/soundtrack/playlists",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of playlists.",
            HttpStatusCode.BadRequest => "The ID in the id query parameter is not a valid playlist ASIN.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetStreamKey = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams/key",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the stream's key.",
            HttpStatusCode.BadRequest => "The broadcaster_id field is required.\r\nThe ID in the broadcaster_id field is not valid.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:read:stream_key scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header must match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetStreams = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of streams.",
            HttpStatusCode.BadRequest => "The value in the type query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetFollowedStreams = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams/followed",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of broadcasters that the user follows and that are streaming live.",
            HttpStatusCode.BadRequest => "The user_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in user_id must match the user ID found in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:read:follows scope.\r\nThe OAuth token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CreateStreamMarker = new()
    {
        Method = HttpMethod.Post,
        Route = "/streams/markers",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully created the marker.",
            HttpStatusCode.BadRequest => "The user_id field is required.\r\nThe length of the string in the description field is too long.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:manage:broadcast scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in the access token is not authorized to create video markers for the user in the user_id field.\r\n The user in the access token must own the video or they must be one of the broadcaster's editors.",
            HttpStatusCode.NotFound => "The user in the user_id field is not streaming live.\r\nThe ID in the user_id field is not valid.\r\nThe user hasn't enabled video on demand (VOD).",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetStreamMarkers = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams/markers",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of markers.",
            HttpStatusCode.BadRequest => "The request must specify either the user_id or video_id query parameter, but not both.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:read:broadcast or user:manage:broadcast scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The user in the access token is not authorized to get the video's markers.\r\n The user in the access token must own the video or be one of the broadcaster's editors.",
            HttpStatusCode.NotFound => "The user specified in the user_id query parameter doesn't have videos.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetBroadcasterSubscriptions = new()
    {
        Method = HttpMethod.Get,
        Route = "/subscriptions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's list of subscribers.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID found in the request's OAuth token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:read:subscriptions scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint CheckUserSubscription = new()
    {
        Method = HttpMethod.Get,
        Route = "/subscriptions/user",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "The user subscribes to the broadcaster.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe user_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in user_id must match the user ID found in the request's OAuth token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:read:subscriptions scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "The user in user_id does not subscribe to the broadcaster in broadcaster_id.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetAllStreamTags = new()
    {
        Method = HttpMethod.Get,
        Route = "/tags/streams",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of tags.",
            HttpStatusCode.BadRequest => "The tag_id query parameter is empty (for example, &tag_id=).\r\nThe list of tag IDs is too long.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetStreamTags = new()
    {
        Method = HttpMethod.Get,
        Route = "/streams/tags",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of tags.",
            HttpStatusCode.BadRequest => "The broadcaster_id field is required.\r\nThe ID in the broadcaster_id field is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must specify an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID in the Client-Id header must match the Client ID in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetChannelTeams = new()
    {
        Method = HttpMethod.Get,
        Route = "/teams/channel",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of teams.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header must contain an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "The broadcaster was not found.\r\nThe broadcaster is not a member of a team.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetTeams = new()
    {
        Method = HttpMethod.Get,
        Route = "/teams",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the team's information.",
            HttpStatusCode.BadRequest => "The name or id query parameter is required.\r\nSpecify either the name or id query parameter but not both.\r\nThe ID in the id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header must contain an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "The specified team was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetUsers = new()
    {
        Method = HttpMethod.Get,
        Route = "/users",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the specified users' information.",
            HttpStatusCode.BadRequest => "The id or login query parameter is required unless the request uses a user access token.\r\nThe request exceeded the maximum allowed number of id and/or login query parameters.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateUser = new()
    {
        Method = HttpMethod.Put,
        Route = "/users",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully updated the specified user's information.",
            HttpStatusCode.BadRequest => "The string in the description query parameter is too long.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:edit scope.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetUsersFollows = new()
    {
        Method = HttpMethod.Get,
        Route = "/users/follows",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the follows information.",
            HttpStatusCode.BadRequest => "The from_id query parameter, to_id query parameter, or both parameters are required.\r\nThe ID in the from_id query parameter is not validThe ID in the to_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetUserBlockList = new()
    {
        Method = HttpMethod.Get,
        Route = "/users/blocks",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the broadcaster's list of blocked users.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The ID in broadcaster_id must match the user ID found in the request's access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:read:blocked_users scope.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint BlockUser = new()
    {
        Method = HttpMethod.Put,
        Route = "/users/blocks",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully blocked the user.",
            HttpStatusCode.BadRequest => "The target_user_id query parameter is required.\r\nThe ID in target_user_id cannot be the same as the user ID in the access token.\r\nThe value in source_context is not valid.\r\nThe value in reason is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:manage:blocked_users scope.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UnblockUser = new()
    {
        Method = HttpMethod.Delete,
        Route = "/users/blocks",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully removed the block.",
            HttpStatusCode.BadRequest => "The target_user_id query parameter is required.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:read:blocked_users scope.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetUserExtensions = new()
    {
        Method = HttpMethod.Get,
        Route = "/users/extensions/list",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the user's installed extensions.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:read:broadcast scope.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetUserActiveExtensions = new()
    {
        Method = HttpMethod.Get,
        Route = "/users/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the user's active extensions.",
            HttpStatusCode.BadRequest => "The user_id query parameter is required if you specify an app access token.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint UpdateUserExtensions = new()
    {
        Method = HttpMethod.Put,
        Route = "/users/extensions",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully updated the active extensions.",
            HttpStatusCode.BadRequest => "The JSON payload is malformed.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:edit:broadcast scope.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "An extension with the specified id and version values was not found.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetVideos = new()
    {
        Method = HttpMethod.Get,
        Route = "/videos",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the list of videos.",
            HttpStatusCode.BadRequest => "The request must specify either the id or user_id or game_id query parameter.\r\nThe id, user_id, and game_id query parameters are mutually exclusive; you must specify only one of them.\r\nThe value in the id query parameter is not valid.\r\nThe ID in the game_id query parameter is not valid.\r\nThe value in the type query parameter is not valid.\r\nThe value in the period query parameter is not valid.\r\nThe value in the sort query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The Authorization header is required and must contain an app access token or user access token.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.NotFound => "The ID in the game_id query parameter was not found.\r\nThe ID in the id query parameter was not found.\r\n Returned only if all the IDs were not found; otherwise, the ID is ignored.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint DeleteVideos = new()
    {
        Method = HttpMethod.Delete,
        Route = "/videos",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully deleted the list of videos.",
            HttpStatusCode.BadRequest => "The id query parameter is required.\r\nThe request exceeded the number of allowed id query parameters.",
            HttpStatusCode.Unauthorized => "The caller is not authorized to delete the specified video.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the channel:manage:videos scope.\r\nThe access token is not valid.\r\nThe ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SendWhisper = new()
    {
        Method = HttpMethod.Post,
        Route = "/whispers",
        SuccessStatusCode = HttpStatusCode.NoContent,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.NoContent => "Successfully sent the whisper message or the message was silently dropped.",
            HttpStatusCode.BadRequest => "The ID in the from_user_id and to_user_id query parameters must be different.\r\nThe message field must not contain an empty string.\r\nThe user that you're sending the whisper to doesn't allow whisper messages (see the Block Whispers from Strangers setting in your Security and Privacy settings).\r\nWhisper messages may not be sent to suspended users.\r\nThe ID in the from_user_id query parameter is not valid.\r\nThe ID in the to_user_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The user in the from_user_id query parameter must have a verified phone number.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:manage:whispers scope.\r\nThe access token is not valid.\r\nThis ID in from_user_id must match the user ID in the user access token.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "Suspended users may not send whisper messages.\r\nThe account that's sending the message doesn't allow sending whispers.",
            HttpStatusCode.NotFound => "The ID in to_user_id was not found.",
            HttpStatusCode.TooManyRequests => "The sending user exceeded the number of whisper requests that they may make.\r\n See Rate Limits for this endpoint above.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SnoozeNextAd = new()
    {
        Method = HttpMethod.Post,
        Route = "/channels/ads/schedule/snooze",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "User’s next ad is successfully snoozed. Their snooze_count is decremented and snooze_refresh_time and next_ad_at are both updated.",
            HttpStatusCode.BadRequest => "The channel is not currently live.\r\nThe broadcaster ID is not valid.\r\nChannel does not have an upcoming scheduled ad break.",
            HttpStatusCode.TooManyRequests => "Channel has no snoozes left.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetAdSchedule = new()
    {
        Method = HttpMethod.Get,
        Route = "/channels/ads",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Returns the ad schedule information for the channel.",
            HttpStatusCode.BadRequest => "The broadcaster ID is not valid.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetModeratedChannels = new()
    {
        Method = HttpMethod.Get,
        Route = "/moderation/channels",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint SendChatMessage = new()
    {
        Method = HttpMethod.Post,
        Route = "/chat/messages",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully sent the specified broadcaster a message.",
            HttpStatusCode.BadRequest => "The broadcaster_id query parameter is required.\r\nThe ID in the broadcaster_id query parameter is not valid.\r\nThe sender_id query parameter is required.\r\nThe ID in the sender_id query parameter is not valid.\r\nThe text query parameter is required.\r\nThe ID in the reply_parent_message_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in the user_id query parameter must match the user ID in the access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:write:chat scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            HttpStatusCode.Forbidden => "The sender is not permitted to send chat messages to the broadcaster’s chat room.",
            HttpStatusCode.UnprocessableEntity => "The message is too large.",
            _ => "Unknown response code"
        }
    };

    public static readonly HelixEndpoint GetUserEmotes = new()
    {
        Method = HttpMethod.Get,
        Route = "/chat/emotes/user",
        SuccessStatusCode = HttpStatusCode.OK,
        GetResponseMessage = code => code switch
        {
            HttpStatusCode.OK => "Successfully retrieved the emotes.",
            HttpStatusCode.BadRequest => "The user_id query parameter is required\r\nThe ID in the user_id query parameter is not valid.",
            HttpStatusCode.Unauthorized => "The ID in user_id must match the user ID in the user access token.\r\nThe Authorization header is required and must contain a user access token.\r\nThe user access token must include the user:read:emotes scope.\r\nThe access token is not valid.\r\nThe client ID specified in the Client-Id header does not match the client ID specified in the access token.",
            _ => "Unknown response code"
        }
    };
}
