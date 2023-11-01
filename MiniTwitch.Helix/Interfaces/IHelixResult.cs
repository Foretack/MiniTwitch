using System.Net;

namespace MiniTwitch.Helix.Interfaces;

public interface IHelixResult
{
    HttpStatusCode StatusCode { get; }
    string Message { get; }
    TimeSpan Elapsed { get; }
    bool Success { get; }
}
