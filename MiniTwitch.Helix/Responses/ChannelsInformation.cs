using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ChannelsInformation : BaseResponse<ChannelsInformation.Information>
{
    public record Information(
        long Id,
        [property: JsonPropertyName("broadcaster_login")] string Name,
        [property: JsonPropertyName("broadcaster_name")] string DisplayName,
        string Language,
        string GameName,
        string GameId,
        string Title,
        int Delay,
        IReadOnlyList<string> Tags,
        IReadOnlyList<ContentLabelId> ContentClassificationLabels,
        bool IsBrandedContent
    );
}