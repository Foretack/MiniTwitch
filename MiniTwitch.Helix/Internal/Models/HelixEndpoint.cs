using System.Net;

namespace MiniTwitch.Helix.Internal.Models;

internal class HelixEndpoint
{
    public HttpMethod Method { get; init; } = default!;
    public string Route { get; init; } = default!;
    public HttpStatusCode SuccessStatusCode { get; init; } = HttpStatusCode.OK;
    public Func<HttpStatusCode, string> GetResponseMessage { get; init; } = default!;
}
