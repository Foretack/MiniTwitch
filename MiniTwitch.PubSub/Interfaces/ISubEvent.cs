using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface ISubEvent
{
    string Username { get; }
    string DisplayName { get; }
    string ChannelName { get; }
    long ChannelId { get; }
    long UserId { get; }
    DateTime Time { get; }
    string SubPlan { get; }
    string SubPlanName { get; }
    int CumulativeMonths { get; }
    int StreakMonths { get; }
    string Context { get; }
    bool IsGift { get; }
    SubMessage SubMessage { get; }
}
