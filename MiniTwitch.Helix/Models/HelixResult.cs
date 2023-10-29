using System.Net;
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
    /// Contains a message clarifying the meaning of the status code in <see cref="StatusCode"/>
    /// </summary>
    public string Message { get; init; }
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
    /// <para>This value should only be used if <see cref="Success"/> is <see langword="true"/></para>
    /// </summary>
    public TResult Value { get; init; }
    /// <summary>
    /// Status code of the response
    /// </summary>
    public HttpStatusCode StatusCode { get; init; }
    /// <summary>
    /// Contains a message clarifying the meaning of the status code in <see cref="StatusCode"/>
    /// </summary>
    public string Message { get; init; }
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
        this.Value is IPaginable p
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

    public static implicit operator TResult(HelixResult<TResult> result) => result.Value;
}
