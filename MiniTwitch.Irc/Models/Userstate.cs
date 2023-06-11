using System.Text;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Interfaces;
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

    internal IrcClient? Source { get; init; }

    internal Userstate(ReadOnlyMemory<byte> memory, IrcClient? source = null)
    {
        this.Source = source;

        string badgeInfo = string.Empty;
        string badges = string.Empty;
        string color = string.Empty;
        string displayName = string.Empty;
        bool mod = false;
        bool vip = false;
        bool subscriber = false;
        bool turbo = false;
        UserType type = UserType.None;
        string channel = memory.Span.FindChannel(true);
        string emoteSets = string.Empty;

        using IrcTags tags = IrcParsing.ParseTags(ref memory);
        foreach (IrcTag tag in tags)
        {
            ReadOnlySpan<byte> tagKey = tag.Key.Span;
            ReadOnlySpan<byte> tagValue = tag.Value.Span;
            switch (tagKey.Sum())
            {

                //mod
                case 320:
                    mod = TagHelper.GetBool(ref tagValue);
                    break;

                //vip
                case 335:
                    vip = TagHelper.GetBool(ref tagValue);
                    break;

                //color
                case 543:
                    color = TagHelper.GetString(ref tagValue, true);
                    break;

                //turbo
                case 556:
                    turbo = TagHelper.GetBool(ref tagValue);
                    break;

                //badges
                case 614:
                    badges = TagHelper.GetString(ref tagValue, true);
                    break;

                //user-type
                case 942 when tagValue.Length > 0:
                    type = (UserType)tagValue.Sum();
                    break;

                //badge-info
                case 972:
                    badgeInfo = TagHelper.GetString(ref tagValue, true, true);
                    break;

                //emote-sets
                case 1030:
                    emoteSets = TagHelper.GetString(ref tagValue, true);
                    break;

                //subscriber
                case 1076:
                    subscriber = TagHelper.GetBool(ref tagValue);
                    break;

                //display-name
                case 1220:
                    displayName = TagHelper.GetString(ref tagValue);
                    break;
            }
        }

        this.Self = new MessageAuthor()
        {
            BadgeInfo = badgeInfo,
            ColorCode = color,
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
    }

    /// <summary>
    /// Construct a <see cref="Userstate"/> from a string. Useful for testing
    /// </summary>
    /// <param name="rawData">The raw IRC message</param>
    /// <returns><see cref="Userstate"/> with the related data</returns>
    public static Userstate Construct(string rawData)
    {
        ReadOnlyMemory<byte> memory = new(Encoding.UTF8.GetBytes(rawData));
        return new(memory);
    }
}