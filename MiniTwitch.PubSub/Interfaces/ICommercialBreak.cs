namespace MiniTwitch.PubSub.Interfaces;

public interface ICommercialBreak
{
    double ServerTime { get; }
    int Length { get; }
    bool Scheduled { get; }
}
