namespace MiniTwitch.PubSub.Internal.Enums;

internal enum MessageType
{
    None = 0,
    PONG = 308,
    MESSAGE = 517,
    RESPONSE = 623,
    RECONNECT = 673,
}
