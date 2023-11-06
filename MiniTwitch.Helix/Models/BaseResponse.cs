using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Models;

public abstract class BaseResponse<T>
{
    [JsonPropertyName("data")]
    public required IReadOnlyList<T> Data { get; init; }
}
