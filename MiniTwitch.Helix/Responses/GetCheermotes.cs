using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetCheermotes : BaseResponse<GetCheermotes.Datum>
{
   public record Datum(
       [property: JsonPropertyName("prefix")] string Prefix,
       [property: JsonPropertyName("tiers")] IReadOnlyList<Tier> Tiers,
       [property: JsonPropertyName("type")] string Type,
       [property: JsonPropertyName("order")] int Order,
       [property: JsonPropertyName("last_updated")] DateTime LastUpdated,
       [property: JsonPropertyName("is_charitable")] bool IsCharitable
   );
   public record Tier(
       [property: JsonPropertyName("min_bits")] int MinBits,
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("color")] string Color,
       [property: JsonPropertyName("images")] Images Images,
       [property: JsonPropertyName("can_cheer")] bool CanCheer,
       [property: JsonPropertyName("show_in_bits_card")] bool ShowInBitsCard
   );
   public record Images(
       [property: JsonPropertyName("dark")] ImageSet Dark,
       [property: JsonPropertyName("light")] ImageSet Light
   );
   public record ImageSet(
       [property: JsonPropertyName("animated")] IDictionary<string, string> Animated,
       [property: JsonPropertyName("static")] IDictionary<string, string> Static
   );
}