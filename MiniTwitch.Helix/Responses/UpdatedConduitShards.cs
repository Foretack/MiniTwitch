﻿
using System.Text.Json.Serialization;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Responses;

public class UpdatedConduitShards : BaseResponse<ConduitShard>
{
    public IReadOnlyList<Error> Errors { get; init; }

    // TODO: Move 'code' field to an enum if twitch every documents the error codes
    public record Error(
        [property: JsonPropertyName("id")]
        string ShardId,
        string Message,
        string Code
    );
}