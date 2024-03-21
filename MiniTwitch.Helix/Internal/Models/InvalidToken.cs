namespace MiniTwitch.Helix.Internal.Models;

public record InvalidToken(
        int Status,
        string Message
    );
