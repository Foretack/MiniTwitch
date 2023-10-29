# MiniTwitch.PubSub

MiniTwitch.PubSub is the component responsible for interaction with the Twitch PubSub service. The usage of this package revolves around the `PubSubClient`  class and the `Topics` static class.

## Features

* Package code is fully documented with XML comments
* Exposes documented & undocumented PubSub topics
* Uses `System.Text.Json` under the hood; Fast, efficient and without unnecessary dependencies
* Exposes events with `Func<T1, .., ValueTask>` delegates, making asynchronous handling very easy
* Automatically reconnects upon disconnection & automatically re-listens to topics
* Simplistic; Events have clear descriptions on what they do and how to get them invoked
* Multi-token support; You're not limited to 1 auth token per `PubSubClient`
* Comes with a built-in logger, which can be disabled or replaced easily
* Events return the topic parameters as `ChannelId` or `UserId`, making them easily distinguishable

## Getting Started

here is an example usage of the `PubSubClient` class:

```c#
using MiniTwitch.PubSub;
using MiniTwitch.PubSub.Interfaces;
using MiniTwitch.PubSub.Models;
using MiniTwitch.PubSub.Payloads;

namespace MiniTwitchExample;

public class Program
{
    static async Task Main()
    {
        PubSubClient client = new("my token");

        await client.ConnectAsync();
        var playbackResponse = await client.ListenTo(Topics.VideoPlayback(36175310));
        if (playbackResponse.IsSuccess)
            Console.WriteLine($"Listened to {playbackResponse.TopicKey} successfully!");

        var responses =  await client.ListenTo(Topics.Following(783267696) | Topics.ChatroomsUser(754250938, "a different token"));
        foreach (var response in responses)
        {
            if (!response.IsSuccess)
                Console.WriteLine($"Failed to listen to {response.TopicKey}! Error: {response.Error}");
        }

        client.OnStreamUp += OnStreamUp;
        client.OnFollow += OnFollow;
        client.OnTimedOut += OnTimedOut;

        _ = Console.ReadLine();
    }

    private static ValueTask OnStreamUp(ChannelId channelId, IStreamUp stream)
    {
        Console.WriteLine($"Channel ID {channelId} just went live! (Stream delay: {stream.PlayDelay})");
        return ValueTask.CompletedTask;
    }

    private static ValueTask OnFollow(ChannelId channelId, Follower follower)
    {
        Console.WriteLine($"{follower.Name} just followed you!");
        return ValueTask.CompletedTask;
    }

    private static ValueTask OnTimedOut(UserId userId, ITimeOutData timeout)
    {
        Console.WriteLine(
            $"Your other account (ID: {userId}) has been timed out for {timeout.ExpiresInMs}ms in channel ID {timeout.ChannelId}");
        return ValueTask.CompletedTask;
    }
}
```

****