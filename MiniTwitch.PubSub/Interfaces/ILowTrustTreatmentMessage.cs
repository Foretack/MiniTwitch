using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface ILowTrustTreatmentMessage
{
    string LowTrustId { get; }
    long ChannelId { get; }
    LowTrustUser.UserInfo UpdatedBy { get; }
    DateTime UpdatedAt { get; }
    long TargetUserId { get; }
    string TargetUser { get; }
    string Treatment { get; }
    string[] Types { get; }
    string BanEvasionEvaluation { get; }
    DateTime EvaluatedAt { get; }
}
