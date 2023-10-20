using System.Net;
using MiniTwitch.Helix.Interfaces;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Internal.Models;

namespace MiniTwitch.Helix.Models;

public readonly struct HelixResult : IHelixResult
{
    public HttpStatusCode StatusCode { get; init; }
    public string Message { get; init; }
    public TimeSpan Elapsed { get; init; }
    public bool Success { get; init; }
}

public readonly struct HelixResult<TResult> : IHelixResult
{
    public TResult Value { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public string Message { get; init; }
    public TimeSpan Elapsed { get; init; }
    public bool Success { get; init; }
    public bool CanPaginate =>
        this.Value is IPaginable p
        && p.Pagination.Cursor is { Length: > 0 }
        && this.HelixTask is not null;

    internal HelixTask? HelixTask { get; init; }

    public Task<HelixResult<TResult>> Paginate(CancellationToken cancellationToken = default)
    {
        if (!this.CanPaginate)
            return Task.FromResult(this);

        this.HelixTask!.Value.Request.AddParam(QueryParams.First, ((IPaginable)this.Value!).Pagination.Cursor!);
        return HelixResultFactory.Create<TResult>(
            this.HelixTask.Value.Client,
            this.HelixTask.Value.Request,
            this.HelixTask.Value.Endpoint,
            cancellationToken
        );
    }

    public static implicit operator TResult(HelixResult<TResult> result) => result.Value;
}
