namespace MiniTwitch.Helix.Internal.Models;

internal record TokenInfo(
    string ClientId,
    string Login,
    IReadOnlyList<string> Scopes,
    int ExpiresIn
)
{
    public long ReceivedAt { get; set; }
    public bool IsPermaToken => this.ExpiresIn == 0;
};
