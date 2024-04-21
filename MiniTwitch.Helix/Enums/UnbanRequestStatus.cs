using System.Text.Json.Serialization;
using MiniTwitch.Helix.Internal.Json;

namespace MiniTwitch.Helix.Enums;

[JsonConverter(typeof(EnumConverter<UnbanRequestStatus>))]
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
