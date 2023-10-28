using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class UsersCategory
{
    private readonly AllCategories _all;

    internal UsersCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<User>> GetUsers(
        long? id = null,
        string? login = null,
        CancellationToken cancellationToken = default)
    => _all.GetUsers(id, login, cancellationToken);

    public Task<HelixResult<Users>> GetUsers(
        IEnumerable<long>? id = null,
        IEnumerable<string>? login = null,
        CancellationToken cancellationToken = default)
    => _all.GetUsers(id, login, cancellationToken);

    public Task<HelixResult<UpdatedUser>> UpdateUser(
        string? description = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateUser(description, cancellationToken);

    public Task<HelixResult> BlockUser(
        long targetUserId,
        string? sourceContext = null,
        string? reason = null,
        CancellationToken cancellationToken = default)
    => _all.BlockUser(targetUserId, sourceContext, reason, cancellationToken);

    public Task<HelixResult> UnblockUser(
        long targetUserId,
        CancellationToken cancellationToken = default)
    => _all.UnblockUser(targetUserId, cancellationToken);

    public Task<HelixResult<BlockList>> GetUserBlockList(
        long broadcasterId,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetUserBlockList(broadcasterId, first, cancellationToken);

    public Task<HelixResult<UserExtensions>> GetUserExtensions(
        CancellationToken cancellationToken = default)
    => _all.GetUserExtensions(cancellationToken);

    public Task<HelixResult<ActiveExtensions>> GetUserActiveExtensions(
        long? userId = null,
        CancellationToken cancellationToken = default)
    => _all.GetUserActiveExtensions(userId, cancellationToken);
}
