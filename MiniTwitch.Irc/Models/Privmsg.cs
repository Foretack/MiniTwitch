using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Interfaces;
using MiniTwitch.Irc.Internal.Models;
using MiniTwitch.Irc.Internal.Parsing;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents a chat message
/// <para>Twitch docs: <see href="https://dev.twitch.tv/docs/irc/tags/#privmsg-tags"/></para>
/// <para>Note: Object can be implicitly converted to <see langword="string"/>, which returns <see cref="Privmsg.Content"/></para>
/// </summary>
public readonly struct Privmsg : IUnixTimestamped, IEquatable<Privmsg>
{
    /// <summary>
    /// Author of the message
    /// </summary>
    public MessageAuthor Author { get; }
    /// <summary>
    /// Reply contents of the message
    /// <para>Note: Values are <see cref="string.Empty"/> if <see cref="MessageReply.HasContent"/> is <see langword="false"/></para>
    /// </summary>
    public MessageReply Reply { get; init; }
    /// <summary>
    /// HypeChat information about this message
    /// <para>Note: Values are <see cref="string.Empty"/> and <see langword="default"/> if <see cref="HypeChat.HasContent"/> is <see langword="false"/></para>
    /// </summary>
    public HypeChat HypeChat { get; init; }
    /// <summary>
    /// The channel where the message was sent
    /// </summary>
    public IBasicChannel Channel { get; init; }
    /// <summary>
    /// Content of the message
    /// </summary>
    public string Content { get; init; }
    /// <summary>
    /// Emote sets in the content of the message
    /// <para><see cref="string.Empty"/> if there are none</para>
    /// </summary>
    public string Emotes { get; init; }
    /// <summary>
    /// Automod flags in the content of the message
    /// <para><see cref="string.Empty"/> if there are none</para>
    /// </summary>
    public string Flags { get; init; }
    /// <summary>
    /// Unique ID to identify the message
    /// </summary>
    public string Id { get; init; }
    /// <summary>
    /// The amount of bits cheered in the message
    /// <para>Default is 0</para>
    /// </summary>
    public int Bits { get; init; }
    /// <summary>
    /// Client nonce that was sent with the message
    /// <para>Note: Can be <see cref="string.Empty"/></para>
    /// </summary>
    public string Nonce { get; init; }
    /// <summary>
    /// Whether the was the author's first message in the channel
    /// </summary>
    public bool IsFirstMessage { get; init; }
    /// <summary>
    /// Whether the message is an action. Action messages are sent with .me
    /// </summary>
    public bool IsAction { get; init; }
    /// <summary>
    /// Whether the user is a returning chatter
    /// <para>This tag is not documented <see href="https://dev.twitch.tv/docs/irc/tags/#privmsg-tags"/> </para>
    /// </summary>
    public bool IsReturningChatter { get; init; }

    /// <inheritdoc/>
    public long TmiSentTs { get; init; }
    /// <inheritdoc/>
    public DateTimeOffset SentTimestamp => DateTimeOffset.FromUnixTimeMilliseconds(this.TmiSentTs);

    internal IrcClient? Source { get; init; }

    internal Privmsg(ReadOnlyMemory<byte> memory, IrcClient? source = null)
    {
        this.Source = source;

        // MessageAuthor
        string badges = string.Empty;
        string badgeInfo = string.Empty;
        Color color = default;
        string displayName = string.Empty;
        string username = memory.Span.FindUsername();
        long uid = 0;
        bool mod = false;
        bool sub = false;
        bool turbo = false;
        bool vip = false;
        UserType userType = UserType.None;

        // MessageReply
        string replyMessageId = string.Empty;
        long replyUserId = 0;
        string replyMessageBody = string.Empty;
        string replyUsername = string.Empty;
        string replyDisplayName = string.Empty;
        string threadParentMessageid = string.Empty;
        string threadParentUsername = string.Empty;

        //HypeChat
        int paidAmount = 0;
        int cPaidAmount = 0;
        string currency = string.Empty;
        int exponent = 0;
        bool isSystemMessage = false;
        string level = string.Empty;

        // IBasicChannel
        string channelName = memory.Span.FindChannel();
        long channelId = 0;

        (this.Content, this.IsAction) = memory.Span.FindContent(maybeAction: true);

        string emotes = string.Empty;
        string flags = string.Empty;
        string id = string.Empty;
        int bits = 0;
        string nonce = string.Empty;
        long tmiSentTs = 0;
        bool firstMsg = false;
        bool returningChatter = false;

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
                    mod = TagHelper.GetBool(tagValue);
                    break;

                //vip
                case 335:
                    vip = TagHelper.GetBool(tagValue);
                    break;

                //bits
                case 434:
                    bits = TagHelper.GetInt(tagValue);
                    break;

                //flags
                case 525:
                    flags = TagHelper.GetString(tagValue);
                    break;

                //color
                case 543:
                    color = TagHelper.GetColor(tagValue);
                    break;

                //turbo
                case 556:
                    turbo = TagHelper.GetBool(tagValue);
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
                    uid = TagHelper.GetLong(tagValue);
                    break;

                //first-msg
                case 924:
                    firstMsg = TagHelper.GetBool(tagValue);
                    break;

                //user-type
                case 942 when tagValue.Length > 0:
                    userType = (UserType)tagValue.Sum();
                    break;

                //badge-info
                case 972:
                    badgeInfo = TagHelper.GetString(tagValue, true, true);
                    break;

                //subscriber
                case 1076:
                    sub = TagHelper.GetBool(tagValue);
                    break;

                //tmi-sent-ts
                case 1093:
                    tmiSentTs = TagHelper.GetLong(tagValue);
                    break;

                //client-nonce
                case 1215:
                    nonce = TagHelper.GetString(tagValue);
                    break;

                //display-name
                case 1220:
                    displayName = TagHelper.GetString(tagValue);
                    break;

                //returning-chatter
                case 1782:
                    returningChatter = TagHelper.GetBool(tagValue);
                    break;

                //reply-parent-msg-id
                case 1873:
                    replyMessageId = TagHelper.GetString(tagValue);
                    break;

                //reply-parent-user-id
                case 1993:
                    replyUserId = TagHelper.GetLong(tagValue);
                    break;

                //reply-parent-msg-body
                case 2098:
                    replyMessageBody = TagHelper.GetString(tagValue, unescape: true);
                    break;

                //pinned-chat-paid-level
                case 2139:
                    level = TagHelper.GetString(tagValue, intern: true);
                    break;

                //pinned-chat-paid-amount
                case 2263:
                    paidAmount = TagHelper.GetInt(tagValue);
                    break;

                //reply-parent-user-login
                case 2325:
                    replyUsername = TagHelper.GetString(tagValue);
                    break;

                //pinned-chat-paid-currency
                case 2478:
                    currency = TagHelper.GetString(tagValue, intern: true);
                    break;

                //pinned-chat-paid-exponent
                case 2484:
                    exponent = TagHelper.GetInt(tagValue);
                    break;

                //reply-parent-display-name
                case 2516:
                    replyDisplayName = TagHelper.GetString(tagValue);
                    break;

                //reply-thread-parent-msg-id
                case 2550:
                    threadParentMessageid = TagHelper.GetString(tagValue);
                    break;

                //reply-thread-parent-user-login
                case 3002:
                    threadParentUsername = TagHelper.GetString(tagValue);
                    break;

                //pinned-chat-paid-canonical-amount
                case 3244:
                    cPaidAmount = TagHelper.GetInt(tagValue);
                    break;

                //pinned-chat-paid-is-system-message
                case 3331:
                    isSystemMessage = TagHelper.GetBool(tagValue);
                    break;
            }
        }

        this.Author = new MessageAuthor()
        {
            BadgeInfo = badgeInfo,
            Badges = badges,
            ChatColor = color,
            DisplayName = displayName,
            Id = uid,
            IsMod = mod,
            IsSubscriber = sub,
            Type = userType,
            Name = username,
            IsTurbo = turbo,
            IsVip = vip
        };
        this.Reply = new MessageReply()
        {
            ParentMessageId = replyMessageId,
            ParentDisplayName = replyDisplayName,
            ParentMessage = replyMessageBody,
            ParentUserId = replyUserId,
            ParentUsername = replyUsername,
            ParentThreadMessageId = threadParentMessageid,
            ParentThreadUsername = threadParentUsername
        };
        this.HypeChat = new HypeChat()
        {
            PaidAmount = paidAmount,
            CanonicalPaidAmount = cPaidAmount,
            PaymentCurrency = currency,
            Exponent = exponent,
            IsSystemMessage = isSystemMessage,
            Level = level
        };
        this.Channel = new IrcChannel()
        {
            Name = channelName,
            Id = channelId
        };
        this.Emotes = emotes;
        this.Flags = flags;
        this.Id = id;
        this.Bits = bits;
        this.Nonce = nonce;
        this.TmiSentTs = tmiSentTs;
        this.IsFirstMessage = firstMsg;
        this.IsReturningChatter = returningChatter;
    }

    /// <summary>
    /// Reply to the message
    /// </summary>
    /// <param name="reply">The reply to send</param>
    /// <param name="action">Prepend .me</param>
    /// <returns></returns>
    public ValueTask ReplyWith(string reply, bool action = false) => this.Source?.ReplyTo(this, reply, action) ?? ValueTask.CompletedTask;

    /// <summary>
    /// Construct a message from a string. Useful for testing
    /// </summary>
    /// <param name="rawData">The raw IRC message <para>Example input: @badge-info=subscriber/10;badges=subscriber/6;color=#F2647B;display-name=occluder;emotes=;first-msg=0;flags=;id=1eef01e3-634a-493b-b1a7-4f65040fa986;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1679231590118;turbo=0;user-id=783267696;user-type= :occluder!occluder@occluder.tmi.twitch.tv PRIVMSG #pajlada :-tags lol!</para></param>
    /// <returns><see cref="Privmsg"/> with the related data</returns>
    public static Privmsg Construct(string rawData)
    {
        ReadOnlyMemory<byte> memory = new(Encoding.UTF8.GetBytes(rawData));
        return new(memory);
    }

    /// <inheritdoc/>
    public bool Equals(Privmsg other) => other.Id == this.Id;

    /// <inheritdoc/>
    public bool Equals(string? other) => this.Content.Equals(other);

    // Don't remove this, compiler wont shut up
#pragma warning disable CS8765
    /// <inheritdoc/>
    public override bool Equals([NotNull] object obj) => obj is Privmsg && Equals((Privmsg)obj);
#pragma warning restore CS8765
    /// <inheritdoc/>
    public static bool operator ==(Privmsg left, Privmsg right) => left.Equals(right);
    /// <inheritdoc/>
    public static bool operator !=(Privmsg left, Privmsg right) => !(left == right);
    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(this.Id);
        hash.Add(this.Content);
        return hash.ToHashCode();
    }

    /// <inheritdoc/>
    public static implicit operator string(Privmsg message) => message.Content;
}