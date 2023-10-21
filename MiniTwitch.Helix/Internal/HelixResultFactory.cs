using System.Net.Http.Json;
using MiniTwitch.Helix.Internal.Models;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Internal;

internal static class HelixResultFactory
{
    public static async Task<HelixResult<T>> Create<T>(HelixApiClient client, RequestData request, HelixEndpoint endpoint,
        CancellationToken cancellationToken)
    {
        (HttpResponseMessage response, long elapsedMs) = await client.RequestAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode && response.StatusCode != endpoint.SuccessStatusCode)
        {
            return new HelixResult<T>()
            {
                Success = false,
                Message = endpoint.GetResponseMessage(response.StatusCode),
                StatusCode = response.StatusCode,
                Elapsed = TimeSpan.FromMilliseconds(elapsedMs),
                Value = default!
            };
        }

        T? toObject;

        try
        {
            toObject = await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
            if (toObject is null)
            {
                return new HelixResult<T>()
                {
                    Success = false,
                    Message = "Unknown deserialization failure.\n\n" +
                        await response.Content.ReadAsStringAsync(cancellationToken),
                    StatusCode = response.StatusCode,
                    Elapsed = TimeSpan.FromMilliseconds(elapsedMs),
                    Value = toObject!
                };
            }
        }
        catch (Exception ex)
        {
            return new HelixResult<T>()
            {
                Success = false,
                Message = $"Deserialization failure.\n" +
                    $"{ex.Message}\n" +
                    $"{ex.StackTrace}\n\n" +
                    await response.Content.ReadAsStringAsync(cancellationToken),
                StatusCode = response.StatusCode,
                Elapsed = TimeSpan.FromMilliseconds(elapsedMs),
                Value = default!
            };
        }

        return new HelixResult<T>()
        {
            Success = true,
            Message = endpoint.GetResponseMessage(response.StatusCode),
            StatusCode = response.StatusCode,
            Elapsed = TimeSpan.FromMilliseconds(elapsedMs),
            Value = toObject,
            HelixTask = new() { Endpoint = endpoint, Client = client, Request = request },
        };
    }

    public static async Task<HelixResult> Create(HelixApiClient client, RequestData request, HelixEndpoint endpoint,
        CancellationToken cancellationToken)
    {
        (HttpResponseMessage response, long elapsedMs) = await client.RequestAsync(request, cancellationToken);
        return new HelixResult()
        {
            Success = response.StatusCode == endpoint.SuccessStatusCode,
            Message = endpoint.GetResponseMessage(response.StatusCode),
            StatusCode = response.StatusCode,
            Elapsed = TimeSpan.FromMilliseconds(elapsedMs)
        };
    }
}
