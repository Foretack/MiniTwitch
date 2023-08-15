using MiniTwitch.PubSub.Enums;

namespace MiniTwitch.PubSub.Models;

/// <summary>
/// Response received from Twitch for listen/unlisten messages
/// </summary>
public readonly struct ListenResponse
{
    /// <summary>
    /// The response's error
    /// <para>If the listen/unlisten was successful, the value is <see cref="ResponseError.Success"/></para>
    /// </summary>
    public readonly ResponseError Error { get; init; }
    /// <summary>
    /// The topic sent in the listen/unlisten message
    /// <para>Listen string: "0:TOPIC"</para>
    /// <para>Unlisten string: "1:TOPIC"</para>
    /// </summary>
    public readonly string TopicKey { get; init; }
    /// <summary>
    /// Whether the response indicates success
    /// </summary>
    public bool IsSuccess => this.Error == ResponseError.Success;
}
