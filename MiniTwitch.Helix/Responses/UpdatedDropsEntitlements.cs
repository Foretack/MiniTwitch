using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UpdatedDropsEntitlements : BaseResponse<UpdatedDropsEntitlements.Info>
{
    public record Info(
        [property: JsonPropertyName("status")] string Status,
        [property: JsonPropertyName("ids")] IReadOnlyList<string> Ids
    );
}