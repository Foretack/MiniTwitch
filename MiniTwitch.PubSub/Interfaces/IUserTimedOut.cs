namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents infromation regarding a user than has been timed out
/// </summary>
public interface IUserTimedOut
{
    /// <summary>
    /// Name of the moderator that timed out the user
    /// </summary>
    string CreatedBy { get; }
    /// <summary>
    /// ID of the moderator that timed out the user
    /// </summary>
    long CreatedByUserId { get; }
    /// <summary>
    /// Time of timeout action
    /// </summary>
    DateTime CreatedAt { get; }
    /// <summary>
    /// ID of the timed-out user
    /// </summary>
    long TargetUserId { get; }
    /// <summary>
    /// Name of the timed-out user
    /// </summary>
    string TargetUsername { get; }
    /// <summary>
    /// Whether the timeout was a result of automod
    /// </summary>
    bool FromAutomod { get; }
    /// <summary>
    /// Reason for the timeout
    /// <para><see cref="string.Empty"/> if no reason is given</para>
    /// </summary>
    string Reason { get; }
    /// <summary>
    /// Timeout duration
    /// </summary>
    TimeSpan Duration { get; }
}
