using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a suspicious chat message
/// </summary>
public interface ILowTrustTreatmentMessage
{
    /// <summary>
    /// An ID for the suspicious user entry, which is a combination of the channel ID where the treatment was updated and the user ID of the suspicious user
    /// </summary>
    string LowTrustId { get; }
    /// <summary>
    /// ID of the channel where the suspicious user was present
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// Information about the moderator who made any update for the suspicious user
    /// </summary>
    LowTrustUser.UserInfo UpdatedBy { get; }
    /// <summary>
    /// Timestamp of when the treatment was updated for the suspicious user
    /// </summary>
    DateTime UpdatedAt { get; }
    /// <summary>
    /// User ID of the suspicious user
    /// </summary>
    long TargetUserId { get; }
    /// <summary>
    /// Name of the suspicious user
    /// </summary>
    string TargetUser { get; }
    /// <summary>
    /// The treatment set for the suspicious user, can be “NO_TREATMENT”, “ACTIVE_MONITORING”, or “RESTRICTED”
    /// </summary>
    string Treatment { get; }
    /// <summary>
    /// User types (if any) that apply to the suspicious user, can be “UNKNOWN_TYPE”, “MANUALLY_ADDED”, “DETECTED_BAN_EVADER”, or “BANNED_IN_SHARED_CHANNEL”
    /// </summary>
    string[] Types { get; }
    /// <summary>
    /// A ban evasion likelihood value (if any) that as been applied to the user automatically by Twitch, can be “UNKNOWN_EVADER”, “UNLIKELY_EVADER”, “LIKELY_EVADER”, or “POSSIBLE_EVADER”
    /// </summary>
    string BanEvasionEvaluation { get; }
    /// <summary>
    /// Timestamp for the first time the suspicious user was automatically evaluated by Twitch.
    /// </summary>
    DateTime EvaluatedAt { get; }
}
