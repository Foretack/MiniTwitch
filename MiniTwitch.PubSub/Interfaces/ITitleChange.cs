namespace MiniTwitch.PubSub.Interfaces;

public interface ITitleChange
{
    string Channel { get; }
    long ChannelId { get; }
    string OldTitle { get; }
    string NewTitle { get; }
}
