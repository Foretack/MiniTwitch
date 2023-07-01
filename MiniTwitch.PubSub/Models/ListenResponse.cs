using MiniTwitch.PubSub.Enums;

namespace MiniTwitch.PubSub.Models;

public readonly struct ListenResponse
{
    public readonly ResponseError Error { get; init; }
    public readonly string TopicKey { get; init; }
    public bool IsSuccess => this.Error == ResponseError.Success;
}
