using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class Clip : SingleResponse<Clip.Info>
{
   public record Info(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("edit_url")] string EditUrl
   );
}