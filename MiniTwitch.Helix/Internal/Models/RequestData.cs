﻿using System.Text;

namespace MiniTwitch.Helix.Internal.Models;

internal class RequestData
{
    public object Body { get; set; } = default!;

    internal readonly string _method;
    private readonly string _url;
    private readonly StringBuilder _paramBuilder = new();

    public RequestData(string requestUrl, HelixEndpoint endpoint)
    {
        _url = requestUrl + endpoint.Route;
        _method = endpoint.Method.Method;
    }

    public string GetUrl() => _url + _paramBuilder.ToString();

    public RequestData AddParam(string key, object? value)
    {
        const char question = '?';
        const char ampersand = '&';
        if (value is null)
            return this;

        _ = _paramBuilder.Length == 0
            ? _paramBuilder.Append(question)
            : _paramBuilder.Append(ampersand);

        _ = _paramBuilder.Append($"{key}={value}");
        return this;
    }

    public RequestData AddMultiParam(string key, IEnumerable<object>? value)
    {
        if (value is null)
            return this;

        foreach (object obj in value)
        {
            if (_paramBuilder.Length == 0)
            {
                _ = _paramBuilder.Append($"?{key}={obj}");
                continue;
            }

            _ = _paramBuilder.Append($"&{key}={obj}");
        }

        return this;
    }

    public RequestData AddMultiParam<T>(string key, IEnumerable<T>? value)
    {
        if (value is null)
            return this;

        foreach (T? obj in value)
        {
            if (_paramBuilder.Length == 0)
            {
                _ = _paramBuilder.Append($"?{key}={obj}");
                continue;
            }

            _ = _paramBuilder.Append($"&{key}={obj}");
        }

        return this;
    }
}
