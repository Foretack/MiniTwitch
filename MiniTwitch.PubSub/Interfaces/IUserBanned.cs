namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents infromation regarding a user than has been banned
/// </summary>
public interface IUserBanned
{
    /// <summary>
    /// Name of the moderator that banned the user
    /// </summary>
    string CreatedBy { get; }
    /// <summary>
    /// ID of the moderator that banned the user
    /// </summary>
    long CreatedByUserId { get; }
    /// <summary>
    /// Time of ban
    /// </summary>
    DateTime CreatedAt { get; }
    /// <summary>
    /// ID of the banned user
    /// </summary>
    long TargetUserId { get; }
    /// <summary>
    /// Name of the banned user
    /// </summary>
    string TargetUsername { get; }
    /// <summary>
    /// Whether the ban was a result of automod
    /// </summary>
    bool FromAutomod { get; }
    /// <summary>
    /// Reason for the ban
    /// <para><see cref="string.Empty"/> if no reason is given</para>
    /// </summary>
    string Reason { get; }
}
