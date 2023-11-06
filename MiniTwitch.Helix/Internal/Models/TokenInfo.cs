using System.Text.Json.Serialization;

namespace MiniTwitch.Helix.Internal.Models;

internal record TokenInfo(
    [property: JsonPropertyName("client_id")] string ClientId,
    [property: JsonPropertyName("login")] string Login,
    [property: JsonPropertyName("scopes")] IReadOnlyList<string> Scopes,
    [property: JsonPropertyName("expires_in")] int ExpiresIn
)
{
    public long ReceivedAt { get; set; }
    public bool IsPermaToken => this.ExpiresIn == 0;
};
