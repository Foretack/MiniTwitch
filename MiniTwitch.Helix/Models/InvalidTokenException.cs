namespace MiniTwitch.Helix.Models;

public class InvalidTokenException : Exception
{
    public string? TokenMessage { get; init; }

    internal InvalidTokenException(string? tokenMessage, string? message) : base(message)
    {
        this.TokenMessage = tokenMessage;
    }
}
