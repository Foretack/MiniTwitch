using MiniTwitch.PubSub.Enums;

namespace MiniTwitch.PubSub.Models;

public readonly struct ListenResponse
{
    public readonly ResponseError Error { get; init; }
    public readonly string TopicString { get; init; }
    public bool IsSuccess => Error == ResponseError.None;
}
