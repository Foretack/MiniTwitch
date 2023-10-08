using System.Drawing;
using System.Text;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Interfaces;
using MiniTwitch.Irc.Internal.Enums;
using MiniTwitch.Irc.Internal.Models;
using MiniTwitch.Irc.Internal.Parsing;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents the USERNOTICE command
/// <para>Twitch docs: <see href="https://dev.twitch.tv/docs/irc/commands/#usernotice"/>, <see href="https://dev.twitch.tv/docs/irc/tags/#usernotice-tags"/></para>
/// </summary>
public readonly struct Usernotice : IGiftSubNoticeIntro, IAnnouncementNotice, IPaidUpgradeNotice,
    ISubNotice, IGiftSubNotice, IRaidNotice, IPrimeUpgradeNotice, IEquatable<Usernotice>
{
    private const string VIP_ROLE = "vip/1";

    /// <inheritdoc/>
    public MessageAuthor Author { get; init; }
    /// <inheritdoc/>
    public IGiftSubRecipient Recipient { get; init; }
    /// <inheritdoc/>
    public IBasicChannel Channel { get; init; }
    /// <inheritdoc/>
    public SubPlan SubPlan { get; init; }
    /// <inheritdoc/>
    public AnnouncementColor Color { get; init; }
    /// <inheritdoc/>
    public string Emotes { get; init; }
    /// <inheritdoc/>
    public string Flags { get; init; }
    /// <inheritdoc/>
    public string Id { get; init; }
    /// <inheritdoc/>
    public string SubPlanName { get; init; }
    /// <inheritdoc/>
    public string SystemMessage { get; init; }
    /// <inheritdoc/>
    public string Message { get; init; }
    /// <inheritdoc/>
    public string GifterUsername { get; init; }
    /// <inheritdoc/>
    public string GifterDisplayName { get; init; }
    /// <inheritdoc/>
    public int CumulativeMonths { get; init; }
    /// <inheritdoc/>
    public int Months { get; init; }
    /// <inheritdoc/>
    public int MonthStreak { get; init; }
    /// <inheritdoc/>
    public int GiftedMonths { get; init; }
    /// <inheritdoc/>
    public int GiftCount { get; init; }
    /// <inheritdoc/>
    public int TotalGiftCount { get; init; }
    /// <inheritdoc/>
    public int ViewerCount { get; init; }
    /// <inheritdoc/>
    public bool ShouldShareStreak { get; init; } = default;

    /// <inheritdoc/>
    public long TmiSentTs { get; init; } = default;
    /// <inheritdoc/>
    public DateTimeOffset SentTimestamp => DateTimeOffset.FromUnixTimeMilliseconds(this.TmiSentTs);

    internal UsernoticeType MsgId { get; init; } = UsernoticeType.None;

    internal Usernotice(ref IrcMessage message)
    {
        // Author
        bool isMod = false;
        Color colorCode = default;
        string badges = string.Empty;
        long userId = 0;
        UserType userType = UserType.None;
        string badgeInfo = string.Empty;
        bool isSubscriber = false;
        string displayName = string.Empty;
        string username = string.Empty;
        bool isTurbo = false;

        // Recipient
        string recipientDisplayName = string.Empty;
        string recipientUsername = string.Empty;
        long recipientId = 0;

        // Channel
        string channelName = message.GetChannel();
        long channelId = 0;

        SubPlan subPlan = SubPlan.None;
        AnnouncementColor color = AnnouncementColor.Unknown;
        string emotes = string.Empty;
        string flags = string.Empty;
        string id = string.Empty;
        string subPlanName = string.Empty;
        string systemMessage = string.Empty;
        string content = string.Empty;
        string gifterUsername = string.Empty;
        string gifterDisplayName = string.Empty;
        int cumulativeMonths = 0;
        int months = 0;
        int monthStreak = 0;
        int giftedMonths = 0;
        int giftCount = 0;
        int totalGiftCount = 0;
        int viewerCount = 0;
        bool shouldShareStreak = false;

        using IrcTags tags = message.ParseTags();
        foreach (IrcTag tag in tags)
        {
            ReadOnlySpan<byte> tagKey = tag.Key.Span;
            ReadOnlySpan<byte> tagValue = tag.Value.Span;

            switch (tagKey.Sum())
            {
                //id
                case (int)Tags.Id:
                    id = TagHelper.GetString(tagValue);
                    break;

                //mod
                case (int)Tags.Mod:
                    isMod = TagHelper.GetBool(tagValue);
                    break;

                //flags
                case (int)Tags.Flags:
                    flags = TagHelper.GetString(tagValue);
                    break;

                //login
                case (int)Tags.Login:
                    username = TagHelper.GetString(tagValue);
                    break;

                //color
                case (int)Tags.Color:
                    colorCode = TagHelper.GetColor(tagValue);
                    break;

                //turbo 
                case (int)Tags.Turbo:
                    isTurbo = TagHelper.GetBool(tagValue);
                    break;

                //msg-id
                case (int)Tags.MsgId:
                    this.MsgId = (UsernoticeType)tagValue.Sum();
                    break;

                //badges
                case (int)Tags.Badges:
                    badges = TagHelper.GetString(tagValue, true);
                    break;

                //emotes
                case (int)Tags.Emotes:
                    emotes = TagHelper.GetString(tagValue);
                    break;

                //room-id
                case (int)Tags.RoomId:
                    channelId = TagHelper.GetLong(tagValue);
                    break;

                //user-id
                case (int)Tags.UserId:
                    userId = TagHelper.GetLong(tagValue);
                    break;

                //user-type
                case (int)Tags.UserType when tagValue.Length > 0:
                    userType = (UserType)tagValue.Sum();
                    break;

                //badge-info
                case (int)Tags.BadgeInfo:
                    badgeInfo = TagHelper.GetString(tagValue, true, true);
                    break;

                //system-msg
                case (int)Tags.SystemMsg:
                    systemMessage = TagHelper.GetString(tagValue, unescape: true);
                    break;

                //subscriber
                case (int)Tags.Subscriber:
                    isSubscriber = TagHelper.GetBool(tagValue);
                    break;

                //tmi-sent-ts
                case (int)Tags.TmiSentTs:
                    this.TmiSentTs = TagHelper.GetLong(tagValue);
                    break;

                //display-name
                case (int)Tags.DisplayName:
                    displayName = TagHelper.GetString(tagValue);
                    break;

                //msg-param-color
                case (int)Tags.MsgParamColor:
                    color = (AnnouncementColor)tagValue.Sum();
                    break;

                //msg-param-months
                case (int)Tags.MsgParamMonths:
                    months = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-sub-plan
                case (int)Tags.MsgParamSubPlan:
                    subPlan = (SubPlan)tagValue.Sum();
                    break;

                //msg-param-sender-name
                case (int)Tags.MsgParamSenderName:
                    gifterDisplayName = TagHelper.GetString(tagValue);
                    break;

                //msg-param-gift-months
                case (int)Tags.MsgParamGiftMonths:
                    giftedMonths = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-viewerCount
                case (int)Tags.MsgParamViewerCount:
                    viewerCount = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-recipient-id
                case (int)Tags.MsgParamRecipientId:
                    recipientId = TagHelper.GetLong(tagValue);
                    break;

                //msg-param-sender-login
                case (int)Tags.MsgParamSenderLogin:
                    gifterUsername = TagHelper.GetString(tagValue);
                    break;

                //msg-param-sender-count
                case (int)Tags.MsgParamSenderCount:
                    totalGiftCount = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-sub-plan-name
                case (int)Tags.MsgParamSubPlanName:
                    subPlanName = TagHelper.GetString(tagValue, true, true);
                    break;

                //msg-param-streak-months
                case (int)Tags.MsgParamStreakMonths:
                    monthStreak = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-mass-gift-count
                case (int)Tags.MsgParamMassGiftCount:
                    giftCount = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-cumulative-months
                case (int)Tags.MsgParamCumulativeMonths:
                    cumulativeMonths = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-recipient-user-name
                case (int)Tags.MsgParamRecipientUserName:
                    recipientUsername = TagHelper.GetString(tagValue);
                    break;

                //msg-param-should-share-streak
                case (int)Tags.MsgParamShouldShareStreak:
                    shouldShareStreak = TagHelper.GetBool(tagValue);
                    break;

                //msg-param-recipient-display-name
                case (int)Tags.MsgparamRecipientDisplayName:
                    recipientDisplayName = TagHelper.GetString(tagValue);
                    break;
            }
        }

        if (this.MsgId is UsernoticeType.Resub or UsernoticeType.Announcement)
        {
            content = message.HasMessageContent ? message.GetContent().Content : string.Empty;
        }

        this.Author = new MessageAuthor()
        {
            BadgeInfo = badgeInfo,
            Badges = badges,
            ChatColor = colorCode,
            DisplayName = displayName,
            Id = userId,
            IsMod = isMod,
            IsSubscriber = isSubscriber,
            Type = userType,
            Name = username,
            IsTurbo = isTurbo,
            IsVip = badges.Contains(VIP_ROLE)
        };
        this.Channel = new IrcChannel()
        {
            Name = channelName,
            Id = channelId
        };
        this.Recipient = new MessageAuthor()
        {
            DisplayName = recipientDisplayName,
            Name = recipientUsername,
            Id = recipientId
        };
        this.SubPlan = subPlan;
        this.Color = color;
        this.Emotes = emotes;
        this.Flags = flags;
        this.Id = id;
        this.SubPlanName = subPlanName;
        this.SystemMessage = systemMessage;
        this.Message = content;
        this.GifterUsername = gifterUsername;
        this.GifterDisplayName = gifterDisplayName;
        this.CumulativeMonths = cumulativeMonths;
        this.Months = months;
        this.MonthStreak = monthStreak;
        this.GiftedMonths = giftedMonths;
        this.GiftCount = giftCount;
        this.TotalGiftCount = totalGiftCount;
        this.ViewerCount = viewerCount;
        this.ShouldShareStreak = shouldShareStreak;
    }

    /// <summary>
    /// Construct a <see cref="Usernotice"/> from a string. Useful for testing
    /// </summary>
    /// <param name="rawData">The raw IRC message</param>
    /// <returns><see cref="Usernotice"/> with the related data</returns>
    public static Usernotice Construct(string rawData)
    {
        ReadOnlyMemory<byte> memory = new(Encoding.UTF8.GetBytes(rawData));
        var message = new IrcMessage(memory);
        return new(ref message);
    }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    /// <inheritdoc/>
    public bool Equals(Usernotice other) => this.Id == other.Id;
    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is Usernotice && Equals((Usernotice)obj);
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    /// <inheritdoc/>
    public static bool operator ==(Usernotice left, Usernotice right) => left.Equals(right);
    /// <inheritdoc/>
    public static bool operator !=(Usernotice left, Usernotice right) => !(left == right);
    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var code = new HashCode();
        code.Add(this.Id);
        code.Add(this.MsgId);
        return code.ToHashCode();
    }
}