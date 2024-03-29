﻿namespace MiniTwitch.PubSub.Internal.Enums;

internal enum WaitableEvents
{
    Connected,
    Success,
    ERR_BADMESSAGE,
    ERR_BADAUTH,
    ERR_SERVER,
    ERR_BADTOPIC,
    ERR_TOO_MANY_TOPICS,
    PONG
}
