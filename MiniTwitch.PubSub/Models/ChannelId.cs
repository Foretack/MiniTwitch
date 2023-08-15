namespace MiniTwitch.PubSub.Models;

/// <summary>
/// A strongly typed object for a channel's ID
/// <para>Note: This object can be implicitly converted to <see cref="long"/> (returns <see cref="Value"/>)</para>
/// </summary>
public readonly struct ChannelId
{
    /// <summary>
    /// The channel ID
    /// </summary>
    public readonly long Value;

    internal ChannelId(long id)
    {
        Value = id;
    }

    /// <inheritdoc/>
    public override string ToString() => Value.ToString();
    /// <inheritdoc/>
    public static implicit operator ChannelId(long id) => new(id);
    /// <inheritdoc/>
    public static implicit operator long(ChannelId id) => id.Value;
}
