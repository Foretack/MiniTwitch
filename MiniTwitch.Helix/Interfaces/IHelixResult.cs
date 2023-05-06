using System.Net;

namespace MiniTwitch.Helix.Interfaces;

public interface IHelixResult
{
    HttpStatusCode StatusCode { get; }
    string Message { get; }
    long ElapsedMs { get; }
    bool Success { get; }
}
