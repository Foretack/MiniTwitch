namespace MiniTwitch.Helix.Internal.Models;

internal readonly struct HelixTask
{
    internal HelixEndpoint Endpoint { get; init; }
    internal RequestData Request { get; init; }
    internal HelixApiClient Client { get; init; }
}
