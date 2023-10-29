namespace MiniTwitch.PubSub.Models;

/// <summary>
/// A strongly typed object for a channel's ID
/// <para>Note: This object can be implicitly converted to <see cref="long"/> (returns <see cref="Value"/>)</para>
/// </summary>
public readonly struct ChannelId : IEquatable<ChannelId>, IComparable<ChannelId>
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
    /// <inheritdoc/>
    public int CompareTo(ChannelId other)
    {
        if (this.Value < other.Value)
            return -1;
        if (this.Value > other.Value)
            return 1;

        return 0;
    }
    /// <inheritdoc/>
    public bool Equals(ChannelId other) => this.Value == other.Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is ChannelId uid && uid.Value == this.Value;

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Value);
        return hash.ToHashCode();
    }

    /// <inheritdoc/>
    public static bool operator ==(ChannelId left, ChannelId right)
    {
        return left.Equals(right);
    }

    /// <inheritdoc/>
    public static bool operator !=(ChannelId left, ChannelId right)
    {
        return !(left == right);
    }

    /// <inheritdoc/>
    public static bool operator <(ChannelId left, ChannelId right)
    {
        return left.CompareTo(right) < 0;
    }

    /// <inheritdoc/>
    public static bool operator <=(ChannelId left, ChannelId right)
    {
        return left.CompareTo(right) <= 0;
    }

    /// <inheritdoc/>
    public static bool operator >(ChannelId left, ChannelId right)
    {
        return left.CompareTo(right) > 0;
    }

    /// <inheritdoc/>
    public static bool operator >=(ChannelId left, ChannelId right)
    {
        return left.CompareTo(right) >= 0;
    }
}
