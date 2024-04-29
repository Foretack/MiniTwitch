using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Requests;

public class ChatMessage
{
    [JsonConverter(typeof(LongConverter))]
    public long BroadcasterId { get; }
    public string Message { get; }
    public string? ReplyParentMessageId { get; }
    /// <summary>
    /// This value is assigned automatically
    /// </summary>
    public long SenderId { get; internal set; }

    public ChatMessage(long broadcasterId, string message, string? replyParentMessageId = null)
    {
        this.BroadcasterId = broadcasterId;
        this.Message = message;
        this.ReplyParentMessageId = replyParentMessageId;
    }
}