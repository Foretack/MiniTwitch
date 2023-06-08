namespace MiniTwitch.PubSub.Interfaces;

public interface IUnbanData
{
    long ChannelId { get; }
    long TargetId { get; }
}
