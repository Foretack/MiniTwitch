using MiniTwitch.Irc.Models;

namespace MiniTwitch.Irc.Enums;

/// <summary>
/// Represents ignorable IRC commands
/// </summary>
[Flags]
public enum IgnoreCommand
{
    /// <summary>
    /// Don't skip anything
    /// </summary>
    None = 0,
    /// <summary>
    /// Skip PRIVMSGs
    /// <para>Affected events: <see cref="IrcClient.OnMessage"/></para>
    /// </summary>
    PRIVMSG = 1 << 1,
    /// <summary>
    /// Ignore USERNOTICEs
    /// <para>Affected events: <see cref="IrcClient.OnAnnouncement"/>, <see cref="IrcClient.OnGiftedSubNotice"/>, <see cref="IrcClient.OnGiftedSubNoticeIntro"/>, <see cref="IrcClient.OnPaidUpgradeNotice"/>, </para>
    /// <para><see cref="IrcClient.OnPrimeUpgradeNotice"/>, <see cref="IrcClient.OnRaidNotice"/>, <see cref="IrcClient.OnSubscriptionNotice"/></para>
    /// </summary>
    USERNOTICE = 1 << 2,
    /// <summary>
    /// Ignore CLEARCHATs
    /// <para>Affected events: <see cref="IrcClient.OnChatClear"/>, <see cref="IrcClient.OnUserBan"/>, <see cref="IrcClient.OnUserTimeout"/></para>
    /// </summary>
    CLEARCHAT = 1 << 3,
    /// <summary>
    /// Ignore CLEARMSGs
    /// <para>Affected events: <see cref="IrcClient.OnMessageDelete"/></para>
    /// </summary>
    CLEARMSG = 1 << 4,
    /// <summary>
    /// Ignore WHISPERs
    /// <para>Affected events: <see cref="IrcClient.OnWhisper"/></para>
    /// </summary>
    WHISPER = 1 << 5,
    /// <summary>
    /// Ignore USERSTATEs
    /// <para>Affected events: <see cref="IrcClient.OnUserstate"/></para>
    /// <para>Affected properties: <see cref="ClientOptions.ModMessageRateLimit"/></para>
    /// </summary>
    USERSTATE = 1 << 6,
    /// <summary>
    /// Ignore JOINs
    /// </summary>
    JOIN = 1 << 7,
    /// <summary>
    /// Ignore PARTs
    /// <para>Affected events: <see cref="IrcClient.OnChannelPart"/></para>
    /// </summary>
    PART = 1 << 8,
    /// <summary>
    /// Ignore NOTICEs
    /// <para>Affected events: <see cref="IrcClient.OnNotice"/></para>
    /// </summary>
    NOTICE = 1 << 9,
    /// <summary>
    /// Ignore ROOMSTATEs
    /// <para>Affected events: <see cref="IrcClient.OnChannelJoin"/></para>
    /// </summary>
    ROOMSTATE = 1 << 10,
}
