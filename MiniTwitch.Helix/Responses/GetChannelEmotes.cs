using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetChannelEmotes : BaseResponse<GetChannelEmotes.Datum>
{
   [JsonPropertyName("template")]
   public string Template { get; init; }

   public record Datum(
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("name")] string Name,
       [property: JsonPropertyName("images")] Images Images,
       [property: JsonPropertyName("tier")] string Tier,
       [property: JsonPropertyName("emote_type")] string EmoteType,
       [property: JsonPropertyName("emote_set_id")] string EmoteSetId,
       [property: JsonPropertyName("format")] IReadOnlyList<string> Formats,
       [property: JsonPropertyName("scale")] IReadOnlyList<string> Scales,
       [property: JsonPropertyName("theme_mode")] IReadOnlyList<string> ThemeModes
   );

   public record Images(
       [property: JsonPropertyName("url_1x")] string Url1x,
       [property: JsonPropertyName("url_2x")] string Url2x,
       [property: JsonPropertyName("url_4x")] string Url4x
   );
}