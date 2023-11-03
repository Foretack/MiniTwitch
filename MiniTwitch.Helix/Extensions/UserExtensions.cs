using MiniTwitch.Common.Interaction;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Extensions;

public static class UserExtensions
{
    public static Task<HelixResult> Block(
        this IHelixUserTarget target,
        HelixWrapper wrapper,
        string? sourceContext = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    => wrapper.BlockUser(target.Id, sourceContext, reason, cancellationToken);

    public static Task<HelixResult> Unblock(
        this IHelixUserTarget target,
        HelixWrapper wrapper,
        CancellationToken cancellationToken = default)
    => wrapper.UnblockUser(target.Id, cancellationToken);

    public static Task<HelixResult<Users>> GetInfo(
        this IHelixUserTarget target,
        HelixWrapper wrapper,
        CancellationToken cancellationToken = default)
    => wrapper.GetUsers(target.Id, cancellationToken: cancellationToken);

    public static Task<HelixResult<BannedUser>> Ban(
        this IHelixUserTarget target,
        HelixWrapper wrapper,
        long channelId,
        TimeSpan? duration = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    => wrapper.BanUser(channelId, new() { Data = new() { UserId = target.Id, Duration = duration, Reason = reason! } }, cancellationToken);

    public static Task<HelixResult> Unban(
        this IHelixUserTarget target,
        HelixWrapper wrapper,
        long channelId,
        CancellationToken cancellationToken = default)
    => wrapper.UnbanUser(channelId, target.Id, cancellationToken);

    public static Task<HelixResult> SendWhisper(
        this IHelixUserTarget target,
        HelixWrapper wrapper,
        string message,
        CancellationToken cancellationToken = default)
    => wrapper.SendWhisper(target.Id, message, cancellationToken);

    public static Task<HelixResult> Block(
        this IHelixUserTarget target,
        SortedHelixWrapper wrapper,
        string? sourceContext = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    => wrapper.All.BlockUser(target.Id, sourceContext, reason, cancellationToken);

    public static Task<HelixResult> Unblock(
        this IHelixUserTarget target,
        SortedHelixWrapper wrapper,
        CancellationToken cancellationToken = default)
    => wrapper.All.UnblockUser(target.Id, cancellationToken);

    public static Task<HelixResult<Users>> GetInfo(
        this IHelixUserTarget target,
        SortedHelixWrapper wrapper,
        CancellationToken cancellationToken = default)
    => wrapper.All.GetUsers(target.Id, cancellationToken: cancellationToken);

    public static Task<HelixResult<BannedUser>> Ban(
        this IHelixUserTarget target,
        SortedHelixWrapper wrapper,
        long channelId,
        TimeSpan? duration = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    => wrapper.All.BanUser(channelId, new() { Data = new() { UserId = target.Id, Duration = duration, Reason = reason! } }, cancellationToken);

    public static Task<HelixResult> Unban(
        this IHelixUserTarget target,
        SortedHelixWrapper wrapper,
        long channelId,
        CancellationToken cancellationToken = default)
    => wrapper.All.UnbanUser(channelId, target.Id, cancellationToken);

    public static Task<HelixResult> SendWhisper(
        this IHelixUserTarget target,
        SortedHelixWrapper wrapper,
        string message,
        CancellationToken cancellationToken = default)
    => wrapper.All.SendWhisper(target.Id, message, cancellationToken);
}
