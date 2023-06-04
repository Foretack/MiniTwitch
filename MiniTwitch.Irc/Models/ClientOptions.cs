using Microsoft.Extensions.Logging;
using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Interfaces;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// An object used for client configuration
/// </summary>
public sealed class ClientOptions : IMembershipClientOptions
{
    /// <summary>
    /// The username of the account
    /// </summary>
    public string Username { get; set; } = string.Empty;
    /// <summary>
    /// The OAuth token of the account
    /// <para>Note: Prepending "oauth:" is not necessary</para>
    /// </summary>
    public string OAuth { get; set; } = string.Empty;
    /// <summary>
    /// IRC commands to ignore from being fully parsed and handled. Multiple values can be set with <see langword="|"/>
    /// <para>Note: This can help with CPU and memory usage, but it will stop corresponding events from firing</para>
    /// <para>Only use it if you know what you are doing!</para>
    /// <para>Default is <see cref="IgnoreCommand.None"/></para>
    /// </summary>
    public IgnoreCommand IgnoreCommands { get; set; } = IgnoreCommand.None;
    /// <summary>
    /// Whether to connect anonymously or not
    /// <para>Note: You will not be able to send messages if connect anonymously</para>
    /// <para>Default is <see langword="false"/></para>
    /// </summary>
    public bool Anonymous { get; set; } = false;
    /// <summary>
    /// Whether to hide the sending of <see cref="Username"/> and <see cref="OAuth"/> from logging (if a logger through <see cref="Logger"/> is provided)
    /// <para>Default is <see langword="true"/></para>
    /// </summary>
    public bool HideAuthenticationLogs { get; set; } = true;
    /// <summary>
    /// Logging destination
    /// <para>Adding a logger is not required, but it's highly recommended</para>
    /// </summary>
    public ILogger? Logger { get; set; }
    /// <summary>
    /// The amount of outgoing JOINs allowed in a 10 second time period
    /// <para>Twitch docs: <see href="https://dev.twitch.tv/docs/irc/#rate-limits"/></para>
    /// <para>Default value is <see langword="20"/></para>
    /// </summary>
    public int JoinRateLimit { get; set; } = 20;
    /// <summary>
    /// The amount of outgoing PRIVMSGs allowed in a 30 second period
    /// <para>Twitch docs: <see href="https://dev.twitch.tv/docs/irc/#rate-limits"/></para>
    /// <para>Default value is <see langword="20"/></para>
    /// </summary>
    public int MessageRateLimit { get; set; } = 20;
    /// <summary>
    /// The amount of outgoing PRIVMSGs in moderated channels allowed in a 30 second period
    /// <para>Twitch docs: <see href="https://dev.twitch.tv/docs/irc/#rate-limits"/></para>
    /// <para>Note: Adding <see cref="IgnoreCommand.USERSTATE"/> to <see cref="IgnoreCommands"/> makes this obsolete</para>
    /// <para>Default value is <see langword="100"/></para>
    /// </summary>
    public int ModMessageRateLimit { get; set; } = 100;
    /// <summary>
    /// Applies <see cref="MessageRateLimit"/> and <see cref="ModMessageRateLimit"/> globally instead of per channel
    /// <para>Relevant issue: <see href="https://git.kotmisia.pl/Mm2PL/docs/issues/12"/></para>
    /// <para>Default value is <see langword="true"/></para>
    /// </summary>
    public bool UseGlobalRateLimit { get; set; } = true;
    /// <summary>
    /// The time to wait before trying to reconnect
    /// <para>Default value is <see langword="30"/> seconds</para>
    /// </summary>
    public TimeSpan ReconnectionDelay { get; set; } = TimeSpan.FromSeconds(30);
}