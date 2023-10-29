using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Internal.Models;

internal readonly struct ResponsePayload
{
    [JsonPropertyName("nonce")]
    public string Nonce { get; init; }
    [JsonPropertyName("error")]
    public string Error { get; init; }
}
