# MiniTwitch

<img src="https://media.occluder.space/f/banner.png" alt="MiniTwitch" />
MiniTwitch is a Twitch library for .NET6+ that is focused on performance and memory, it can parse through 350k messages/s (on i5-9400F). 

MiniTwitch currently supports IRC, with plans of supporting Helix, PubSub and hopefully EventSub in the future as well.


## Quick start

### MiniTwitch.Irc
The IRC component is responsible for connection and communication with chat.

Below is an example usage of the `IrcClient` class, which exposes methods and events for received data from Twitch.

The client is completely asynchronous and will handle reconnections & "keep-alive-ping"s for you!

Events for the following are exposed through `IrcClient`:
 - Receive connection information:
 `IrcClient.OnConnect`
 `IrcClient.OnReconnect`
 `IrcClient.OnDisconnect`
 - Receive chat messages:
 `IrcClient.OnMessage` 
 - Receive ban/timeout information:
 `IrcClient.OnUserTimeout`
 `IrcClient.OnUserBan`
 - Receive subscription information:
 `IrcClient.OnSubscriptionNotice`
 `IrcClient.OnGiftedSubNotice`
 `IrcClient.OnGiftedSubNoticeIntro`
	 - Also includes information about users extending/upgrading their subscriptions:
	 `IrcClient.OnPaidUpgradeNotice` 
	 `IrcClient.OnPrimeUpgradeNotice`
- Receive raid information:
`IrcClient.OnRaidNotice`
- Receive announcements:
`IrcClient.OnAnnouncement`
- Receive chat/message clear information:
`IrcClient.OnMessageDelete`
`IrcClient.OnChatClear`
- Receive channel information:
`IrcClient.OnChannelJoin`
`IrcClient.OnChannelPart`
	- Also includes Roomstate information:
	`IrcClient.OnEmoteOnlyModified`
	`IrcClient.OnFollowerModeModified`
	`IrcClient.OnUniqueModeModified`
	`IrcClient.OnSlowModeModified`
	`IrcClient.OnSubOnlyModified`
- Receive whispers:
`IrcClient.OnWhisper`
- Receive Userstate information:
`IrcClient.OnUserstate`
- Receive notices:
`IrcClient.OnNotice`
	- Exposes notice type through `Notice.Type`:
		- Emote_only_on
		- Emote_only_off 
		- Followers_on
		- Followers_on_zero
		- Followers_off
		- Subs_on
		- Subs_off
		- R9K_on
		- R9K_off
		- Slow_on
		- Slow_off
		- Cmds_available
		- Msg_channel_suspended
		- Msg_duplicate
		- Msg_emoteonly
		- Msg_followersonly_zero
		- Msg_followersonly
		- Msg_rejected_mandatory
		- Msg_R9K
		- Msg_slowmode
		- Msg_subsonly
		- Msg_timedout
		- Msg_banned
		- Msg_requires_verified_phone_number
		- Msg_ratelimit
		- Msg_suspended
		- Msg_verified_email
		- No_permission
		- Unavailable_command
		- Unrecognized_cmd
		- Bad_auth
		- Invalid_parent

```csharp
using Microsoft.Extensions.Logging;
using MiniTwitch.Irc;
using Serilog;
using MiniTwitch.Irc.Models;

namespace ExampleApp;

public class Program
{
    private static async Task Main(string[] args)
    {
        // Optional: Set up logger
        Bot bot = new Bot("myusername", "mytoken");
        await bot.Client.ConnectAsync();
        await bot.Client.JoinChannel("mychannel");

        Console.ReadLine();
    }
}

public class Bot
{
    public IrcClient Client { get; init; }

    public Bot(string username, string oauth)
    {
        Client = new IrcClient(options =>
        {
            options.Username = username;
            options.OAuth = oauth;
            // Optional
            options.Logger = new LoggerFactory().AddSerilog(Log.Logger);
        });

        Client.OnMessage += OnMessage_AsyncExample;
        //// Syncronous example
        //Client.OnMessage += OnMessage_SyncExample;

        //// Alternatively, you can subscribe with anonymous methods:

        //// This is an example of an async anonymous event subscription
        //Client.OnMessage += async message =>
        //{
        //    if (message.Content == "!ping")
        //        await message.ReplyWith("Pong!");
        //};

        //// Syncronous variant
        //Client.OnMessage += message =>
        //{
        //    if (message.Content == "penis123")
        //        Console.WriteLine("Your password got leaked 🚨 🚨 🚨 ");

        //    return ValueTask.CompletedTask;
        //};
    }

    // This is an example of an async event subscription
    // The delegate on most events is Func<T, ValueTask>, which means the method return type needs to be ValueTask
    // The T type is what is passed in the parameter
    // This event's handler is Func<Privmsg, ValueTask>
    private async ValueTask OnMessage_AsyncExample(Privmsg message)
    {
        if (message.Content == "!ping")
            await message.ReplyWith("Pong!");
    }

    //private ValueTask OnMessage_SyncExample(Privmsg message)
    //{
    //    if (message.Content == "penis123")
    //        Console.WriteLine("Your password got leaked 🚨 🚨 🚨 ");

    //    return ValueTask.CompletedTask;
    //}
}
```
