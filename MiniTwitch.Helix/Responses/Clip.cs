using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class Clip : BaseResponse<Clip.Info>
{
    public record Info(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("edit_url")] string EditUrl
    );
}