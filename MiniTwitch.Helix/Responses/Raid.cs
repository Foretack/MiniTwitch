using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Raid : SingleResponse<Raid.Info>
{
    public record Info(
        [property: JsonPropertyName("created_at")] DateTime CreatedAt,
        [property: JsonPropertyName("is_mature")] bool IsMature
    );
}