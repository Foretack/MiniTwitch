namespace MiniTwitch.PubSub.Interfaces;

public interface IUntimeOutData
{
    long ChannelId { get; }
    long TargetId { get; }
}
