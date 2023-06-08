namespace MiniTwitch.PubSub.Interfaces;

public interface IAliasRestrictedUpdate
{
    bool UserIsRestricted { get; }
    long ChannelId2 { get; }
}
