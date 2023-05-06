﻿using System.Text;
using MiniTwitch.Helix.Internal.Enums;

namespace MiniTwitch.Helix.Internal.Models;

internal struct RequestData
{
    public object Body { get; set; } = default!;

    internal readonly string _method;
    private readonly string _url;
    private readonly StringBuilder _paramBuilder = new();

    public RequestData(string requestUrl, HttpMethod method)
    {
        _url = requestUrl;
        _method = method.Method;
    }

    public readonly string GetUrl() => _url + _paramBuilder.ToString();

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
}
