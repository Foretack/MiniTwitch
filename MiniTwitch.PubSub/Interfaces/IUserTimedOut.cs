namespace MiniTwitch.PubSub.Interfaces;

public interface IUserTimedOut
{
    string CreatedBy { get; }
    long CreatedByUserId { get; }
    DateTime CreatedAt { get; }
    long TargetUserId { get; }
    string TargetUsername { get; }
    bool FromAutomod { get; }
    string Reason { get; }
    TimeSpan Duration { get; }
}
