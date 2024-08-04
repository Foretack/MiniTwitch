using System.Net;
using System.Runtime.CompilerServices;
using MiniTwitch.Helix.Interfaces;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Internal.Models;

namespace MiniTwitch.Helix.Models;

/// <summary>
/// Contains the data about the result of a request to the Twitch Helix API.
/// </summary>
public readonly struct HelixResult : IHelixResult
{
    /// <summary>
    /// Status code of the response
    /// </summary>
    public HttpStatusCode StatusCode { get; init; }
    /// <summary>
    /// Contains a message clarifying the error in the response. Check <see cref="Success"/> before using this value.
    /// </summary>
    public string? Message { get; init; }
    /// <summary>
    /// The amount of time the request took to get a response
    /// </summary>
    public TimeSpan Elapsed { get; init; }
    /// <summary>
    /// Whether the request was successful
    /// </summary>
    public bool Success { get; init; }
    /// <summary>
    /// Ratelimit information about the request
    /// <para>Only applicable if <see cref="Success"/> is <see langword="true"/></para>
    /// </summary>
    public RequestRatelimit Ratelimit { get; init; }
}

/// <summary>
/// Contains the data about the result of a request to the Twitch Helix API.
/// </summary>
public readonly struct HelixResult<TResult> : IHelixResult
{
    /// <summary>
    /// The response's content as <typeparamref name="TResult"/>
    /// <para>This value should only be accessed if <see cref="Success"/> is <see langword="true"/></para>
    /// </summary>
    public TResult Value { get; init; }
    /// <summary>
    /// Status code of the response
    /// </summary>
    public HttpStatusCode StatusCode { get; init; }
    /// <summary>
    /// Contains a message clarifying the error in the response. Check <see cref="Success"/> before using this value.
    /// </summary>
    public string? Message { get; init; }
    /// <summary>
    /// The amount of time the request took to get a response
    /// </summary>
    public TimeSpan Elapsed { get; init; }
    /// <summary>
    /// Whether the request was successful
    /// </summary>
    public bool Success { get; init; }
    /// <summary>
    /// Ratelimit information about the request
    /// <para>Only applicable if <see cref="Success"/> is <see langword="true"/></para>
    /// </summary>
    public RequestRatelimit Ratelimit { get; init; }
    /// <summary>
    /// Whether the request can fetch the next page of content
    /// </summary>
    public bool CanPaginate =>
        this.Success
        && this.Value is IPaginable p
        && p.Pagination.Cursor is { Length: > 0 }
        && this.HelixTask is not null;

    internal HelixTask? HelixTask { get; init; }

    /// <summary>
    /// Fetches the next page of content
    /// <para>The same object is returned if <see cref="CanPaginate"/> is <see langword="false"/></para>
    /// </summary>
    public Task<HelixResult<TResult>> Paginate(CancellationToken cancellationToken = default)
    {
        if (!this.CanPaginate)
            return Task.FromResult(this);

        this.HelixTask!.Value.Request.AddParam(QueryParams.After, ((IPaginable)this.Value!).Pagination.Cursor!);
        return HelixResultFactory.Create<TResult>(
            this.HelixTask.Value.Client,
            this.HelixTask.Value.Request,
            this.HelixTask.Value.Endpoint,
            cancellationToken
        );
    }

    /// <summary>
    /// Fetches the next pages of content and returns them via IAsyncEnumerable
    /// <para>Does nothing if <see cref="CanPaginate"/> is <see langword="false"/></para>
    /// </summary>
    public async IAsyncEnumerable<HelixResult<TResult>> EnumeratePages(
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var result = this;
        while (
            result.CanPaginate &&
            await result.Paginate(cancellationToken) is { Success: true } next
        )
        {
            yield return next;
            result = next;
        }
    }

    /// <summary>
    /// Fetches the next pages of content and returns them via IAsyncEnumerable
    /// <para>Does nothing if <see cref="CanPaginate"/> is <see langword="false"/></para>
    /// </summary>
    /// <param name="limit">The maximum amount of pages to fetch before stopping</param>
    /// <param name="cancellationToken"></param>
    public async IAsyncEnumerable<HelixResult<TResult>> EnumeratePages(
        int limit,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        int page = 0;
        var result = this;
        while (
            page < limit &&
            result.CanPaginate &&
            await result.Paginate(cancellationToken) is { Success: true } next
        )
        {
            yield return next;
            result = next;
            page++;
        }
    }

    public static implicit operator TResult(HelixResult<TResult> result) => result.Value;
}
