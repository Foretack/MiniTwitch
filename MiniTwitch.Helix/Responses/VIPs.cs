using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class VIPs : PaginableResponse<VIPs.VIP>
{
    public record VIP(
        [property: JsonPropertyName("user_id")] long Id,
        [property: JsonPropertyName("user_login")] string Name,
        [property: JsonPropertyName("user_name")] string DisplayName
    );
}