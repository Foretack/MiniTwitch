using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class ChatMessage
{
    [JsonConverter(typeof(LongConverter))]
    public required long BroadcasterId { get; init; }
    public required string Message { get; init; }
    public string? ReplyParentMessageId { get; init; } = null;
    /// <summary>
    /// This value is assigned automatically
    /// </summary>
    public long SenderId { get; internal set; }
}