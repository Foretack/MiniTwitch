using System.Text.Json.Serialization;
using MiniTwitch.Helix.Enums;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Responses;

public record ConduitShard(
    string Id,
    [property: JsonConverter(typeof(EnumConverter<ConduitShardStatus>))]
    ConduitShardStatus Status,
    ConduitTransport Transport
);

