[2023/11/14]
```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3570/22H2/2022Update)
AMD Ryzen 5 5500, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method                | LineCount | Mean          | Error        | StdDev       | Allocated |
|---------------------- |---------- |--------------:|-------------:|-------------:|----------:|
| **Create**                | **1**         |      **34.31 ns** |     **0.386 ns** |     **0.362 ns** |         **-** |
| Create_Parse          | 1         |     409.43 ns |     3.424 ns |     3.035 ns |     688 B |
| Create_Parse_Map_Send | 1         |     951.91 ns |    12.541 ns |    11.731 ns |     496 B |
| **Create**                | **100**       |   **3,468.59 ns** |    **11.058 ns** |     **9.803 ns** |         **-** |
| Create_Parse          | 100       |  42,173.96 ns |   513.590 ns |   480.412 ns |   70800 B |
| Create_Parse_Map_Send | 100       |  93,322.18 ns |   826.022 ns |   732.247 ns |   49536 B |
| **Create**                | **1000**      |  **39,394.06 ns** |   **341.485 ns** |   **319.425 ns** |         **-** |
| Create_Parse          | 1000      | 428,392.24 ns | 3,083.658 ns | 2,733.583 ns |  737464 B |
| Create_Parse_Map_Send | 1000      | 970,324.95 ns | 3,646.234 ns | 3,044.770 ns |  512778 B |

Processing capability: 1,030,580 messages per second

Method information:
- `Create`: Creates the [IrcMessage](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Internal/Models/IrcMessage.cs) struct on top of IRC data
- `Create_Parse`: Creates IrcMessage and uses all its methods (GetChannel, GetUsername, GetContent, ParseTags)
- `Create_Parse_Map_Send`: Runs the entirety of the handling process in [IrcClient](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/IrcClient.cs#L528):
	* Creates IrcMessage
	* Maps the IrcMessage to its respective struct (e.g [Usernotice](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Models/Usernotice.cs), [Privmsg](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Models/Privmsg.cs), [Clearchat](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Models/ClearChat.cs)...)
	* All the message tags are converted from bytes to other representations such as `int`, `string` and `bool` by [TagHelper](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Internal/Parsing/TagHelper.cs)
	* After the structs are constructed, the event corresponding to the message is invoked with the constructed struct

Data used: First 2000 lines of [Forsen's chat logs from 2022/01/01](https://logs.ivr.fi/channel/forsen/2022/1/1?raw=t) (very large)