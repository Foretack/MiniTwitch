using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniTwitch.Helix.Models;

#pragma warning disable CS8618
public static class Responses
{
    // TODO: give "Datum"s proper names when possible

    public class StartCommercial : SingleResponse<StartCommercial.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("length")] int Length,
            [property: JsonPropertyName("message")] string Message,
            [property: JsonPropertyName("retry_after")] int RetryAfter
        );
    }

    public class GetExtensionAnalytics : PaginableResponse<GetExtensionAnalytics.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("extension_id")] string ExtensionId,
            [property: JsonPropertyName("URL")] string Url,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("date_range")] DateRange DateRange
        );
        public record DateRange(
            [property: JsonPropertyName("started_at")] DateTime StartedAt,
            [property: JsonPropertyName("ended_at")] DateTime EndedAt
        );
    }

    public class GetGameAnalytics : PaginableResponse<GetGameAnalytics.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("game_id")] string ExtensionId,
            [property: JsonPropertyName("URL")] string Url,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("date_range")] DateRange DateRange
        );
        public record DateRange(
            [property: JsonPropertyName("started_at")] DateTime StartedAt,
            [property: JsonPropertyName("ended_at")] DateTime EndedAt
        );
    }

    public class GetBitsLeaderboard : BaseResponse<GetBitsLeaderboard.Datum>
{
        [JsonPropertyName("date_range")]
        public StartEndDate DateRange { get; init; }
        [JsonPropertyName("total")]
        public int Total { get; init; }

