using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class BlockedTerms : PaginableResponse<BlockedTerms.Term>
{
    public record Term(
         long BroadcasterId,
         long ModeratorId,
         string Id,
         string Text,
         DateTime CreatedAt,
         DateTime? UpdatedAt,
         DateTime? ExpiresAt
    );
}