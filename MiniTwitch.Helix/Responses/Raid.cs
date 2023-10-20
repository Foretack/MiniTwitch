using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class Raid : SingleResponse<Raid.Info>
{
   public record Info(
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("is_mature")] bool IsMature
   );
}