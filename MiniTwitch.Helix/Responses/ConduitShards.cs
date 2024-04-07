using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class ConduitShards : PaginableResponse<ConduitShards.Shard>
{
    public record Shard(
        string Id,
        [property: JsonConverter(typeof(EnumConverter<ConduitShardStatus>))]
        ConduitShardStatus Status,
        ConduitTransport Transport
    );
}
