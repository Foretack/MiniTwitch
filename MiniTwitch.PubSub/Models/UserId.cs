namespace MiniTwitch.PubSub.Models;

/// <summary>
/// A strongly typed object for a user's ID
/// <para>Note: This object can be implicitly converted to <see cref="long"/> (returns <see cref="Value"/>)</para>
/// </summary>
public readonly struct UserId
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
}
