# MiniTwitch.Helix (Pre-release)

MiniTwitch.Helix conveniently wraps the Twitch Helix API and exposes them through the `HelixWrapper` and `SortedHelixWrapper` classes. The difference between the two classes is that `HelixWrapper` exposes all endpoints as methods directly on the class, while `SortedHelixWrapper` exposes them through categories (i.e `HelixWrapper.BanUser()` vs `SortedHelixWrapper.Moderation.BanUser()`)

## Features

- Contains all generally available and beta Helix API endpoints
- Virtually no dependencies
- Returns meaningful information about responses with `HelixResult`:
	- **HelixResult.Success**: Whether the request was successful
	- **HelixResult.StatusCode**: Status code of the response
	- **HelixResult.Message**: Contains a message clarifying the meaning of the status code
	- **HelixResult.Elapsed**: The amount of time the request took to get a response
	- **HelixResult.RateLimit.Limit**: Maximum amount of requests that can be made in a period
	- **HelixResult.RateLimit.Remaining**: The amount of requests that can be made before the ratelimit resets
	- **HelixResult.RateLimit.ResetsIn**: The amount of time before the ratelimit resets

- Validates access tokens & warns before their expiry
- Easy pagination API for `HelixResult<T>`:
	- **HelixResult.CanPaginate**: Determines whether the next page of content can be requested
	- **HelixResult.Paginate()**: Fetches the next page of content

## Getting Started

This example demonstrates the usage of `HelixWrapper` and `HelixResult<T>.Paginate()`

```csharp
using MiniTwitch.Helix;
using MiniTwitch.Helix.Models;
using MiniTwitch.Helix.Responses;

namespace MiniTwitchExample;

public class Program
{
    public static HelixWrapper Helix { get; set; }

    static async Task Main()
    {
        Helix = new HelixWrapper("Access token", "Client ID");

        await GetFirst1000Usernames(12345678, 12345678);
        await GetAllUsernames(12345678, 12345678);
    }

    private static async Task<IReadOnlyList<string>> GetFirst1000Usernames(long broadcasterId, long moderatorId)
    {
        List<string> usernames = new();
        HelixResult<Chatters> chatters = await Helix.GetChatters(broadcasterId, moderatorId, first: 1000);

        // Make sure the result is a success and the value contains data
        if (!chatters.Success) return Array.Empty<string>();

        foreach (var chatter in chatters.Value.Data)
        {
            usernames.Add(chatter.Username);
        }

        return usernames;
    }

    private static async Task<IReadOnlyList<string>> GetAllUsernames(long broadcasterId, long moderatorId)
    {
        List<string> usernames = new();
        HelixResult<Chatters> chatters = await Helix.GetChatters(broadcasterId, moderatorId, first: 1000);
        
        if (!chatters.Success) return Array.Empty<string>();

        foreach (var chatter in chatters.Value.Data)
        {
            usernames.Add(chatter.Username);
        }

        // No more users - return what we got
        if (!chatters.CanPaginate) return usernames;

        // Continue paginating if the result is a success and there is content
        while (await chatters.Paginate() is { Success: true } next)
        {
            foreach (var chatter in next.Value.Data)
            {
                usernames.Add(chatter.Username);
            }

            // Return when pagination is no longer possible
            if (!next.CanPaginate) return usernames;

            chatters = next;
        }

        return usernames;
    }
}
```