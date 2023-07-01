namespace MiniTwitch.PubSub.Models;

public readonly struct ChannelId
{
    public readonly long Value;

    internal ChannelId(long id)
    {
        Value = id;
    }

    public override string ToString() => Value.ToString();
    public static implicit operator ChannelId(long id) => new(id);
    public static implicit operator long(ChannelId id) => id.Value;
}
