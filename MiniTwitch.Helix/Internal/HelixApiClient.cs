using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Internal.Models;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix.Internal;

internal sealed class HelixApiClient
{
    public JsonSerializerOptions SerializerOptions { get; init; } = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        PropertyNamingPolicy = new SnakeCaseNamingPolicy()
    };

    private readonly HttpClient _httpClient = new();
    private readonly ILogger? _logger;
    private readonly string _token;
    private ValidToken? _tokenInfo;

    public HelixApiClient(string token, string clientId, ILogger? logger)
    {
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        _httpClient.DefaultRequestHeaders.Add("Client-Id", $"{clientId}");
        _token = token;
        _logger = logger;
    }

    public Task<(HttpResponseMessage, long)> RequestAsync(RequestData requestObject, CancellationToken ct) => requestObject._method switch
    {
        "POST" => PostAsync(requestObject, ct),
        "GET" => GetAsync(requestObject, ct),
        "PUT" => PutAsync(requestObject, ct),
        "DELETE" => DeleteAsync(requestObject, ct),
        "PATCH" => PatchAsync(requestObject, ct),
        _ => throw new NotImplementedException($"HTTP method {requestObject._method} is not supported")
    };

    private async Task<(HttpResponseMessage, long)> PostAsync(RequestData requestObject, CancellationToken ct)
    {
        await ValidateToken();
        string url = requestObject.GetUrl();
        var sw = Stopwatch.StartNew();
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, requestObject.Body, this.SerializerOptions, ct);
        sw.Stop();
        long elapsedMs = sw.ElapsedMilliseconds;
        LogLevel logLevel = response.IsSuccessStatusCode ? LogLevel.Debug : LogLevel.Warning;
        Log(logLevel, "POST [{Code}] {Url} {ElapsedMs}ms", response.StatusCode, url, elapsedMs);
        return (response, elapsedMs);
    }

    private async Task<(HttpResponseMessage, long)> GetAsync(RequestData requestObject, CancellationToken ct)
    {
        await ValidateToken();
        string url = requestObject.GetUrl();
        var sw = Stopwatch.StartNew();
        HttpResponseMessage response = await _httpClient.GetAsync(url, ct);
        sw.Stop();
        long elapsedMs = sw.ElapsedMilliseconds;
        LogLevel logLevel = response.IsSuccessStatusCode ? LogLevel.Debug : LogLevel.Warning;
        Log(logLevel, "GET [{Code}] {Url} {ElapsedMs}ms", response.StatusCode, url, elapsedMs);
        return (response, elapsedMs);
    }

    private async Task<(HttpResponseMessage, long)> PutAsync(RequestData requestObject, CancellationToken ct)
    {
        await ValidateToken();
        string url = requestObject.GetUrl();
        var sw = Stopwatch.StartNew();
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, requestObject.Body, this.SerializerOptions, ct);
        sw.Stop();
        long elapsedMs = sw.ElapsedMilliseconds;
        LogLevel logLevel = response.IsSuccessStatusCode ? LogLevel.Debug : LogLevel.Warning;
        Log(logLevel, "PUT [{Code}] {Url} {ElapsedMs}ms", response.StatusCode, url, elapsedMs);
        return (response, elapsedMs);
    }

    private async Task<(HttpResponseMessage, long)> DeleteAsync(RequestData requestObject, CancellationToken ct)
    {
        await ValidateToken();
        string url = requestObject.GetUrl();
        var sw = Stopwatch.StartNew();
        HttpResponseMessage response = await _httpClient.DeleteAsync(url, ct);
        sw.Stop();
        long elapsedMs = sw.ElapsedMilliseconds;
        LogLevel logLevel = response.IsSuccessStatusCode ? LogLevel.Debug : LogLevel.Warning;
        Log(logLevel, "DELETE [{Code}] {Url} {ElapsedMs}ms", response.StatusCode, url, elapsedMs);
        return (response, elapsedMs);
    }

    private async Task<(HttpResponseMessage, long)> PatchAsync(RequestData requestObject, CancellationToken ct)
    {
        await ValidateToken();
        string url = requestObject.GetUrl();
        string rawContent = JsonSerializer.Serialize(requestObject.Body, this.SerializerOptions);
        var content = new StringContent(rawContent, Encoding.UTF8, "application/json");
        var sw = Stopwatch.StartNew();
        HttpResponseMessage response = await _httpClient.PatchAsync(url, content, ct);
        sw.Stop();
        long elapsedMs = sw.ElapsedMilliseconds;
        LogLevel logLevel = response.IsSuccessStatusCode ? LogLevel.Debug : LogLevel.Warning;
        Log(logLevel, "PATCH [{Code}] {Url} {ElapsedMs}ms", response.StatusCode, url, elapsedMs);
        return (response, elapsedMs);
    }

    private async ValueTask ValidateToken()
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (_tokenInfo is not null)
        {
            TimeSpan expiresIn = TimeSpan.FromSeconds(_tokenInfo.ReceivedAt + _tokenInfo.ExpiresIn - now);
            if (_tokenInfo.IsPermaToken)
            {
                Log(LogLevel.Trace, "Request sent with access token from user {Username} [No expiry]");
                return;
            }

            switch (expiresIn)
            {
                case { TotalSeconds: <=-1 }:
                    throw new InvalidTokenException(null, $"Access token for user \"{_tokenInfo.Login}\" has expired");
                case { TotalHours: < 0 }:
                    Log(LogLevel.Warning, "Access token for user {Username} expires in {ExpiresInMinutes} minutes", expiresIn.Minutes);
                    break;
                case { TotalDays: < 0 }:
                    Log(LogLevel.Warning, "Access token for user {Username} expires in {ExpiresInHours} hours", expiresIn.Hours);
                    break;
                default:
                    Log(LogLevel.Trace, "Request sent with access token from user {Username} [Expires in: {ExpiresIn}]", expiresIn);
                    break;
            }

            return;
        }

        HttpResponseMessage response = await _httpClient.GetAsync("https://id.twitch.tv/oauth2/validate");
        if (!response.IsSuccessStatusCode)
        {
            InvalidToken? invalid = await response.Content.ReadFromJsonAsync<InvalidToken>();
            throw new InvalidTokenException(invalid?.Message, "Provided access token is either invalid or has expired");
        }

        _tokenInfo = await response.Content.ReadFromJsonAsync<ValidToken>();
        if (_tokenInfo is null)
            return;

        _tokenInfo.ReceivedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (_tokenInfo.IsPermaToken)
        {
            Log(
                LogLevel.Information, 
                "Validated access token from user {Username} with {ScopeCount} scopes. The token does not expire",
                _tokenInfo.Login, _tokenInfo.Scopes.Count
            );

            return;
        }

        Log(
            LogLevel.Information, 
            "Validated access token from user {Username} with {ScopeCount} scopes. The token expires at {ExpiresAt}",
            _tokenInfo.Login, _tokenInfo.Scopes.Count, DateTimeOffset.FromUnixTimeSeconds(_tokenInfo.ReceivedAt + _tokenInfo.ExpiresIn)
        );
    }

    private void Log(LogLevel level, string template, params object[] properties) => _logger?.Log(level, "[MiniTwitch.Helix] " + template, properties);
}
