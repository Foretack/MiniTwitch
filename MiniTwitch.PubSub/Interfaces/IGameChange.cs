namespace MiniTwitch.PubSub.Interfaces;

public interface IGameChange
{
    string Channel { get; }
    long ChannelId { get; }
    string OldGame { get; }
    string NewGame { get; }
    long OldGameId { get; }
    long NewGameId { get; }
}
