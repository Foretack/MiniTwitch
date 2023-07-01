using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

public interface IAnonSubGiftEvent
{
    string ChannelName { get; }
    long ChannelId { get; }
    DateTime Time { get; }
    string SubPlan { get; }
    string SubPlanName { get; }
    int Months { get; }
    string Context { get; }
    bool IsGift { get; }
    SubMessage SubMessage { get; }
    long RecipientId { get; }
    string RecipientUsername { get; }
    string RecipientDisplayName { get; }
}
