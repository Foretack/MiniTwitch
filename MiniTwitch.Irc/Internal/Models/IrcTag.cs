namespace MiniTwitch.Irc.Internal.Models;

internal readonly record struct IrcTag(ReadOnlyMemory<byte> Key, ReadOnlyMemory<byte> Value);
