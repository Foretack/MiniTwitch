[2024/11/14]
```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5011/22H2/2022Update)
AMD Ryzen 5 5500, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method                | LineCount | Mean          | Error        | StdDev       | Allocated |
|---------------------- |---------- |--------------:|-------------:|-------------:|----------:|
| **Create**                | **1**         |      **34.25 ns** |     **0.263 ns** |     **0.233 ns** |         **-** |
| Create_Parse          | 1         |     429.68 ns |     4.395 ns |     4.111 ns |     688 B |
| Create_Parse_Map_Send | 1         |     934.08 ns |     1.088 ns |     0.849 ns |     544 B |
| **Create**                | **100**       |   **3,334.77 ns** |    **11.907 ns** |     **9.296 ns** |         **-** |
| Create_Parse          | 100       |  43,553.52 ns |   262.838 ns |   205.206 ns |   70800 B |
| Create_Parse_Map_Send | 100       |  93,196.93 ns |   124.218 ns |   103.728 ns |   54144 B |
| **Create**                | **1000**      |  **36,764.70 ns** |   **330.280 ns** |   **308.944 ns** |         **-** |
| Create_Parse          | 1000      | 466,712.74 ns | 3,409.083 ns | 2,661.588 ns |  737464 B |
| Create_Parse_Map_Send | 1000      | 992,239.23 ns | 2,743.689 ns | 2,432.208 ns |  558858 B |

Method information:
- `Create`: Creates the [IrcMessage](https://github.com/occluder/MiniTwitch/blob/master/MiniTwitch.Irc/Internal/Models/IrcMessage.cs) struct on top of IRC data
- `Create_Parse`: Creates IrcMessage and uses all its methods (GetChannel, GetUsername, GetContent, ParseTags)
- `Create_Parse_Map_Send`: Runs the entirety of the handling process in [IrcClient](https://github.com/occluder/MiniTwitch/blob/master/MiniTwitch.Irc/IrcClient.cs#L528):
	* Creates IrcMessage
	* Maps the IrcMessage to its respective struct (e.g [Usernotice](https://github.com/occluder/MiniTwitch/blob/master/MiniTwitch.Irc/Models/Usernotice.cs), [Privmsg](https://github.com/occluder/MiniTwitch/blob/master/MiniTwitch.Irc/Models/Privmsg.cs), [Clearchat](https://github.com/occluder/MiniTwitch/blob/master/MiniTwitch.Irc/Models/ClearChat.cs)...)
	* All the message tags are converted from bytes to other representations such as `int`, `string` and `bool` by [TagHelper](https://github.com/occluder/MiniTwitch/blob/master/MiniTwitch.Irc/Internal/Parsing/TagHelper.cs)
	* After the structs are constructed, the event corresponding to the message is invoked with the constructed struct

Data used: First 2000 lines of [Forsen's chat logs from 2022/01/01](https://logs.ivr.fi/channel/forsen/2022/1/1?raw=t) (very large)