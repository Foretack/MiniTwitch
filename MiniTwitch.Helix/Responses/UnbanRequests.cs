using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;
public class UnbanRequests : PaginableResponse<UnbanRequests.Request>
{
    public record Request(
        string Id,
        long BroadcasterId,
        [property: JsonPropertyName("broadcaster_login")]
        string BroadcasterName,
        [property: JsonPropertyName("broadcaster_name")]
        string BroadcasterDisplayName,
        [property: JsonConverter(typeof(OptionalLongConverter))]
        long? ModeratorId,
        [property: JsonPropertyName("moderator_login")]
        string? ModeratorName,
        [property: JsonPropertyName("moderator_name")]
        string? ModeratorDisplayName,
        long UserId,
        [property: JsonPropertyName("user_login")]
        string UserName,
        [property: JsonPropertyName("user_name")]
        string UserDisplayName,
        string Text,
        //[property: JsonConverter(typeof(EnumConverter<UnbanRequestStatus>))]
        UnbanRequestStatus Status,
        DateTime CreatedAt,
        DateTime? ResolvedAt,
        string? ResolutionText
    );
}
