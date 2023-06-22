using System.Text.Json.Serialization;
using MiniTwitch.PubSub.Interfaces;

namespace MiniTwitch.PubSub.Models;

public readonly record struct SubscribeEventsPayload(
    [property: JsonPropertyName("channel_name")] string ChannelName,
    [property: JsonPropertyName("channel_id")] long ChannelId,
    [property: JsonPropertyName("time")] DateTime Time,
    [property: JsonPropertyName("sub_plan")] string SubPlan,
    [property: JsonPropertyName("sub_plan_name")] string SubPlanName,
    [property: JsonPropertyName("context")] string Context,
    [property: JsonPropertyName("is_gift")] bool IsGift,
    [property: JsonPropertyName("sub_message")] SubMessage SubMessage,
    [property: JsonPropertyName("recipient_id")] long RecipientId = 0,
    [property: JsonPropertyName("recipient_user_name")] string RecipientUsername = "",
    [property: JsonPropertyName("recipient_display_name")] string RecipientDisplayName = "",
    [property: JsonPropertyName("user_name")] string Username = "",
    [property: JsonPropertyName("display_name")] string DisplayName = "",
    [property: JsonPropertyName("user_id")] long UserId = 0,
    [property: JsonPropertyName("months")] int Months = 0,
    [property: JsonPropertyName("streak_months")] int StreakMonths = 0,
    [property: JsonPropertyName("multi_month_duration")] int MultiMonthDuration = 1,
    [property: JsonPropertyName("cumulative_months")] int CumulativeMonths = 0
) : ISubEvent, ISubGiftEvent, IAnonSubGiftEvent;

public readonly record struct Emote(
    [property: JsonPropertyName("start")] int Start,
    [property: JsonPropertyName("end")] int End,
    [property: JsonPropertyName("id")] int Id
);

public readonly record struct SubMessage(
    [property: JsonPropertyName("message")] string Message = "",
    [property: JsonPropertyName("emotes")] IReadOnlyList<Emote>? Emotes = default
);