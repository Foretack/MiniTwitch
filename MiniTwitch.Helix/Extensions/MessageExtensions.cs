using MiniTwitch.Common.Interaction;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Extensions;

public static class MessageExtensions
{
    public static Task<HelixResult> Delete(
        this IHelixMessageTarget message,
        HelixWrapper wrapper,
        long channelId,
        CancellationToken cancellationToken = default)
    => wrapper.DeleteChatMessages(channelId, message.Id, cancellationToken);

    public static Task<HelixResult> Delete(
        this IHelixMessageTarget message,
        SortedHelixWrapper wrapper,
        long channelId,
        CancellationToken cancellationToken = default)
    => wrapper.All.DeleteChatMessages(channelId, message.Id, cancellationToken);
}
