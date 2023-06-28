<img src="https://media.occluder.space/f/banner.png" alt="MiniTwitch" />

# About

MiniTwitch is a collection of Twitch libraries for NET Core 6.0+ with the goal of providing convenient asynchronous APIs for Twitch services and care for performance and memory.

Only the IRC component is curently implemented, other components for remaining Twitch services are still in development (Helix, PubSub, EventSub). 🛠

# MiniTwitch.Irc

MiniTwitch.Irc is the component responsible for Twitch chat services. The usage of this package revolves around the `IrcClient`  class which handles connection, communication and channel management

## Features

* Package code is fully documented with XML comments
* Full coverage of chatroom messages and events with convenient APIs
* Built with performance and memory in mind. Nanosecond speeds, with low memory allocation
* Exposes events as `ValueTask`, making for efficient & concurrent usage
* Automatically reconnects upon disconnection & automatically rejoins channels
* Simple & customizable ratelimiting of sending messages and joining channels
* Allows for connecting anonymously - No need for authorization if you don't plan to send anything!
* Understand what happens behind the scenes by supplying an `ILogger`. Allows you to use any logging library which implements [logging abstractions](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging)

## Getting Started

here is an example usage of the `IrcClient` class:

```c#
using MiniTwitch.Irc;
using MiniTwitch.Irc.Models;

namespace MiniTwitchExample;

public class Program
{
    static async Task Main()
    {
        Bot bot = new("myusername", "mytoken");
        await bot.Client.ConnectAsync();
        await bot.Client.JoinChannel("occluder");

        _ = Console.ReadLine();
    }
}

public class Bot
{
    public IrcClient Client { get; init; }

    public Bot(string username, string token)
    {
        Client = new IrcClient(options =>
        {
            options.Username = username;
            options.OAuth = token;
        });

        Client.OnChannelJoin += ChannelJoinEvent;
        Client.OnMessage += MessageEvent;
    }

    private ValueTask ChannelJoinEvent(IrcChannel channel)
    {
        return Client.SendMessage(channel.Name, "Hello from MiniTwitch!");
    }

    private async ValueTask MessageEvent(Privmsg message)
    {
        if (message.Content == "penis123")
        {
            await message.ReplyWith("That's my password!!");
        }
        else if (message.Content == "Wait a minute!")
        {
            await Task.Delay(TimeSpan.FromMinutes(1));
            await message.ReplyWith("I waited. Now what?");
        }
    }
}
```

### Subscribing to events

All events use either the `Func<T, ValueTask>` or `Func<ValueTask>` delegates. Meaning that subscribing methods must have the return type `ValueTask` and account for the `T` parameter when it's present (see `Client.OnMessage` in the example above), the parameter name you set does not matter. Also, if the method doesn't have any asynchronous code you should not mark it as `async` and return `ValueTask.CompletedTask`, `default`or some `ValueTask` object instead.


Subscribing can be done either programmatically:

```c#
Client.OnMessage += MessageEvent;

private async ValueTask MessageEvent(Privmsg message)
{
    ...
}
```

or with anonymous functions:

```c#
Client.OnMessage += async message => 
{
    ...
};
```

Note that you cannot unsubscribe from events if you used anonymous functions.

Read more about event subscriptions [here](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events)

## Installation

****

You can add this package to your project by searching for it with the package manager, or by using the NuGet cli tool:

```c#
Install-Package MiniTwitch.Irc
```

## Dependencies

1. [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/)
2. [MiniTwitch.Common](https://www.nuget.org/packages/MiniTwitch.Common/)