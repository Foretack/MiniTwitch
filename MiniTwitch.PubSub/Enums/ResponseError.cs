namespace MiniTwitch.PubSub.Enums;

public enum ResponseError
{
    None,
    Success,
    ERR_BADMESSAGE,
    ERR_BADAUTH,
    ERR_SERVER,
    ERR_BADTOPIC,
    Response_Timeout,
}
