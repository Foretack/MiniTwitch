using MiniTwitch.Helix.Requests;
using MiniTwitch.Helix.Responses;

namespace MiniTwitch.Helix.Models;

public sealed class PredictionsCategory
{
    private readonly AllCategories _all;

    internal PredictionsCategory(AllCategories all)
    {
        _all = all;
    }

    public Task<HelixResult<Predictions>> GetPredictions(
        long broadcasterId,
        string? id = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPredictions(broadcasterId, id, first, cancellationToken);

    public Task<HelixResult<Predictions>> GetPredictions(
        long broadcasterId,
        IEnumerable<string>? ids = null,
        int? first = null,
        CancellationToken cancellationToken = default)
    => _all.GetPredictions(broadcasterId, ids, first, cancellationToken);

    public Task<HelixResult<Prediction>> CreatePrediction(
        NewPrediction body,
        CancellationToken cancellationToken = default)
    => _all.CreatePrediction(body, cancellationToken);

    public Task<HelixResult<Prediction>> EndPrediction(
        PredictionToEnd body,
        CancellationToken cancellationToken = default)
    => _all.EndPrediction(body, cancellationToken);
}
