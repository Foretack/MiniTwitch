using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class CreateClip : BaseResponse<CreateClip.Clip>
{
   public record Clip(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("edit_url")] string EditUrl
   );
}