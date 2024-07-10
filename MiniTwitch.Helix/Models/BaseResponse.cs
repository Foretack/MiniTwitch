namespace MiniTwitch.Helix.Models;

public interface IBaseResponse
{
    public string? Error { get; init; }

    public string? Message { get; init; }
}

public abstract class BaseResponse : IBaseResponse
{
    public string? Error { get; init; }

    public string? Message { get; init; }
}

public abstract class BaseResponse<T> : IBaseResponse
{
    public IReadOnlyList<T> Data { get; init; }

    public string? Error { get; init; }

    public string? Message { get; init; }
}
