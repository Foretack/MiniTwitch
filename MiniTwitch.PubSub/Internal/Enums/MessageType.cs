namespace MiniTwitch.PubSub.Internal.Enums;

internal enum MessageType
{
    None = 0,
    PING = 80 + 73 + 78 + 71,
    PONG = 80 + 79 + 78 + 71,
    RECONNECT = 82 + 69 + 67 + 79 + 78 + 78 + 69 + 67 + 84,
    RESPONSE = 82 + 69 + 83 + 80 + 79 + 78 + 83 + 69,
    MESSAGE = 77 + 69 + 83 + 83 + 65 + 71 + 69,
}
