namespace MiniTwitch.Irc.Internal.Enums;
internal enum IrcCommand
{
    [Obsolete("Unused")] Connected_host = 146,
    [Obsolete("Unused")] Connected_motd = 147,
    [Obsolete("Unused")] Connected_useless = 148,
    [Obsolete("Unused")] NamesList = 155,
    [Obsolete("Unused")] Connected_useless_motd = 156,
    [Obsolete("Unused")] Connected_useless2_or_NamesListEnd_who_cares = 159,
    [Obsolete("Unused")] Connected_end_of_bullshit = 160,

    Unknown = 0,
    Connected = 145,
    Capabilities_received = 212,
    PING = 302,
    JOIN = 304,
    PONG = 308,
    PART = 311,
    NOTICE = 450,
    WHISPER = 546,
    PRIVMSG = 552,
    CLEARMSG = 590,
    CLEARCHAT = 647,
    RECONNECT = 673,
    ROOMSTATE = 702,
    USERSTATE = 704,
    USERNOTICE = 769,
    GLOBALUSERSTATE = 1137
}
