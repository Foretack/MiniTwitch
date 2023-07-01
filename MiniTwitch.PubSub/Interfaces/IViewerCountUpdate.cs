namespace MiniTwitch.PubSub.Interfaces;

public interface IViewerCountUpdate
{
    double ServerTime { get; }
    int Viewers { get; }
}
