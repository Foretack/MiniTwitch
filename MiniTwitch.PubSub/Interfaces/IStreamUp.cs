namespace MiniTwitch.PubSub.Interfaces;

public interface IStreamUp
{
    double ServerTime { get; }
    int PlayDelay { get; }
}
