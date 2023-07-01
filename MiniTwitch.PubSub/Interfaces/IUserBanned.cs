namespace MiniTwitch.PubSub.Interfaces;

public interface IUserBanned
{
    string CreatedBy { get; }
    long CreatedByUserId { get; }
    DateTime CreatedAt { get; }
    long TargetUserId { get; }
    string TargetUsername { get; }
    bool FromAutomod { get; }
    string Reason { get; }
}
