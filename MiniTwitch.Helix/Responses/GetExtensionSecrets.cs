using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class GetExtensionSecrets : BaseResponse<GetExtensionSecrets.Datum>
{
   public record Datum(
       [property: JsonPropertyName("format_version")] int FormatVersion,
       [property: JsonPropertyName("secrets")] IReadOnlyList<Secret> Secrets
   );

   public record Secret(
       [property: JsonPropertyName("content")] string Content,
       [property: JsonPropertyName("active_at")] DateTime ActiveAt,
       [property: JsonPropertyName("expires_at")] DateTime ExpiresAt
   );
}