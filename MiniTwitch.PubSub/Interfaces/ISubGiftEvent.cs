using MiniTwitch.PubSub.Models.Payloads;

namespace MiniTwitch.PubSub.Interfaces;

/// <summary>
/// Represents information about a subgift event
/// </summary>
public interface ISubGiftEvent
{
    /// <summary>
    /// Name of the subgifter
    /// </summary>
    string Username { get; }
    /// <summary>
    /// Display name of the subgifter
    /// </summary>
    string DisplayName { get; }
    /// <summary>
    /// Name of the channel where the gift was sent
    /// </summary>
    string ChannelName { get; }
    /// <summary>
    /// ID of the subgifter
    /// </summary>
    long UserId { get; }
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
    /// Event type associated with the subscription product, values: sub, resub, subgift, anonsubgift, resubgift, anonresubgift
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
    /// <summary>
    /// ID of the gift recipient
    /// </summary>
    long RecipientId { get; }
    /// <summary>
    /// Name of the gift recipient
    /// </summary>
    string RecipientUsername { get; }
    /// <summary>
    /// Display name of the gift recipient
    /// </summary>
    string RecipientDisplayName { get; }
    /// <summary>
    /// Number of months gifted as part of a single, multi-month gift OR number of months purchased as part of a multi-month subscription
    /// </summary>
    int MultiMonthDuration { get; }
}
