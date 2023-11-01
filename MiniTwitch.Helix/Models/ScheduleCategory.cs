using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class ScheduleCategory
{
    private readonly AllCategories _all;

    internal ScheduleCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<StreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        string? id = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChannelStreamSchedule(broadcasterId, id, startTime, first, cancellationToken);

    public Task<HelixResult<StreamSchedule>> GetChannelStreamSchedule(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        DateTime? startTime = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetChannelStreamSchedule(broadcasterId, ids, startTime, first, cancellationToken);

    public Task<HelixResult> UpdateChannelStreamSchedule(
        long broadcasterId,
        bool? isVacationEnabled = null,
        DateTime? vacationStartTime = null,
        DateTime? vacationEndTime = null,
        string? timezone = null,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelStreamSchedule(broadcasterId, isVacationEnabled, vacationStartTime, vacationEndTime, timezone, cancellationToken);

    public Task<HelixResult<ScheduleSegment>> CreateChannelStreamScheduleSegment(
        long broadcasterId,
        NewScheduleSegment body,
        CancellationToken cancellationToken = default)
    => _all.CreateChannelStreamScheduleSegment(broadcasterId, body, cancellationToken);

    public Task<HelixResult<Responses.UpdatedScheduleSegment>> UpdateChannelStreamScheduleSegment(
        long broadcasterId,
        string id,
        Requests.UpdatedScheduleSegment Body,
        CancellationToken cancellationToken = default)
    => _all.UpdateChannelStreamScheduleSegment(broadcasterId, id, Body, cancellationToken);

    public Task<HelixResult> DeleteChannelStreamScheduleSegment(
        long broadcasterId,
        string id,
        CancellationToken cancellationToken = default)
    => _all.DeleteChannelStreamScheduleSegment(broadcasterId, id, cancellationToken);
}
