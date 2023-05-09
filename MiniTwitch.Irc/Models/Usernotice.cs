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

    internal Usernotice(ReadOnlyMemory<byte> memory)
    {
        // Author
        bool isMod = false;
        string colorCode = string.Empty;
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
        string channelName = memory.Span.FindChannel();
        long channelId = 0;

        SubPlan subPlan = SubPlan.None;
        AnnouncementColor color = AnnouncementColor.Unknown;
        string emotes = string.Empty;
        string flags = string.Empty;
        string id = string.Empty;
        string subPlanName = string.Empty;
        string systemMessage = string.Empty;
        string message = string.Empty;
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

        using IrcTags tags = IrcParsing.ParseTags(memory);
        foreach (IrcTag tag in tags)
        {
            ReadOnlySpan<byte> tagKey = tag.Key.Span;
            ReadOnlySpan<byte> tagValue = tag.Value.Span;

            switch (tagKey.Sum())
            {
                //id
                case 205:
                    id = TagHelper.GetString(tagValue);
                    break;

                //mod
                case 320:
                    isMod = TagHelper.GetBool(tagValue);
                    break;

                //flags
                case 525:
                    flags = TagHelper.GetString(tagValue);
                    break;

                //login
                case 537:
                    username = TagHelper.GetString(tagValue);
                    break;

                //color
                case 543:
                    colorCode = TagHelper.GetString(tagValue, true);
                    break;

                //turbo 
                case 556:
                    isTurbo = TagHelper.GetBool(tagValue);
                    break;

                //msg-id
                case 577:
                    this.MsgId = (UsernoticeType)tagValue.Sum();
                    break;

                //badges
                case 614:
                    badges = TagHelper.GetString(tagValue, true);
                    break;

                //emotes
                case 653:
                    emotes = TagHelper.GetString(tagValue);
                    break;

                //room-id
                case 695:
                    channelId = TagHelper.GetLong(tagValue);
                    break;

                //user-id
                case 697:
                    userId = TagHelper.GetLong(tagValue);
                    break;

                //user-type
                case 942 when tagValue.Length > 0:
                    userType = (UserType)tagValue.Sum();
                    break;

                //badge-info
                case 972:
                    badgeInfo = TagHelper.GetString(tagValue, true, true);
                    break;

                //system-msg
                case 1049:
                    systemMessage = TagHelper.GetString(tagValue, unescape: true);
                    break;

                //subscriber
                case 1076:
                    isSubscriber = TagHelper.GetBool(tagValue);
                    break;

                //tmi-sent-ts
                case 1093:
                    this.TmiSentTs = TagHelper.GetLong(tagValue);
                    break;

                //display-name
                case 1220:
                    displayName = TagHelper.GetString(tagValue);
                    break;

                //msg-param-color
                case 1489:
                    color = (AnnouncementColor)tagValue.Sum();
                    break;

                //msg-param-months
                case 1611:
                    months = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-sub-plan
                case 1748:
                    subPlan = (SubPlan)tagValue.Sum();
                    break;

                //msg-param-sender-name
                case 2049:
                    gifterDisplayName = TagHelper.GetString(tagValue);
                    break;

                //msg-param-gift-months
                case 2082:
                    giftedMonths = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-viewerCount
                case 2125:
                    viewerCount = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-recipient-id
                case 2159:
                    recipientId = TagHelper.GetLong(tagValue);
                    break;

                //msg-param-sender-login
                case 2169:
                    gifterUsername = TagHelper.GetString(tagValue);
                    break;

                //msg-param-sender-count
                case 2185:
                    totalGiftCount = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-sub-plan-name
                case 2210:
                    subPlanName = TagHelper.GetString(tagValue, true, true);
                    break;

                //msg-param-streak-months
                case 2306:
                    monthStreak = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-mass-gift-count
                case 2451:
                    giftCount = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-cumulative-months
                case 2743:
                    cumulativeMonths = TagHelper.GetInt(tagValue);
                    break;

                //msg-param-recipient-user-name
                case 2863:
                    recipientUsername = TagHelper.GetString(tagValue);
                    break;

                //msg-param-should-share-streak
                case 2872:
                    shouldShareStreak = TagHelper.GetBool(tagValue);
                    break;

                //msg-param-recipient-display-name
                case 3174:
                    recipientDisplayName = TagHelper.GetString(tagValue);
                    break;
            }
        }

        if (this.MsgId is UsernoticeType.Resub or UsernoticeType.Announcement)
        {
            message = memory.Span.FindContent(maybeEmpty: true).Content;
        }

        this.Author = new MessageAuthor()
        {
            BadgeInfo = badgeInfo,
            Badges = badges,
            ColorCode = colorCode,
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
        this.Message = message;
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
        return new(memory);
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