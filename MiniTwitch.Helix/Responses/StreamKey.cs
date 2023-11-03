using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class StreamKey : BaseResponse<StreamKey.Info>
{
    public record Info(
        [property: JsonPropertyName("stream_key")] string StreamKey
    );
}