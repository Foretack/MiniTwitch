namespace MiniTwitch.PubSub.Interfaces;

public interface ITimeOutData
{
    long ChannelId { get; }
    DateTime ExpiresAt { get; }
    long ExpiresInMs { get; }
    string? Reason { get; }
    long TargetId { get; }
}
