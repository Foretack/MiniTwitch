namespace MiniTwitch.PubSub.Enums;

public enum ResponseError
{
    None,
    Unknown,
    ERR_BADMESSAGE,
    ERR_BADAUTH,
    ERR_SERVER,
    ERR_BADTOPIC
}
