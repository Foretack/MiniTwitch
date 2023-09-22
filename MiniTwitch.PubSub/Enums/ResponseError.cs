namespace MiniTwitch.PubSub.Enums;

/// <summary>
/// Represents possible response errors received when listening to a topic
/// </summary>
public enum ResponseError
{
    /// <summary>
    /// Default value. This is only a fallback value, it does not indicate anything
    /// </summary>
    None,
    /// <summary>
    /// Indicates that the topic was listened to successfully
    /// </summary>
    Success,
    /// <summary>
    /// Indicates that the listen message was invalid
    /// </summary>
    ERR_BADMESSAGE,
    /// <summary>
    /// Indicates that the provided token does not have the permission to listen to the desired topic
    /// </summary>
    ERR_BADAUTH,
    /// <summary>
    /// Indicates that a server error has a occurred
    /// </summary>
    ERR_SERVER,
    /// <summary>
    /// Indicates that the desired topic does not exist
    /// </summary>
    ERR_BADTOPIC,
    /// <summary>
    /// Received when trying to listen to more topics than the maximum amount (100)
    /// </summary>
    ERR_TOO_MANY_TOPICS,
    /// <summary>
    /// Received when Twitch fails to respond to the message within the allowed time
    /// </summary>
    Response_Timeout,
}
