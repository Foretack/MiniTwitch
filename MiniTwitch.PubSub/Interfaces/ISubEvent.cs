using MiniTwitch.PubSub.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents a (re)subscription event
/// </summary>
public interface ISubEvent
{
    /// <summary>
    /// Name of the subscriber
    /// </summary>
    string Username { get; }
    /// <summary>
    /// Display name of the subscriber
    /// </summary>
    string DisplayName { get; }
    /// <summary>
    /// Name of the subscribed-to channel
    /// </summary>
    string ChannelName { get; }
    /// <summary>
    /// ID of the subscribed-to channel
    /// </summary>
    long ChannelId { get; }
    /// <summary>
    /// ID of the subscriber
    /// </summary>
    long UserId { get; }
    /// <summary>
    /// Time when the event occured
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
    int CumulativeMonths { get; }
    /// <summary>
    /// Denotes the user’s most recent (and contiguous) subscription tenure streak in the channel
    /// </summary>
    int StreakMonths { get; }
    /// <summary>
    /// Event type associated with the subscription product, values: <c>sub</c>, <c>resub</c>, <c>subgift</c>, <c>anonsubgift</c>, <c>resubgift</c>, <c>anonresubgift</c>
    /// </summary>
    string Context { get; }
    /// <summary>
    /// If this sub message was caused by a gift subscription
    /// </summary>
    bool IsGift { get; }
    /// <summary>
    /// The user's subscription message
    /// </summary>
    SubscribeEvents.SubMessageData SubMessage { get; }
}
