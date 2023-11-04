using MiniTwitch.Common.Interaction;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Extensions;

public static class ChannelExtensions
{
    public static Task<HelixResult<Clip>> CreateClip(
        this IHelixChannelTarget channel,
        HelixWrapper wrapper,
        bool? hasDelay = null,
        CancellationToken cancellationToken = default)
    => wrapper.CreateClip(channel.Id, hasDelay, cancellationToken);

    public static Task<HelixResult> ClearChat(
        this IHelixChannelTarget channel,
        HelixWrapper wrapper,
        CancellationToken cancellationToken = default)
    => wrapper.DeleteChatMessages(channel.Id, null, cancellationToken);

    public static Task<HelixResult<Moderators>> GetModerators(
        this IHelixChannelTarget channel,
        HelixWrapper wrapper,
        long? userId = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => wrapper.GetModerators(userId, first, cancellationToken);

    public static Task<HelixResult<ChannelTeams>> GetChannelTeams(
        this IHelixChannelTarget channel,
        HelixWrapper wrapper,
        CancellationToken cancellationToken = default)
    => wrapper.GetChannelTeams(channel.Id, cancellationToken);

    public static Task<HelixResult<Commercial>> StartCommercial(
        this IHelixChannelTarget channel,
        HelixWrapper wrapper,
        NewCommercial body,
        CancellationToken cancellationToken = default)
    => wrapper.StartCommercial(body, cancellationToken);
}
