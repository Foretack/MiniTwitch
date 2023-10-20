using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Interfaces;

namespace MiniTwitch.Helix.Responses;

public class BlockedTerms : PaginableResponse<BlockedTerms.Term>
{
   public record Term(
       [property: JsonPropertyName("broadcaster_id")] long BroadcasterId,
       [property: JsonPropertyName("moderator_id")] long ModeratorId,
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("text")] string Text,
       [property: JsonPropertyName("created_at")] DateTime CreatedAt,
       [property: JsonPropertyName("updated_at")] DateTime? UpdatedAt,
       [property: JsonPropertyName("expires_at")] DateTime? ExpiresAt
   );
}