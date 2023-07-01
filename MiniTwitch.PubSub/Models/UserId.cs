namespace MiniTwitch.PubSub.Models;

public readonly struct UserId
{
    public readonly long Value;

    internal UserId(long id)
    {
        Value = id;
    }

    public override string ToString() => Value.ToString();
    public static implicit operator UserId(long id) => new(id);
    public static implicit operator long(UserId id) => id.Value;
}
