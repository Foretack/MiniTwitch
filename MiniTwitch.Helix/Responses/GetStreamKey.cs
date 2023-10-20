using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetStreamKey : SingleResponse<GetStreamKey.Datum>
{
   public record Datum(
       [property: JsonPropertyName("stream_key")] string StreamKey
   );
}