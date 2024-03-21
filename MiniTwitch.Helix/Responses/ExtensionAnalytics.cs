using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ExtensionAnalytics : PaginableResponse<ExtensionAnalytics.Analytics>
{
    public record Analytics(
        string ExtensionId,
        [property: JsonPropertyName("URL")] string Url,
        string Type,
        DateRange DateRange
    );
    public record DateRange(
        DateTime StartedAt,
        DateTime EndedAt
    );
}