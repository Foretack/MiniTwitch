using System.Net.Http.Json;
using System.Text.Json;
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
        where T : IBaseResponse
    {
        (HttpResponseMessage response, TimeSpan elapsed) = await client.RequestAsync(request, cancellationToken);

        T? toObject;
        try
        {
            toObject = await response.Content.ReadFromJsonAsync<T>(HelixApiClient.SerializerOptions, cancellationToken: cancellationToken);
            if (toObject is null)
            {
                return new HelixResult<T>()
                {
                    Success = false,
                    Message = "Unknown deserialization failure.\n\n" +
                        await response.Content.ReadAsStringAsync(cancellationToken),
                    StatusCode = response.StatusCode,
                    Elapsed = elapsed,
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
                Elapsed = elapsed,
                Value = default!
            };
        }

        if (toObject is { Error: not null, Message: not null })
        {
            return new HelixResult<T>()
            {
                Success = false,
                Message = toObject.Message,
                StatusCode = response.StatusCode,
                Elapsed = elapsed,
                Value = default!,
                Ratelimit = GetRateLimit(response)
            };
        }

        return new HelixResult<T>()
        {
            Success = true,
            Message = null,
            StatusCode = response.StatusCode,
            Elapsed = elapsed,
            Value = toObject,
            HelixTask = new() { Endpoint = endpoint, Client = client, Request = request },
            Ratelimit = GetRateLimit(response)
        };
    }

    public static async Task<HelixResult> Create(HelixApiClient client, RequestData request, HelixEndpoint endpoint,
        CancellationToken cancellationToken)
    {
        (HttpResponseMessage response, TimeSpan elapsed) = await client.RequestAsync(request, cancellationToken);

        if (response.StatusCode == endpoint.SuccessStatusCode)
        {
            return new HelixResult()
            {
                Success = true,
                Message = null,
                StatusCode = response.StatusCode,
                Elapsed = elapsed,
                Ratelimit = GetRateLimit(response)
            };
        }

        string? message = string.Empty;
        try
        {
            var element = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken: cancellationToken);

            message = element.TryGetProperty("message", out var value)
                ? value.GetString()
                : string.Empty;
        }
        catch
        {
            // Ignore deserialization errors
        }

        return new HelixResult()
        {
            Success = false,
            Message = message,
            StatusCode = response.StatusCode,
            Elapsed = elapsed,
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
        return new(limit, remaining, resetsIn);
    }
}
