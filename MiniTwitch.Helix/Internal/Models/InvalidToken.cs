using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Internal.Models;

public record InvalidToken(
        [property: JsonPropertyName("status")] int Status,
        [property: JsonPropertyName("message")] string Message
    );
