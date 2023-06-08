namespace MiniTwitch.PubSub.Interfaces;

public interface IBanData
{
    long ChannelId { get; }
    string? Reason { get; }
    long TargetId { get; }
}
