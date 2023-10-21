using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using MiniTwitch.Helix.Internal.Json;
using MiniTwitch.Helix.Internal.Models;

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

    public HelixApiClient(string token, string clientId, ILogger? logger)
    {
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        _httpClient.DefaultRequestHeaders.Add("Client-Id", $"{clientId}");
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

    private void Log(LogLevel level, string template, params object[] properties) => _logger?.Log(level, $"[MiniTwitch.Helix] " + template, properties);
}
