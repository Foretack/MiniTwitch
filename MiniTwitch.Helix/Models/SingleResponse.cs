using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Models;

#pragma warning disable CS8618
public abstract class SingleResponse<T>
{
    [JsonPropertyName("data")]
    internal IReadOnlyList<T> I_Data { get; init; }
    [JsonIgnore]
    public T Data => I_Data[0];
}
#pragma warning restore CS8618
