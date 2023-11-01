using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Commercial : SingleResponse<Commercial.Info>
{
    public record Info(
        [property: JsonPropertyName("length")] int Length,
        [property: JsonPropertyName("message")] string Message,
        [property: JsonPropertyName("retry_after")] int RetryAfter
    );
}