using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetChannelEditors : BaseResponse<GetChannelEditors.Datum>
{
   public record Datum(
       [property: JsonPropertyName("user_id")] long Id,
       [property: JsonPropertyName("user_name")] string DisplayName,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt
   );
}