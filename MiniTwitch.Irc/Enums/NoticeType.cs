namespace MiniTwitch.Irc.Enums;

/// <summary>
/// Represents various types of notices that can be received from Twitch
/// </summary>
public enum NoticeType
{
    /// <summary>
    /// The default enum value for a notice
    /// </summary>
    Unknown,
    /// <summary>
    /// Indicates that "Emote Only" mode has been enabled.
    /// </summary>
    Emote_only_on,
    /// <summary>
    /// Indicates that "Emote Only" mode has been disabled.
    /// </summary>
    Emote_only_off,
    /// <summary>
    /// Indicates that "Followers Only" mode has been enabled.
    /// <para>Note: Unlike <see cref="Followers_on_zero"/>, this notice is given when a user needs to be following for X amount of minutes</para>
    /// </summary>
    Followers_on,
    /// <summary>
    /// Indicates that "Followers Only" mode has been enabled.
    /// </summary>
    Followers_on_zero,
    /// <summary>
    /// Indicates that "Followers Only" mode has been disabled.
    /// </summary>
    Followers_off,
    /// <summary>
    /// Indicates that "Subs Only" mode has been enabled.
    /// </summary>
    Subs_on,
    /// <summary>
    /// Indicates that "Subs Only" mode has been disabled.
    /// </summary>
    Subs_off,
    /// <summary>
    /// Indicates that "Unique" mode has been enabled.
    /// </summary>
    R9K_on,
    /// <summary>
    /// Indicates that "Unique" mode has been disabled.
    /// </summary>
    R9K_off,
    /// <summary>
    /// Indicates that "Slow" mode has been enabled.
    /// </summary>
    Slow_on,
    /// <summary>
    /// Indicates that "Slow" mode has been disabled.
    /// </summary>
    Slow_off,
    /// <summary>
    /// The response to a "/help" message.
    /// </summary>
    Cmds_available,
    /// <summary>
    /// Indicates that you have tried joining a suspended channel.
    /// </summary>
    Msg_channel_suspended,
    /// <summary>
    /// Indicates that you have tried sending a duplicate message.
    /// <para>"Your message is identical to the one you sent within the last 30 seconds."</para>
    /// </summary>
    Msg_duplicate,
    /// <summary>
    /// Indicates that "Emote Only" mode has been enabled.
    /// </summary>
    Msg_emoteonly,
    /// <summary>
    /// Indicates that your message was not sent due to "Followers Only" mode restrictions.
    /// </summary>
    Msg_followersonly_zero,
    /// <summary>
    /// Indicates that your message was not sent due to "Followers Only" mode restrictions.
    /// </summary>
    Msg_followersonly,
    /// <summary>
    /// Indicates that your message was not sent because it conflicts with the channel's moderation settings.
    /// </summary>
    Msg_rejected_mandatory,
    /// <summary>
    /// Indicates that you tried sending a non-unique message in "Unique" mode.
    /// </summary>
    Msg_R9K,
    /// <summary>
    /// Indicates that you have not waited long enough between your messages to comply with "Slow" mode
    /// </summary>
    Msg_slowmode,
    /// <summary>
    /// Indicates that your message was not sent due to "Subs Only" mode restrictions.
    /// </summary>
    Msg_subsonly,
    /// <summary>
    /// Indicates that your message was not sent because you are timed out.
    /// </summary>
    Msg_timedout,
    /// <summary>
    /// Indicates that you have been banned from the channel.
    /// </summary>
    Msg_banned,
    /// <summary>
    /// Indicates that your message was not sent because the channel requires verification through a phone number.
    /// </summary>
    Msg_requires_verified_phone_number,
    /// <summary>
    /// Indicates that your message was not sent because you are sending messages too quickly.
    /// </summary>
    Msg_ratelimit,
    /// <summary>
    /// Indicates that your account has been suspended.
    /// </summary>
    Msg_suspended,
    /// <summary>
    /// Indicates that your message was not sent because the channel requires verification through an email.
    /// </summary>
    Msg_verified_email,
    /// <summary>
    /// Indicates that you tried using a command that you have no permission for.
    /// </summary>
    No_permission,
    /// <summary>
    /// Indicates that you tried using a command that is not available through 3rd party clients.
    /// </summary>
    Unavailable_command,
    /// <summary>
    /// Indicates that you tried using a command that does not exist
    /// </summary>
    Unrecognized_cmd,
    /// <summary>
    /// Indicates that your authentication process was unsuccessful
    /// </summary>
    Bad_auth,
    /// <summary>
    /// Indicates that you tried to reply to a message that cannot be replied to
    /// </summary>
    Invalid_parent,
    /// <summary>
    /// Indicates that you received a warning that must be acknowledged in a browser
    /// </summary>
    Msg_warned,
}
