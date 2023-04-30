namespace MiniTwitch.Irc.Models;

/// <inheritdoc/>
public sealed class MissingCredentialsException : Exception
{
    /// <inheritdoc/>
    public MissingCredentialsException() : base() { }
    /// <inheritdoc/>
    public MissingCredentialsException(string message) : base(message) { }
}