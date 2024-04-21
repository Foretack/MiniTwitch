namespace MiniTwitch.Helix.Enums;

public enum UnbanRequestStatus
{
    /// <summary>
    /// This is only for responses from Helix. Do not use it for requests.
    /// </summary>
    Unknown,
    Pending,
    Approved,
    Denied,
    Acknowledged,
    Canceled,
}
