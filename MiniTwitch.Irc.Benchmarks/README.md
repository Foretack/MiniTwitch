[2023-10-11]
```
BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 5500, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
```
| Method                | LineCount | Mean            | Error        | StdDev       | Allocated |
|---------------------- |---------- |----------------:|-------------:|-------------:|----------:|
| **Create**                | **1**         |        **37.98 ns** |     **0.065 ns** |     **0.058 ns** |         **-** |
| Create_Parse          | 1         |       572.74 ns |     4.306 ns |     4.028 ns |    1688 B |
| Create_Parse_Map_Send | 1         |     1,278.26 ns |     4.775 ns |     4.233 ns |    1536 B |
| **Create**                | **100**       |     **3,962.70 ns** |    **13.748 ns** |    **12.859 ns** |         **-** |
| Create_Parse          | 100       |    61,892.43 ns |   231.734 ns |   193.508 ns |  147208 B |
| Create_Parse_Map_Send | 100       |   127,225.59 ns |   372.128 ns |   348.089 ns |  126512 B |
| **Create**                | **1000**      |    **42,171.25 ns** |    **70.650 ns** |    **66.086 ns** |         **-** |
| Create_Parse          | 1000      |   581,962.63 ns | 1,775.889 ns | 1,661.168 ns | 1437545 B |
| Create_Parse_Map_Send | 1000      | 1,275,107.84 ns | 2,450.598 ns | 2,292.291 ns | 1298634 B |

Method information:
- `Create`: Creates the [IrcMessage](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Internal/Models/IrcMessage.cs) struct on top of IRC data
- `Create_Parse`: Creates IrcMessage and uses all its methods (GetChannel, GetUsername, GetContent, ParseTags)
- `Create_Parse_Map_Send`: Runs the entirety of the handling process in [IrcClient](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/IrcClient.cs#L528):
	* Creates IrcMessage
	* Maps the IrcMessage to its respective struct (e.g [Usernotice](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Models/Usernotice.cs), [Privmsg](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Models/Privmsg.cs), [Clearchat](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Models/ClearChat.cs)...)
	* All the message tags are converted from bytes to other representations such as `int`, `string` and `bool` by [TagHelper](https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/Internal/Parsing/TagHelper.cs)
	* After the structs are constructed, the event corresponding to the message is invoked with the constructed struct