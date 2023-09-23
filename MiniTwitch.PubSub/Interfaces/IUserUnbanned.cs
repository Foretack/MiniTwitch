namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents infromation regarding a user than has been unbanned
/// </summary>
public interface IUserUnbanned
{
    /// <summary>
    /// Name of the moderator that unbanned the user
    /// </summary>
    string CreatedBy { get; }
    /// <summary>
    /// ID of the moderator that unbanned the user
    /// </summary>
    long CreatedByUserId { get; }
    /// <summary>
    /// Time of unban
    /// </summary>
    DateTime CreatedAt { get; }
    /// <summary>
    /// ID of the unbanned user
    /// </summary>
    long TargetUserId { get; }
    /// <summary>
    /// Name of the unbanned user
    /// </summary>
    string TargetUsername { get; }
}
