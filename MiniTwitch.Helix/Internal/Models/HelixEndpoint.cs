﻿using System.Net;

namespace MiniTwitch.Helix.Internal.Models;

internal class HelixEndpoint
{
    public HttpMethod Method { get; init; } = default!;
    public string Route { get; init; } = default!;
}
