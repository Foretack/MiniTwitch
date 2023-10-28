using System.Net.Http.Json;
using MiniTwitch.Helix.Internal.Models;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Internal;

internal static class HelixResultFactory
{
    private const string HEADER_RL_LIMIT = "Ratelimit-Limit";
    private const string HEADER_RL_REMAINING = "Ratelimit-Remaining";
    private const string HEADER_RL_RESET = "Ratelimit-Reset";

    public static async Task<HelixResult<T>> Create<T>(HelixApiClient client, RequestData request, HelixEndpoint endpoint,
        CancellationToken cancellationToken)
    {
        (HttpResponseMessage response, long elapsedMs) = await client.RequestAsync(request, cancellationToken);
        // Because some endpoints don't have appropriate success status codes, .IsSuccessStatusCode should be checked first
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
                    Value = toObject!,
                    Ratelimit = GetRateLimit(response)
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
            Ratelimit = GetRateLimit(response)
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
            Elapsed = TimeSpan.FromMilliseconds(elapsedMs),
            Ratelimit = GetRateLimit(response)
        };
    }

    private static RequestRatelimit GetRateLimit(HttpResponseMessage response)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        int limit = 0;
        int remaining = 0;
        int resets = 0;
        int val;
        foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
        {
            switch (header.Key)
            {
                case HEADER_RL_LIMIT:
                    limit = int.TryParse(header.Value.FirstOrDefault(), out val) ? val : 0;
                    break;

                case HEADER_RL_REMAINING:
                    remaining = int.TryParse(header.Value.FirstOrDefault(), out val) ? val : 0;
                    break;

                case HEADER_RL_RESET:
                    resets = int.TryParse(header.Value.FirstOrDefault(), out val) ? val : 0;
                    break;

                default:
                    continue;
            }
        }

        TimeSpan resetsIn = resets - now < 0 ? TimeSpan.Zero : TimeSpan.FromSeconds(resets - now);
        return new()
        {
            Limit = limit,
            Remaining = remaining,
            ResetsIn = resetsIn
        };
    }
}
