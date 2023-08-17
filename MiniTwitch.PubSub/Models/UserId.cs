namespace MiniTwitch.PubSub.Models;

/// <summary>
/// A strongly typed object for a user's ID
/// <para>Note: This object can be implicitly converted to <see cref="long"/> (returns <see cref="Value"/>)</para>
/// </summary>
public readonly struct UserId : IEquatable<UserId>, IComparable<UserId>
{
    /// <summary>
    /// The user ID
    /// </summary>
    public readonly long Value;

    internal UserId(long id)
    {
        Value = id;
    }
    /// <inheritdoc/>
    public override string ToString() => Value.ToString();
    /// <inheritdoc/>
    public static implicit operator UserId(long id) => new(id);
    /// <inheritdoc/>
    public static implicit operator long(UserId id) => id.Value;
    /// <inheritdoc/>
    public int CompareTo(UserId other)
    {
        if (this.Value < other.Value)
            return -1;
        if (this.Value > other.Value)
            return 1;

        return 0;
    }
    /// <inheritdoc/>
    public bool Equals(UserId other) => this.Value == other.Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is UserId uid && uid.Value == this.Value;

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Value);
        return hash.ToHashCode();
    }

    /// <inheritdoc/>
    public static bool operator ==(UserId left, UserId right)
    {
        return left.Equals(right);
    }

    /// <inheritdoc/>
    public static bool operator !=(UserId left, UserId right)
    {
        return !(left == right);
    }

    /// <inheritdoc/>
    public static bool operator <(UserId left, UserId right)
    {
        return left.CompareTo(right) < 0;
    }

    /// <inheritdoc/>
    public static bool operator <=(UserId left, UserId right)
    {
        return left.CompareTo(right) <= 0;
    }

    /// <inheritdoc/>
    public static bool operator >(UserId left, UserId right)
    {
        return left.CompareTo(right) > 0;
    }

    /// <inheritdoc/>
    public static bool operator >=(UserId left, UserId right)
    {
        return left.CompareTo(right) >= 0;
    }
}
