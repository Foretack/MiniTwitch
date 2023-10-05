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
/// Represents the IRC USERSTATE command
/// <para>Twitch docs: <see href="https://dev.twitch.tv/docs/irc/commands/#userstate"/>, <see href="https://dev.twitch.tv/docs/irc/commands/#userstate"/></para>
/// </summary>
public readonly struct Userstate
{
    private const string BROADCASTER_ROLE = "broadcaster/1";
    private const string VIP_ROLE = "vip/1";

    /// <summary>
    /// You as a message author
    /// </summary>
    public IUserstateSelf Self { get; init; }
    /// <summary>
    /// The channel where <see cref="Self"/> applies
    /// </summary>
    public IGazatuChannel Channel { get; init; }
    /// <summary>
    /// The emote sets you have
    /// </summary>
    public string EmoteSets { get; init; }
    /// <summary>
    /// Client nonce that of the corresponding message
    /// <para>Note: Can be <see cref="string.Empty"/></para>
    /// </summary>
    public string Nonce { get; init; }

    internal IrcClient? Source { get; init; }

    internal Userstate(IrcMessage message, IrcClient? source = null)
    {
        this.Source = source;

        string badgeInfo = string.Empty;
        string badges = string.Empty;
        Color color = default;
        string displayName = string.Empty;
        bool mod = false;
        bool vip = false;
        bool subscriber = false;
        bool turbo = false;
        UserType type = UserType.None;
        string channel = message.GetChannel();
        string emoteSets = string.Empty;
        string nonce = string.Empty;

        using IrcTags tags = message.ParseTags();
        foreach (IrcTag tag in tags)
        {
            if (tag.Key.Length == 0)
            {
                continue;
            }

            ReadOnlySpan<byte> tagKey = tag.Key.Span;
            ReadOnlySpan<byte> tagValue = tag.Value.Span;
            switch (tagKey.Sum())
            {

                //mod
                case (int)Tags.Mod:
                    mod = TagHelper.GetBool(tagValue);
                    break;

                //vip
                case (int)Tags.Vip:
                    vip = TagHelper.GetBool(tagValue);
                    break;

                //color
                case (int)Tags.Color:
                    color = TagHelper.GetColor(tagValue);
                    break;

                //turbo
                case (int)Tags.Turbo:
                    turbo = TagHelper.GetBool(tagValue);
                    break;

                //badges
                case (int)Tags.Badges:
                    badges = TagHelper.GetString(tagValue, true);
                    break;

                //user-type
                case (int)Tags.UserType when tagValue.Length > 0:
                    type = (UserType)tagValue.Sum();
                    break;

                //badge-info
                case (int)Tags.BadgeInfo:
                    badgeInfo = TagHelper.GetString(tagValue, true, true);
                    break;

                //emote-sets
                case (int)Tags.EmoteSets:
                    emoteSets = TagHelper.GetString(tagValue, true);
                    break;

                //subscriber
                case (int)Tags.Subscriber:
                    subscriber = TagHelper.GetBool(tagValue);
                    break;

                //client-nonce
                case (int)Tags.ClientNonce:
                    nonce = TagHelper.GetString(tagValue);
                    break;

                //display-name
                case (int)Tags.DisplayName:
                    displayName = TagHelper.GetString(tagValue);
                    break;
            }
        }

        this.Self = new MessageAuthor()
        {
            BadgeInfo = badgeInfo,
            ChatColor = color,
            Badges = badges,
            Name = this.Source?.Options.Username ?? displayName.ToLower(),
            DisplayName = displayName,
            IsMod = mod || badges.Contains(BROADCASTER_ROLE),
            IsSubscriber = subscriber,
            IsTurbo = turbo,
            IsVip = vip || badges.Contains(VIP_ROLE),
            Type = type
        };
        this.Channel = new IrcChannel()
        {
            Name = channel
        };
        this.EmoteSets = emoteSets;
        this.Nonce = nonce;
    }

    /// <summary>
    /// Construct a <see cref="Userstate"/> from a string. Useful for testing
    /// </summary>
    /// <param name="rawData">The raw IRC message</param>
    /// <returns><see cref="Userstate"/> with the related data</returns>
    public static Userstate Construct(string rawData)
    {
        ReadOnlyMemory<byte> memory = new(Encoding.UTF8.GetBytes(rawData));
        return new(new IrcMessage(memory));
    }
}