using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about an anonymous giftsub
/// </summary>
public interface IAnonSubGiftEvent
{
    /// <summary>
    /// Name of the channel where the gift was sent
    /// </summary>
    string ChannelName { get; }
    /// <summary>
    /// ID of the channel where the gift was sent
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// The time when the gift was sent
    /// </summary>
    DateTime Time { get; }
    /// <summary>
    /// The tier of the gift subscription
    /// <para>Possible values: </para>
    /// <list type="bullet">
    /// <item>Prime — Amazon Prime subscription</item>
    /// <item>1000 — First level of paid subscription</item>
    /// <item>2000 — Second level of paid subscription</item>
    /// <item>3000 — Third level of paid subscription</item>
    /// </list>
    /// </summary>
    string SubPlan { get; }
    /// <summary>
    /// Name of the subscription plan
    /// <para>Example 1: Channel Subscription (mandeow)</para>
    /// <para>Example 2: Channel Subscription (forsenlol)</para>
    /// </summary>
    string SubPlanName { get; }
    /// <summary>
    /// Cumulative number of tenure months of the subscription
    /// </summary>
    int Months { get; }
    /// <summary>
    /// Event type associated with the subscription product, values: <c>sub</c>, <c>resub</c>, <c>subgift</c>, <c>anonsubgift</c>, <c>resubgift</c>, <c>anonresubgift</c>
    /// </summary>
    string Context { get; }
    /// <summary>
    /// If this sub message was caused by a gift subscription (?)
    /// </summary>
    bool IsGift { get; }
    /// <summary>
    /// The body of the user-entered resub message
    /// </summary>
    SubscribeEvents.SubMessageData SubMessage { get; }
    /// <summary>
    /// User ID of the subscription gift recipient
    /// </summary>
    long RecipientId { get; }
    /// <summary>
    /// Login name of the subscription gift recipient
    /// </summary>
    string RecipientUsername { get; }
    /// <summary>
    /// Display name of the person who received the subscription gift
    /// </summary>
    string RecipientDisplayName { get; }
}