        public record Datum(
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("user_login")] string Username,
            [property: JsonPropertyName("user_name")] string DisplayName,
            [property: JsonPropertyName("rank")] int Rank,
            [property: JsonPropertyName("score")] int Score
        );
        public record StartEndDate(
            [property: JsonPropertyName("started_at")] DateTime StartedAt,
            [property: JsonPropertyName("ended_at")] DateTime EndedAt
        );
    }

    public class GetCheermotes : BaseResponse<GetCheermotes.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("prefix")] string Prefix,
            [property: JsonPropertyName("tiers")] IReadOnlyList<Tier> Tiers,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("order")] int Order,
            [property: JsonPropertyName("last_updated")] DateTime LastUpdated,
            [property: JsonPropertyName("is_charitable")] bool IsCharitable
        );
        public record Tier(
            [property: JsonPropertyName("min_bits")] int MinBits,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("color")] string Color,
            [property: JsonPropertyName("images")] Images Images,
            [property: JsonPropertyName("can_cheer")] bool CanCheer,
            [property: JsonPropertyName("show_in_bits_card")] bool ShowInBitsCard
        );
        public record Images(
            [property: JsonPropertyName("dark")] ImageSet Dark,
            [property: JsonPropertyName("light")] ImageSet Light
        );
        public record ImageSet(
            [property: JsonPropertyName("animated")] IDictionary<string, string> Animated,
            [property: JsonPropertyName("static")] IDictionary<string, string> Static
        );
    }

    public class GetExtensionTransactions : PaginableResponse<GetExtensionTransactions.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("timestamp")] DateTime Timestamp,
            [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
            [property: JsonPropertyName("user_id")] string UserId,
            [property: JsonPropertyName("user_login")] string UserLogin,
            [property: JsonPropertyName("user_name")] string UserName,
            [property: JsonPropertyName("product_type")] string ProductType,
            [property: JsonPropertyName("product_data")] ProductData ProductData
        );
        public record ProductData(
            [property: JsonPropertyName("domain")] string Domain,
            [property: JsonPropertyName("sku")] string Sku,
            [property: JsonPropertyName("cost")] Cost Cost,
            [property: JsonPropertyName("inDevelopment")] bool InDevelopment,
            [property: JsonPropertyName("displayName")] string DisplayName,
            [property: JsonPropertyName("expiration")] string Expiration,
            [property: JsonPropertyName("broadcast")] bool Broadcast
        );
        public record Cost(
            [property: JsonPropertyName("amount")] int Amount,
            [property: JsonPropertyName("type")] string Type
        );
    }

    public class GetChannelInformation : BaseResponse<GetChannelInformation.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] long Id,
            [property: JsonPropertyName("broadcaster_login")] string Name,
            [property: JsonPropertyName("broadcaster_name")] string DisplayName,
            [property: JsonPropertyName("broadcaster_language")] string Language,
            [property: JsonPropertyName("game_name")] string GameName,
            [property: JsonPropertyName("game_id")] string GameId,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("delay")] int Delay,
            [property: JsonPropertyName("tags")] IReadOnlyList<string> Tags
        );
    }

    public class GetChannelEditors : BaseResponse<GetChannelEditors.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("user_id")] long Id,
            [property: JsonPropertyName("user_name")] string DisplayName,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt
        );
    }

    public class GetFollowedChannels : PaginableResponse<GetFollowedChannels.Datum>
    {
        [JsonPropertyName("total")]
        public int Total { get; init; }

        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] long Id,
            [property: JsonPropertyName("broadcaster_login")] string Name,
            [property: JsonPropertyName("broadcaster_name")] string DisplayName,
            [property: JsonPropertyName("followed_at")] DateTime FollowedAt
        );
    }

    public class GetChannelFollowers : PaginableResponse<GetChannelFollowers.Datum>
    {
        [JsonPropertyName("total")]
        public int Total { get; init; }

        public record Datum(
            [property: JsonPropertyName("user_id")] long Id,
            [property: JsonPropertyName("user_login")] string Name,
            [property: JsonPropertyName("user_name")] string DisplayName,
            [property: JsonPropertyName("followed_at")] DateTime FollowedAt
        );
    }

    public class CreateCustomRewards : BaseResponse<CreateCustomRewards.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("id")] string RewardId,
            [property: JsonPropertyName("image")] Image? Image,
            [property: JsonPropertyName("background_color")] string BackgroundColor,
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("cost")] long Cost,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("prompt")] string Prompt,
            [property: JsonPropertyName("is_user_input_required")] bool IsUserInputRequired,
            [property: JsonPropertyName("max_per_stream_setting")] MaxPerStreamSetting MaxPerStreamSetting,
            [property: JsonPropertyName("max_per_user_per_stream_setting")] MaxPerUserPerStreamSetting MaxPerUserPerStreamSetting,
            [property: JsonPropertyName("global_cooldown_setting")] GlobalCooldownSetting GlobalCooldownSetting,
            [property: JsonPropertyName("is_paused")] bool IsPaused,
            [property: JsonPropertyName("is_in_stock")] bool IsInStock,
            [property: JsonPropertyName("default_image")] Image DefaultImage,
            [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool ShouldRedemptionsSkipRequestQueue,
            [property: JsonPropertyName("redemptions_redeemed_current_stream")] int? RedemptionsRedeemedInCurrentStream,
            [property: JsonPropertyName("cooldown_expires_at")] DateTime? CooldownExpiresAt
        );

        public record struct Image(
           [property: JsonPropertyName("url_1x")] string Url1x,
           [property: JsonPropertyName("url_2x")] string Url2x,
           [property: JsonPropertyName("url_4x")] string Url4x
        );

        public record struct GlobalCooldownSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("global_cooldown_seconds")] long GlobalCooldownSeconds
        );

        public record struct MaxPerStreamSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("max_per_stream")] long MaxPerStream
        );

        public record struct MaxPerUserPerStreamSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("max_per_user_per_stream")] long MaxPerUserPerStream
        );
    }

    public class GetCustomReward : BaseResponse<GetCustomReward.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("id")] string RewardId,
            [property: JsonPropertyName("image")] Image? Image,
            [property: JsonPropertyName("background_color")] string BackgroundColor,
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("cost")] long Cost,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("prompt")] string Prompt,
            [property: JsonPropertyName("is_user_input_required")] bool IsUserInputRequired,
            [property: JsonPropertyName("max_per_stream_setting")] MaxPerStreamSetting MaxPerStreamSetting,
            [property: JsonPropertyName("max_per_user_per_stream_setting")] MaxPerUserPerStreamSetting MaxPerUserPerStreamSetting,
            [property: JsonPropertyName("global_cooldown_setting")] GlobalCooldownSetting GlobalCooldownSetting,
            [property: JsonPropertyName("is_paused")] bool IsPaused,
            [property: JsonPropertyName("is_in_stock")] bool IsInStock,
            [property: JsonPropertyName("default_image")] Image DefaultImage,
            [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool ShouldRedemptionsSkipRequestQueue,
            [property: JsonPropertyName("redemptions_redeemed_current_stream")] int? RedemptionsRedeemedInCurrentStream,
            [property: JsonPropertyName("cooldown_expires_at")] DateTime? CooldownExpiresAt
        );

        public record struct Image(
           [property: JsonPropertyName("url_1x")] string Url1x,
           [property: JsonPropertyName("url_2x")] string Url2x,
           [property: JsonPropertyName("url_4x")] string Url4x
        );

        public record struct GlobalCooldownSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("global_cooldown_seconds")] long GlobalCooldownSeconds
        );

        public record struct MaxPerStreamSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("max_per_stream")] long MaxPerStream
        );

        public record struct MaxPerUserPerStreamSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("max_per_user_per_stream")] long MaxPerUserPerStream
        );
    }

    public class GetCustomRewardRedemption : BaseResponse<GetCustomRewardRedemption.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("user_name")] string UserDisplayName,
            [property: JsonPropertyName("user_login")] string UserName,
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("user_input")] string UserInput,
            [property: JsonPropertyName("redeemed_at")] DateTime RedeemedAt,
            [property: JsonPropertyName("reward")] RedemptionReward Reward
        )
        {
            internal string status = "None";
            public RewardRedemptionStatus Status => Enum.Parse<RewardRedemptionStatus>(status);
        };

        public record struct RedemptionReward(
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("prompt")] string Prompt,
            [property: JsonPropertyName("cost")] long Cost
        );
    }

    public class UpdateCustomReward : BaseResponse<UpdateCustomReward.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("id")] string RewardId,
            [property: JsonPropertyName("image")] Image? Image,
            [property: JsonPropertyName("background_color")] string BackgroundColor,
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("cost")] long Cost,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("prompt")] string Prompt,
            [property: JsonPropertyName("is_user_input_required")] bool IsUserInputRequired,
            [property: JsonPropertyName("max_per_stream_setting")] MaxPerStreamSetting MaxPerStreamSetting,
            [property: JsonPropertyName("max_per_user_per_stream_setting")] MaxPerUserPerStreamSetting MaxPerUserPerStreamSetting,
            [property: JsonPropertyName("global_cooldown_setting")] GlobalCooldownSetting GlobalCooldownSetting,
            [property: JsonPropertyName("is_paused")] bool IsPaused,
            [property: JsonPropertyName("is_in_stock")] bool IsInStock,
            [property: JsonPropertyName("default_image")] Image DefaultImage,
            [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool ShouldRedemptionsSkipRequestQueue,
            [property: JsonPropertyName("redemptions_redeemed_current_stream")] int? RedemptionsRedeemedInCurrentStream,
            [property: JsonPropertyName("cooldown_expires_at")] DateTime? CooldownExpiresAt
        );

        public record struct Image(
           [property: JsonPropertyName("url_1x")] string Url1x,
           [property: JsonPropertyName("url_2x")] string Url2x,
           [property: JsonPropertyName("url_4x")] string Url4x
        );

        public record struct GlobalCooldownSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("global_cooldown_seconds")] long GlobalCooldownSeconds
        );

        public record struct MaxPerStreamSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("max_per_stream")] long MaxPerStream
        );

        public record struct MaxPerUserPerStreamSetting(
            [property: JsonPropertyName("is_enabled")] bool IsEnabled,
            [property: JsonPropertyName("max_per_user_per_stream")] long MaxPerUserPerStream
        );
    }

    public class UpdateRedemptionStatus : BaseResponse<UpdateRedemptionStatus.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("user_name")] string UserDisplayName,
            [property: JsonPropertyName("user_login")] string UserName,
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("user_input")] string UserInput,
            [property: JsonPropertyName("redeemed_at")] DateTime RedeemedAt,
            [property: JsonPropertyName("reward")] RedemptionReward Reward
        )
        {
            internal string status = "None";
            public RewardRedemptionStatus Status => Enum.Parse<RewardRedemptionStatus>(status);
        };
        public record struct RedemptionReward(
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("prompt")] string Prompt,
            [property: JsonPropertyName("cost")] long Cost
        );
    }

    public class GetCharityCampaign : BaseResponse<GetCharityCampaign.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
            [property: JsonPropertyName("charity_name")] string CharityName,
            [property: JsonPropertyName("charity_description")] string CharityDescription,
            [property: JsonPropertyName("charity_logo")] string CharityLogo,
            [property: JsonPropertyName("charity_website")] string CharityWebsite,
            [property: JsonPropertyName("current_amount")] CurrentAmount CurrentAmount,
            [property: JsonPropertyName("target_amount")] TargetAmount TargetAmount
        );

        public record struct CurrentAmount(
           [property: JsonPropertyName("value")] int Value,
            [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
            [property: JsonPropertyName("currency")] string Currency
        );

        public record struct TargetAmount(
            [property: JsonPropertyName("value")] int Value,
            [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
            [property: JsonPropertyName("currency")] string Currency
        );
    }

    public class GetCharityCampaignDonations : BaseResponse<GetCharityCampaignDonations.Datum>, IPaginable
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; }

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("campaign_id")] string CampaignId,
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("user_login")] string Username,
            [property: JsonPropertyName("user_name")] string UserDisplayName,
            [property: JsonPropertyName("amount")] Donation Amount
        );

        public record Donation(
            [property: JsonPropertyName("value")] int Value,
            [property: JsonPropertyName("decimal_places")] int DecimalPlaces,
            [property: JsonPropertyName("curency")] string Currency
        )
        {
            public double GetAmount() => this.Value * Math.Pow(10, -DecimalPlaces);
        };
    }

    public class GetChatters : BaseResponse<GetChatters.Datum>, IPaginable
    {
        [JsonPropertyName("total")]
        public int Total { get; init; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; }

        public record Datum(
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("user_login")] string Username,
            [property: JsonPropertyName("user_name")] string UserDisplayName
        );
    }

    public class GetChannelEmotes : BaseResponse<GetChannelEmotes.Datum>
    {
        [JsonPropertyName("template")]
        public string Template { get; init; }

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("images")] Images Images,
            [property: JsonPropertyName("tier")] string Tier,
            [property: JsonPropertyName("emote_type")] string EmoteType,
            [property: JsonPropertyName("emote_set_id")] string EmoteSetId,
            [property: JsonPropertyName("format")] IReadOnlyList<string> Formats,
            [property: JsonPropertyName("scale")] IReadOnlyList<string> Scales,
            [property: JsonPropertyName("theme_mode")] IReadOnlyList<string> ThemeModes
        );

        public record Images(
            [property: JsonPropertyName("url_1x")] string Url1x,
            [property: JsonPropertyName("url_2x")] string Url2x,
            [property: JsonPropertyName("url_4x")] string Url4x
        );
    }

    public class GetGlobalEmotes : BaseResponse<GetGlobalEmotes.Datum>
    {
        [JsonPropertyName("template")]
        public string Template { get; init; }

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("images")] Images Images,
            [property: JsonPropertyName("format")] IReadOnlyList<string> Formats,
            [property: JsonPropertyName("scale")] IReadOnlyList<string> Scales,
            [property: JsonPropertyName("theme_mode")] IReadOnlyList<string> ThemeModes
        );

        public record Images(
            [property: JsonPropertyName("url_1x")] string Url1x,
            [property: JsonPropertyName("url_2x")] string Url2x,
            [property: JsonPropertyName("url_4x")] string Url4x
        );
    }

    public class GetEmoteSets : BaseResponse<GetEmoteSets.Emote>
    {
        [JsonPropertyName("template")]
        public string Template { get; init; }

        public record Emote(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("images")] Images Images,
            [property: JsonPropertyName("emote_type")] string EmoteType,
            [property: JsonPropertyName("emote_set_id")] string EmoteSetId,
            [property: JsonPropertyName("owner_id")] long OwnerId,
            [property: JsonPropertyName("format")] IReadOnlyList<string> Formats,
            [property: JsonPropertyName("scale")] IReadOnlyList<string> Scales,
            [property: JsonPropertyName("theme_mode")] IReadOnlyList<string> ThemeModes
        );

        public record Images(
            [property: JsonPropertyName("url_1x")] string Url1x,
            [property: JsonPropertyName("url_2x")] string Url2x,
            [property: JsonPropertyName("url_4x")] string Url4x
        );
    }

    public class GetChannelChatBadges : BaseResponse<GetChannelChatBadges.BadgeSet>
    {
        public record BadgeSet(
            [property: JsonPropertyName("set_id")] string SetId,
            [property: JsonPropertyName("versions")] IReadOnlyList<Version> Versions
        );

        public record Version(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("image_url_1x")] string ImageUrl1x,
            [property: JsonPropertyName("image_url_2x")] string ImageUrl2x,
            [property: JsonPropertyName("image_url_4x")] string ImageUrl4x,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("click_action")] string ClickAction,
            [property: JsonPropertyName("click_url")] string ClickUrl
        );
    }

    public class GetGlobalChatBadges : BaseResponse<GetChannelChatBadges.BadgeSet>
    { }

    public class GetChatSettings : BaseResponse<GetChatSettings.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("slow_mode")] bool SlowMode,
            [property: JsonPropertyName("slow_mode_wait_time")] int SlowModeWaitTime,
            [property: JsonPropertyName("follower_mode")] bool FollowerMode,
            [property: JsonPropertyName("follower_mode_duration")] int FollowerModeDuration,
            [property: JsonPropertyName("subscriber_mode")] bool SubscriberMode,
            [property: JsonPropertyName("emote_mode")] bool EmoteMode,
            [property: JsonPropertyName("unique_chat_mode")] bool UniqueChatMode,
            [property: JsonPropertyName("non_moderator_chat_delay")] bool NonModeratorChatDelay,
            [property: JsonPropertyName("non_moderator_chat_delay_duration")] int NonModeratorChatDelayDuration
        );
    }

    public class UpdateChatSettings : BaseResponse<GetChatSettings.Datum>
    { }

    public class BanUser
    {
        [JsonPropertyName("data")]
        public Datum[] Data { get; init; }

        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("moderator_id")] long ModeratorId,
            [property: JsonPropertyName("user_id")] string UserId,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("end_time")] DateTime? EndTime
        );
    }

    public class GetUserBlockList : IPaginable
    {
        [JsonPropertyName("data")]
        public Datum[] Data { get; init; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; }

        public record Datum(
            [property: JsonPropertyName("user_id")] long Id,
            [property: JsonPropertyName("user_login")] string Name,
            [property: JsonPropertyName("display_name")] string DisplayName
        );
    }

    public class GetUserChatColor : BaseResponse<GetUserChatColor.User>
    {
        public record User(
            [property: JsonPropertyName("user_id")] long Id,
            [property: JsonPropertyName("user_name")] string DisplayName,
            [property: JsonPropertyName("user_login")] string Name,
            [property: JsonPropertyName("color")] string Color
        );
    }

    public class CreateClip : BaseResponse<CreateClip.Clip>
    {
        public record Clip(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("edit_url")] string EditUrl
        );
    }

    public class GetClips : BaseResponse<GetClips.Clip>, IPaginable
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; }

        public record Clip(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("url")] string Url,
            [property: JsonPropertyName("embed_url")] string EmbedUrl,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
            [property: JsonPropertyName("creator_id")] long CreatorId,
            [property: JsonPropertyName("creator_name")] string CreatorName,
            [property: JsonPropertyName("video_id")] string VideoId,
            [property: JsonPropertyName("game_id")] string GameId,
            [property: JsonPropertyName("language")] string Language,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("view_count")] int ViewCount,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
            [property: JsonPropertyName("duration")] int Duration,
            [property: JsonPropertyName("vod_offset")] int VodOffset,
            [property: JsonPropertyName("is_featured")] bool IsFeatured
        );
    }

    public class GetContentClassificationLabels : BaseResponse<GetContentClassificationLabels.Label>
    {
        public record Label(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("name")] string Name
        );
    }

    public class GetDropsEntitlements : BaseResponse<GetDropsEntitlements.Entitlement>, IPaginable
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; }

        public record Entitlement(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("benefit_id")] string BenefitId,
            [property: JsonPropertyName("timestamp")] DateTime Timestamp,
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("game_id")] string GameId,
            [property: JsonPropertyName("fulfillment_status")] string FulfillmentStatus,
            [property: JsonPropertyName("last_updated")] DateTime LastUpdated
        );
    }

    public class UpdateDropsEntitlements : BaseResponse<UpdateDropsEntitlements.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("ids")] IReadOnlyList<string> Ids
        );
    }

    public class GetExtensionConfigurationSegment : BaseResponse<GetExtensionConfigurationSegment.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("segment")] string Segment,
            [property: JsonPropertyName("content")] string Content,
            [property: JsonPropertyName("version")] string Version
        );
    }

    public class GetExtensionLiveChannels : BaseResponse<GetExtensionLiveChannels.Datum>, IPaginable
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; }

        public record Datum(
        [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
        [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
        [property: JsonPropertyName("game_name")] string GameName,
        [property: JsonPropertyName("game_id")] string GameId,
        [property: JsonPropertyName("title")] string Title
    );
    }

    public class GetExtensionSecrets : BaseResponse<GetExtensionSecrets.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("format_version")] int FormatVersion,
            [property: JsonPropertyName("secrets")] IReadOnlyList<Secret> Secrets
        );

        public record Secret(
            [property: JsonPropertyName("content")] string Content,
            [property: JsonPropertyName("active_at")] DateTime ActiveAt,
            [property: JsonPropertyName("expires_at")] DateTime ExpiresAt
        );
    }

    public class CreateExtensionSecret : BaseResponse<GetExtensionSecrets.Datum>
    { }

    public class GetExtensions : BaseResponse<GetExtensionSecrets.Datum>
    {
        public record Component(
            [property: JsonPropertyName("viewer_url")] string ViewerUrl,
            [property: JsonPropertyName("aspect_width")] int AspectWidth,
            [property: JsonPropertyName("aspect_height")] int AspectHeight,
            [property: JsonPropertyName("aspect_ratio_x")] int AspectRatioX,
            [property: JsonPropertyName("aspect_ratio_y")] int AspectRatioY,
            [property: JsonPropertyName("autoscale")] bool Autoscale,
            [property: JsonPropertyName("scale_pixels")] int ScalePixels,
            [property: JsonPropertyName("target_height")] int TargetHeight,
            [property: JsonPropertyName("size")] int Size,
            [property: JsonPropertyName("zoom")] bool Zoom,
            [property: JsonPropertyName("zoom_pixels")] int ZoomPixels,
            [property: JsonPropertyName("can_link_external_content")] bool CanLinkExternalContent
        );

        public record Datum(
            [property: JsonPropertyName("author_name")] string AuthorName,
            [property: JsonPropertyName("bits_enabled")] bool BitsEnabled,
            [property: JsonPropertyName("can_install")] bool CanInstall,
            [property: JsonPropertyName("configuration_location")] string ConfigurationLocation,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("eula_tos_url")] string EulaTosUrl,
            [property: JsonPropertyName("has_chat_support")] bool HasChatSupport,
            [property: JsonPropertyName("icon_url")] string IconUrl,
            [property: JsonPropertyName("icon_urls")] IconUrls IconUrls,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("privacy_policy_url")] string PrivacyPolicyUrl,
            [property: JsonPropertyName("request_identity_link")] bool RequestIdentityLink,
            [property: JsonPropertyName("screenshot_urls")] IReadOnlyList<string> ScreenshotUrls,
            [property: JsonPropertyName("state")] string State,
            [property: JsonPropertyName("subscriptions_support_level")] string SubscriptionsSupportLevel,
            [property: JsonPropertyName("summary")] string Summary,
            [property: JsonPropertyName("support_email")] string SupportEmail,
            [property: JsonPropertyName("version")] string Version,
            [property: JsonPropertyName("viewer_summary")] string ViewerSummary,
            [property: JsonPropertyName("views")] Views Views,
            [property: JsonPropertyName("allowlisted_config_urls")] IReadOnlyList<string> AllowlistedConfigUrls,
            [property: JsonPropertyName("allowlisted_panel_urls")] IReadOnlyList<string> AllowlistedPanelUrls
        );

        public record IconUrls(
            [property: JsonPropertyName("100x100")] string Url100x100,
            [property: JsonPropertyName("24x24")] string Url24x24,
            [property: JsonPropertyName("300x200")] string Url300x200
        );

        public record Mobile(
            [property: JsonPropertyName("viewer_url")] string ViewerUrl
        );

        public record Panel(
            [property: JsonPropertyName("viewer_url")] string ViewerUrl,
            [property: JsonPropertyName("height")] int Height,
            [property: JsonPropertyName("can_link_external_content")] bool CanLinkExternalContent
        );

        public record VideoOverlay(
            [property: JsonPropertyName("viewer_url")] string ViewerUrl,
            [property: JsonPropertyName("can_link_external_content")] bool CanLinkExternalContent
        );

        public record Views(
            [property: JsonPropertyName("mobile")] Mobile Mobile,
            [property: JsonPropertyName("panel")] Panel Panel,
            [property: JsonPropertyName("video_overlay")] VideoOverlay VideoOverlay,
            [property: JsonPropertyName("component")] Component Component
        );
    }

    public class GetReleasedExtensions : BaseResponse<GetExtensions.Datum>
    {

    }

    public class GetExtensionBitsProducts : BaseResponse<GetExtensionBitsProducts.Datum>
    {
        public record Cost(
            [property: JsonPropertyName("amount")] int Amount,
            [property: JsonPropertyName("type")] string Type
        );

        public record Datum(
            [property: JsonPropertyName("sku")] string Sku,
            [property: JsonPropertyName("cost")] Cost Cost,
            [property: JsonPropertyName("in_development")] bool InDevelopment,
            [property: JsonPropertyName("display_name")] string DisplayName,
            [property: JsonPropertyName("expiration")] DateTime Expiration,
            [property: JsonPropertyName("is_broadcast")] bool IsBroadcast
        );
    }

    public class UpdateExtensionBitsProduct : BaseResponse<GetExtensionBitsProducts.Datum>
    {

    }

    public class CreateEventSubSubscription : BaseResponse<CreateEventSubSubscription.Datum>
    {
        [JsonPropertyName("total")]
        public int Total { get; init; }
        [JsonPropertyName("total_cost")]
        public int TotalCost { get; init; }
        [JsonPropertyName("max_total_cost")] 
        public int MaxTotalCost { get; init; }

        public record Condition(
            [property: JsonPropertyName("user_id")] long UserId
        );

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("version")] string Version,
            [property: JsonPropertyName("condition")] Condition Condition,
            [property: JsonPropertyName("created_at")] string CreatedAt,
            [property: JsonPropertyName("transport")] Transport Transport,
            [property: JsonPropertyName("cost")] int Cost
        );

        public record Transport(
            [property: JsonPropertyName("method")] string Method,
            [property: JsonPropertyName("callback")] string Callback
        );
    }

    public class GetEventSubSubscriptions : BaseResponse<GetEventSubSubscriptions.Datum>, IPaginable
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; }
        [JsonPropertyName("total_cost")]
        public int TotalCost { get; init; }
        [JsonPropertyName("max_total_cost")]
        public int MaxTotalCost { get; init; }
        [JsonPropertyName("total")]
        public int Total { get; init; }

        public record Condition(
            [property: JsonPropertyName("broadcaster_user_id")] long BroadcasterUserId,
            [property: JsonPropertyName("user_id")] long UserId
        );

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("version")] string Version,
            [property: JsonPropertyName("condition")] Condition Condition,
            [property: JsonPropertyName("created_at")] string CreatedAt,
            [property: JsonPropertyName("transport")] Transport Transport,
            [property: JsonPropertyName("cost")] int Cost
        );

        public record Root(
            [property: JsonPropertyName("total")] int Total,
            [property: JsonPropertyName("data")] IReadOnlyList<Datum> Data,
            [property: JsonPropertyName("total_cost")] int TotalCost,
            [property: JsonPropertyName("max_total_cost")] int MaxTotalCost,
            [property: JsonPropertyName("pagination")] Pagination Pagination
        );

        public record Transport(
            [property: JsonPropertyName("method")] string Method,
            [property: JsonPropertyName("callback")] string Callback
        );
    }

    public class GetTopGames : BaseResponse<GetTopGames.Datum>, IPaginable
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; }

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("box_art_url")] string BoxArtUrl,
            [property: JsonPropertyName("igdb_id")] string IgdbId
        );
    }

    public class GetGames : PaginableResponse<GetTopGames.Datum>
    { }

    public class GetCreatorGoals : BaseResponse<GetCreatorGoals.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("current_amount")] int CurrentAmount,
            [property: JsonPropertyName("target_amount")] int TargetAmount,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt
        );
    }

    public class GetChannelGuestStarSettings : BaseResponse<GetChannelGuestStarSettings.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("is_moderator_send_live_enabled")] bool IsModeratorSendLiveEnabled,
            [property: JsonPropertyName("slot_count")] int SlotCount,
            [property: JsonPropertyName("is_browser_source_audio_enabled")] bool IsBrowserSourceAudioEnabled,
            [property: JsonPropertyName("layout")] string Layout,
            [property: JsonPropertyName("browser_source_token")] string BrowserSourceToken
        );
    }

    public class GetGuestStarSession : SingleResponse<GetGuestStarSession.Datum>
    {
        public record AudioSettings(
           [property: JsonPropertyName("is_available")] bool IsAvailable,
           [property: JsonPropertyName("is_host_enabled")] bool IsHostEnabled,
           [property: JsonPropertyName("is_guest_enabled")] bool IsGuestEnabled
       );

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("guests")] IReadOnlyList<Guest> Guests
        );

        public record Guest(
            [property: JsonPropertyName("slot_id")] string SlotId,
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("user_display_name")] string DisplayName,
            [property: JsonPropertyName("user_login")] string Username,
            [property: JsonPropertyName("is_live")] bool IsLive,
            [property: JsonPropertyName("volume")] int Volume,
            [property: JsonPropertyName("assigned_at")] DateTime AssignedAt,
            [property: JsonPropertyName("audio_settings")] AudioSettings AudioSettings,
            [property: JsonPropertyName("video_settings")] VideoSettings VideoSettings
        );

        public record VideoSettings(
            [property: JsonPropertyName("is_available")] bool IsAvailable,
            [property: JsonPropertyName("is_host_enabled")] bool IsHostEnabled,
            [property: JsonPropertyName("is_guest_enabled")] bool IsGuestEnabled
        );
    }

    public class CreateGuestStarSession : SingleResponse<GetGuestStarSession.Datum>
    { }

    public class EndGuestStarSession : SingleResponse<GetGuestStarSession.Datum>
    { }

    public class GetGuestStarInvites : BaseResponse<GetGuestStarInvites.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("invited_at")] DateTime InvitedAt,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("is_audio_enabled")] bool IsAudioEnabled,
            [property: JsonPropertyName("is_video_enabled")] bool IsVideoEnabled,
            [property: JsonPropertyName("is_audio_available")] bool IsAudioAvailable,
            [property: JsonPropertyName("is_video_available")] bool IsVideoAvailable
        );

    }

    public class GetHypeTrainEvents : PaginableResponse<GetHypeTrainEvents.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("event_type")] string EventType,
            [property: JsonPropertyName("event_timestamp")] DateTime EventTimestamp,
            [property: JsonPropertyName("version")] string Version,
            [property: JsonPropertyName("event_data")] EventData EventData
        );

        public record EventData(
            [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
            [property: JsonPropertyName("cooldown_end_time")] string CooldownEndTime,
            [property: JsonPropertyName("expires_at")] string ExpiresAt,
            [property: JsonPropertyName("goal")] int Goal,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("last_contribution")] Contribution LastContribution,
            [property: JsonPropertyName("level")] int Level,
            [property: JsonPropertyName("started_at")] string StartedAt,
            [property: JsonPropertyName("top_contributions")] IReadOnlyList<Contribution> TopContributions,
            [property: JsonPropertyName("total")] int Total
        );

        public record Contribution(
            [property: JsonPropertyName("total")] int Total,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("user")] long UserId
        );

    }

    public class CheckAutoModStatus : BaseResponse<CheckAutoModStatus.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("msg_id")] string MessageId,
            [property: JsonPropertyName("is_permitted")] bool IsPermitted
        );
    }

    public class GetAutoModSettings : SingleResponse<GetAutoModSettings.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("moderator_id")] long ModeratorId,
            [property: JsonPropertyName("overall_level")] int? OverallLevel,
            [property: JsonPropertyName("disability")] int Disability,
            [property: JsonPropertyName("aggression")] int Aggression,
            [property: JsonPropertyName("sexuality_sex_or_gender")] int SexualitySexOrGender,
            [property: JsonPropertyName("misogyny")] int Misogyny,
            [property: JsonPropertyName("bullying")] int Bullying,
            [property: JsonPropertyName("swearing")] int Swearing,
            [property: JsonPropertyName("race_ethnicity_or_religion")] int RaceEthnicityOrReligion,
            [property: JsonPropertyName("sex_based_terms")] int SexBasedTerms
        );
    }

    public class UpdateAutoModSettings : SingleResponse<GetAutoModSettings.Datum>
    { }

    public class GetBannedUsers : PaginableResponse<GetBannedUsers.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("user_login")] string Username,
            [property: JsonPropertyName("user_name")] string UserDisplayName,
            [property: JsonPropertyName("expires_at")] DateTime ExpiresAt,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("reason")] string Reason,
            [property: JsonPropertyName("moderator_id")] long ModeratorId,
            [property: JsonPropertyName("moderator_login")] string ModeratorName,
            [property: JsonPropertyName("moderator_name")] string ModeratorDisplayName
        );
    }

    public class GetBlockedTerms : PaginableResponse<GetBlockedTerms.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("moderator_id")] long ModeratorId,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("text")] string Text,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("updated_at")] DateTime? UpdatedAt,
            [property: JsonPropertyName("expires_at")] DateTime? ExpiresAt
        );
    }

    public class AddBlockedTerm : SingleResponse<GetBlockedTerms.Datum>
    {
    }

    public class GetModerators : PaginableResponse<GetModerators.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("user_id")] long Id,
            [property: JsonPropertyName("user_login")] string Name,
            [property: JsonPropertyName("user_name")] string DisplayName
        );
    }

    public class GetVIPs : PaginableResponse<GetVIPs.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("user_id")] long Id,
            [property: JsonPropertyName("user_login")] string Name,
            [property: JsonPropertyName("user_name")] string DisplayName
        );
    }

    public class UpdateShieldModeStatus : SingleResponse<UpdateShieldModeStatus.Datum> 
    {
        public record Datum(
            [property: JsonPropertyName("is_active")] bool IsActive,
            [property: JsonPropertyName("moderator_id")] long ModeratorId,
            [property: JsonPropertyName("moderator_name")] string ModeratorDisplayName,
            [property: JsonPropertyName("moderator_login")] string ModeratorName,
            [property: JsonPropertyName("last_activated_at")] DateTime LastActivatedAt
        );
    }

    public class GetShieldModeStatus : SingleResponse<GetShieldModeStatus.Datum>
    {
        public record Datum(
           [property: JsonPropertyName("is_active")] bool IsActive,
           [property: JsonPropertyName("moderator_id")] long ModeratorId,
           [property: JsonPropertyName("moderator_name")] string ModeratorDisplayName,
           [property: JsonPropertyName("moderator_login")] string ModeratorName,
           [property: JsonPropertyName("last_activated_at")] DateTime LastActivatedAt
       );
    }

    public class GetPolls : PaginableResponse<GetPolls.Datum>
    {
        public record Choice(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("votes")] int Votes,
            [property: JsonPropertyName("channel_points_votes")] int ChannelPointsVotes
        );

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("choices")] IReadOnlyList<Choice> Choices,
            [property: JsonPropertyName("channel_points_voting_enabled")] bool ChannelPointsVotingEnabled,
            [property: JsonPropertyName("channel_points_per_vote")] int ChannelPointsPerVote,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("duration")] int Duration,
            [property: JsonPropertyName("started_at")] DateTime StartedAt,
            [property: JsonPropertyName("ended_at")] DateTime? EndedAt
        );
    }

    public class CreatePoll : SingleResponse<CreatePoll.Datum>
    {
        public record Choice(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("votes")] int Votes,
            [property: JsonPropertyName("channel_points_votes")] int ChannelPointsVotes
        );

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("choices")] IReadOnlyList<Choice> Choices,
            [property: JsonPropertyName("channel_points_voting_enabled")] bool ChannelPointsVotingEnabled,
            [property: JsonPropertyName("channel_points_per_vote")] int ChannelPointsPerVote,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("duration")] int Duration,
            [property: JsonPropertyName("started_at")] DateTime StartedAt
        );
    }

    public class EndPoll : SingleResponse<EndPoll.Datum>
    {
        public record Choice(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("votes")] int Votes,
            [property: JsonPropertyName("channel_points_votes")] int ChannelPointsVotes
        );

        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("choices")] IReadOnlyList<Choice> Choices,
            [property: JsonPropertyName("channel_points_voting_enabled")] bool ChannelPointsVotingEnabled,
            [property: JsonPropertyName("channel_points_per_vote")] int ChannelPointsPerVote,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("duration")] int Duration,
            [property: JsonPropertyName("started_at")] DateTime StartedAt,
            [property: JsonPropertyName("ended_at")] DateTime? EndedAt
        );
    }

    public class GetPredictions : PaginableResponse<GetPredictions.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("winning_outcome_id")] string? WinningOutcomeId,
            [property: JsonPropertyName("outcomes")] IReadOnlyList<Outcome> Outcomes,
            [property: JsonPropertyName("prediction_window")] int PredictionWindow,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("ended_at")] DateTime? EndedAt,
            [property: JsonPropertyName("locked_at")] DateTime? LockedAt
        );

        public record Outcome(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("users")] int Users,
            [property: JsonPropertyName("channel_points")] int ChannelPoints,
            [property: JsonPropertyName("top_predictors")] object TopPredictors,
            [property: JsonPropertyName("color")] string Color
        );
    }

    public class CreatePrediction : SingleResponse<CreatePrediction.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("winning_outcome_id")] string? WinningOutcomeId,
            [property: JsonPropertyName("outcomes")] IReadOnlyList<Outcome> Outcomes,
            [property: JsonPropertyName("prediction_window")] int PredictionWindow,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("ended_at")] DateTime? EndedAt,
            [property: JsonPropertyName("locked_at")] DateTime? LockedAt
        );

        public record Outcome(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("users")] int Users,
            [property: JsonPropertyName("channel_points")] int ChannelPoints,
            [property: JsonPropertyName("top_predictors")] object TopPredictors,
            [property: JsonPropertyName("color")] string Color
        );
    }

    public class EndPrediction : SingleResponse<EndPrediction.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("winning_outcome_id")] string? WinningOutcomeId,
            [property: JsonPropertyName("outcomes")] IReadOnlyList<Outcome> Outcomes,
            [property: JsonPropertyName("prediction_window")] int PredictionWindow,
            [property: JsonPropertyName("status")] string Status,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("ended_at")] DateTime? EndedAt,
            [property: JsonPropertyName("locked_at")] DateTime? LockedAt
        );

        public record Outcome(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("users")] int Users,
            [property: JsonPropertyName("channel_points")] int ChannelPoints,
            [property: JsonPropertyName("top_predictors")] object TopPredictors,
            [property: JsonPropertyName("color")] string Color
        );
    }

    public class StartARaid : SingleResponse<StartARaid.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("is_mature")] bool IsMature
        );
    }

    public class GetChannelStreamSchedule 
    {
        [property: JsonPropertyName("data")]
        public ScheduleData Data { get; init; }

        public record Category(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name
        );

        public record ScheduleData(
            [property: JsonPropertyName("segments")] IReadOnlyList<Segment> Segments,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("vacation")] Vacation Vacation
        );

        public record Segment(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("start_time")] DateTime StartTime,
            [property: JsonPropertyName("end_time")] DateTime EndTime,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("canceled_until")] DateTime? CanceledUntil,
            [property: JsonPropertyName("category")] Category Category,
            [property: JsonPropertyName("is_recurring")] bool IsRecurring
        );

        public record Vacation(
            [property: JsonPropertyName("start_time")] DateTime StartTime,
            [property: JsonPropertyName("end_time")] DateTime EndTime
        );
    }

    public class CreateChannelStreamScheduleSegment
    {
        [property: JsonPropertyName("data")]
        public ScheduleData Data { get; init; }

        public record Category(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name
        );

        public record ScheduleData(
            [property: JsonPropertyName("segments")] IReadOnlyList<Segment> Segments,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("vacation")] Vacation Vacation
        );

        public record Segment(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("start_time")] DateTime StartTime,
            [property: JsonPropertyName("end_time")] DateTime EndTime,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("canceled_until")] DateTime? CanceledUntil,
            [property: JsonPropertyName("category")] Category Category,
            [property: JsonPropertyName("is_recurring")] bool IsRecurring
        );

        public record Vacation(
            [property: JsonPropertyName("start_time")] DateTime StartTime,
            [property: JsonPropertyName("end_time")] DateTime EndTime
        );
    }

    public class UpdateChannelStreamScheduleSegment
    {

        [JsonPropertyName("data")]
        public ScheduleData Data { get; init; }

        public record Category(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name
        );

        public record ScheduleData(
            [property: JsonPropertyName("segments")] IReadOnlyList<Segment> Segments,
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("vacation")] Vacation Vacation
        );

        public record Segment(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("start_time")] DateTime StartTime,
            [property: JsonPropertyName("end_time")] DateTime EndTime,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("canceled_until")] object CanceledUntil,
            [property: JsonPropertyName("category")] Category Category,
            [property: JsonPropertyName("is_recurring")] bool IsRecurring
        );

        public record Vacation(
            [property: JsonPropertyName("start_time")] DateTime StartTime,
            [property: JsonPropertyName("end_time")] DateTime EndTime
        );
    }

    public class SearchCategories : PaginableResponse<SearchCategories.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("box_art_url")] string BoxArtUrl
        );
    }

    public class SearchChannels : PaginableResponse<SearchChannels.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_language")] string BroadcasterLanguage,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("display_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("game_id")] string GameId,
            [property: JsonPropertyName("game_name")] string GameName,
            [property: JsonPropertyName("id")] long BroadcasterId,
            [property: JsonPropertyName("is_live")] bool IsLive,
            [property: JsonPropertyName("tags")] IReadOnlyList<string> Tags,
            [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("started_at")] DateTime? StartedAt
        );
    }

    public class GetStreamKey : SingleResponse<GetStreamKey.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("stream_key")] string StreamKey
        );
    }

    public class GetStreams : PaginableResponse<GetStreams.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_language")] string BroadcasterLanguage,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("display_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("game_id")] string GameId,
            [property: JsonPropertyName("game_name")] string GameName,
            [property: JsonPropertyName("id")] long BroadcasterId,
            [property: JsonPropertyName("is_live")] bool IsLive,
            [property: JsonPropertyName("tags")] IReadOnlyList<string> Tags,
            [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("started_at")] DateTime? StartedAt
        );
    }

    public class GetFollowedStreams : PaginableResponse<GetStreams.Datum>
    {
        public record Datum(
           [property: JsonPropertyName("broadcaster_language")] string BroadcasterLanguage,
           [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
           [property: JsonPropertyName("display_name")] string BroadcasterDisplayName,
           [property: JsonPropertyName("game_id")] string GameId,
           [property: JsonPropertyName("game_name")] string GameName,
           [property: JsonPropertyName("id")] long BroadcasterId,
           [property: JsonPropertyName("is_live")] bool IsLive,
           [property: JsonPropertyName("tags")] IReadOnlyList<string> Tags,
           [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
           [property: JsonPropertyName("title")] string Title,
           [property: JsonPropertyName("started_at")] DateTime? StartedAt
       );
    }

    public class CreateStreamMarker : SingleResponse<CreateStreamMarker.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("position_seconds")] int PositionSeconds
        );
    }

    public class GetStreamMarkers : PaginableResponse<GetStreamMarkers.Datum>
    {
        public record Datum(
           [property: JsonPropertyName("user_id")] long UserId,
           [property: JsonPropertyName("user_name")] string UserDisplayName,
           [property: JsonPropertyName("user_login")] string Username,
           [property: JsonPropertyName("videos")] IReadOnlyList<Video> Videos
       );

        public record Marker(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("position_seconds")] int PositionSeconds,
            [property: JsonPropertyName("URL")] string URL
        );

        public record Video(
            [property: JsonPropertyName("video_id")] string VideoId,
            [property: JsonPropertyName("markers")] IReadOnlyList<Marker> Markers
        );
    }

    public class GetBroadcasterSubscriptions : PaginableResponse<GetBroadcasterSubscriptions.Datum>
    {
        [property: JsonPropertyName("total")]
        public int Total { get; init; }
        [property: JsonPropertyName("points")]
        public int Points { get; init; }

        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            // TODO: this should be a long
            [property: JsonPropertyName("gifter_id")] string GifterId,
            [property: JsonPropertyName("gifter_login")] string GifterName,
            [property: JsonPropertyName("gifter_name")] string GifterDisplayName,
            [property: JsonPropertyName("is_gift")] bool IsGift,
            [property: JsonPropertyName("tier")] string Tier,
            [property: JsonPropertyName("plan_name")] string PlanName,
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("user_name")] string UserDisplayName,
            [property: JsonPropertyName("user_login")] string Username
        );
    }

    public class CheckUserSubscription : SingleResponse<CheckUserSubscription.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
            [property: JsonPropertyName("is_gift")] bool IsGift,
            [property: JsonPropertyName("tier")] string Tier
        );
    }

    public class GetChannelTeams : BaseResponse<GetChannelTeams.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
            [property: JsonPropertyName("broadcaster_name")] string BroadcasterDisplayName,
            [property: JsonPropertyName("broadcaster_login")] string BroadcasterName,
            [property: JsonPropertyName("background_image_url")] string? BackgroundImageUrl,
            [property: JsonPropertyName("banner")] string? Banner,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("updated_at")] DateTime? UpdatedAt,
            [property: JsonPropertyName("info")] string Info,
            [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
            [property: JsonPropertyName("team_name")] string TeamName,
            [property: JsonPropertyName("team_display_name")] string TeamDisplayName,
            [property: JsonPropertyName("id")] string Id
        );
    }

    public class GetTeams
    {
        public record Datum(
            [property: JsonPropertyName("users")] IReadOnlyList<User> Users,
            [property: JsonPropertyName("background_image_url")] string? BackgroundImageUrl,
            [property: JsonPropertyName("banner")] string? Banner,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("updated_at")] DateTime UpdatedAt,
            [property: JsonPropertyName("info")] string Info,
            [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
            [property: JsonPropertyName("team_name")] string TeamName,
            [property: JsonPropertyName("team_display_name")] string TeamDisplayName,
            [property: JsonPropertyName("id")] string Id
        );

        public record User(
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("user_name")] string UserDisplayName,
            [property: JsonPropertyName("user_login")] string Username
        );
    }

    public class GetUsers : BaseResponse<GetUsers.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] long Id,
            [property: JsonPropertyName("login")] string Name,
            [property: JsonPropertyName("display_name")] string DisplayName,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("broadcaster_type")] string BroadcasterType,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("profile_image_url")] string ProfileImageUrl,
            [property: JsonPropertyName("offline_image_url")] string OfflineImageUrl,
            [property: JsonPropertyName("email")] string? Email,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt
        );
    }

    public class UpdateUser : SingleResponse<UpdateUser.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] long Id,
            [property: JsonPropertyName("login")] string Name,
            [property: JsonPropertyName("display_name")] string DisplayName,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("broadcaster_type")] string BroadcasterType,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("profile_image_url")] string ProfileImageUrl,
            [property: JsonPropertyName("offline_image_url")] string OfflineImageUrl,
            [property: JsonPropertyName("email")] string? Email,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt
        );
    }

    public class GetUserExtensions : BaseResponse<GetUserExtensions.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("version")] string Version,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("can_activate")] bool CanActivate,
            [property: JsonPropertyName("type")] IReadOnlyList<string> Type
        );
    }

    public class GetUserActiveExtensions
    {
        [JsonPropertyName("data")]
        public ExtensionsData Data { get; init; }

        public record Component(
            [property: JsonPropertyName("active")] bool Active,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("version")] string Version,
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("x")] int X,
            [property: JsonPropertyName("y")] int Y
        );

        public record Panel(
            [property: JsonPropertyName("active")] bool Active,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("version")] string Version,
            [property: JsonPropertyName("name")] string Name
        );

        public record Overlay(
            [property: JsonPropertyName("active")] bool Active,
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("version")] string Version,
            [property: JsonPropertyName("name")] string Name
        );

        public record ExtensionsData(
            [property: JsonPropertyName("panel")] Dictionary<int, Panel> Panel,
            [property: JsonPropertyName("overlay")] Dictionary<int, Overlay> Overlay,
            [property: JsonPropertyName("component")] Dictionary<int, Component> Component
        );
    }

    public class GetVideos : PaginableResponse<GetVideos.Datum>
    {
        public record Datum(
            [property: JsonPropertyName("id")] string Id,
            [property: JsonPropertyName("stream_id")] string? StreamId,
            [property: JsonPropertyName("user_id")] long UserId,
            [property: JsonPropertyName("user_login")] string UserName,
            [property: JsonPropertyName("user_name")] string UserDisplayName,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("description")] string Description,
            [property: JsonPropertyName("created_at")] DateTime CreatedAt,
            [property: JsonPropertyName("published_at")] DateTime PublishedAt,
            [property: JsonPropertyName("url")] string Url,
            [property: JsonPropertyName("thumbnail_url")] string ThumbnailUrl,
            [property: JsonPropertyName("view_count")] int ViewCount,
            [property: JsonPropertyName("language")] string Language,
            [property: JsonPropertyName("type")] string Type,
            [property: JsonPropertyName("duration")] string Duration,
            [property: JsonPropertyName("muted_segments")] IReadOnlyList<MutedSegment>? MutedSegments
        );

        public record MutedSegment(
            [property: JsonPropertyName("duration")] int Duration,
            [property: JsonPropertyName("offset")] int Offset
        );
    }
}
#pragma warning restore CS8618