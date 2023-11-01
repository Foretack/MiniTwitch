using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Models;

public abstract class SingleResponse<T>
{
    [JsonPropertyName("data")]
    internal IReadOnlyList<T> I_Data { get; init; }

    [JsonIgnore]
    public T Data => this.I_Data[0];

    [JsonIgnore]
    public bool HasContent => this.I_Data is { Count: > 0 };
}