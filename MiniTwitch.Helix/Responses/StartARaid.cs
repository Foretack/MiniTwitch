using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class StartARaid : SingleResponse<StartARaid.Datum>
{
   public record Datum(
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("is_mature")] bool IsMature
   );
}