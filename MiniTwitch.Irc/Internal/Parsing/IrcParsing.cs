using System.Text;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Internal.Enums;
using MiniTwitch.Irc.Internal.Models;

namespace MiniTwitch.Irc.Internal.Parsing;

internal static class IrcParsing
{
    internal static string FindChannel(this ReadOnlySpan<byte> span, bool anySeparator = false)
    {
        const byte numberSymbol = (byte)'#';
        const byte space = (byte)' ';
        const byte lf = (byte)'\n';
        const byte cr = (byte)'\r';

        int scopeStart = span.IndexOf(space) + 1;
        int symbolIndex = span[scopeStart..].IndexOf(numberSymbol) + scopeStart;
        int nextSpace;
        if (anySeparator)
        {
            ReadOnlySpan<byte> ends = stackalloc byte[] { space, lf, cr };
            nextSpace = span[symbolIndex..].IndexOfAny(ends) + symbolIndex;
        }
        else
        {
            nextSpace = span[symbolIndex..].IndexOf(space) + symbolIndex;
        }

        if (nextSpace == symbolIndex - 1)
            nextSpace = span.Length;

        ReadOnlySpan<byte> newSpan;
        try
        {
            newSpan = span[(symbolIndex + 1)..nextSpace];
        }
        catch (Exception)
        {
            throw new ArgumentException($"Failed to find channel from {symbolIndex + 1} to {nextSpace} in\n{Encoding.UTF8.GetString(span)}");
        }
        return TagHelper.GetString(newSpan, true);
    }

    internal static (string Content, bool Action) FindContent(this ReadOnlySpan<byte> span, bool maybeEmpty = false, bool maybeAction = false)
    {
        const byte colon = (byte)':';
        const byte space = (byte)' ';

        // <tags> :foo!foo@foo.tmi.twitch.tv PRIVMSG #bar :asdf
        //         ↑
        int firstSeparatorIndex = span.IndexOf(space) + 2;
        // <tags> :foo!foo@foo.tmi.twitch.tv PRIVMSG #bar :asdf
        //                                                 ↑
        int secondSeparatorIndex = span[firstSeparatorIndex..].IndexOf(colon) + firstSeparatorIndex + 1;
        if (maybeEmpty && secondSeparatorIndex - firstSeparatorIndex - 1 == -1)
            return (string.Empty, false);

        ReadOnlySpan<byte> newSpan = span[secondSeparatorIndex..];
        string content = TagHelper.GetString(newSpan);
        if (maybeAction && content.Length > 9 && content[0] == '\u0001' && content[^1] == '\u0001')
            return (content[8..^1], true);

        return (content, false);
    }

    internal static string FindUsername(this ReadOnlySpan<byte> span, bool noTags = false)
    {
        const byte space = (byte)' ';
        const byte exclamationMark = (byte)'!';

        int separator;
        int exclamationIndex;
        if (noTags)
        {
            // :foo!foo@foo.tmi.twitch.tv JOIN #bar
            //  |__|
            separator = 1;
            exclamationIndex = span.IndexOf(exclamationMark);
        }
        else
        {
            // <tags> :foo!foo@foo.tmi.twitch.tv PRIVMSG #bar :asdf
            //         ↑
            separator = span.IndexOf(space) + 2;
            // <tags> :foo!foo@foo.tmi.twitch.tv PRIVMSG #bar :asdf
            //            ↑
            exclamationIndex = span[separator..].IndexOf(exclamationMark) + separator;
        }

        ReadOnlySpan<byte> newSpan;
        try
        {
            newSpan = span[separator..exclamationIndex];
        }
        catch (Exception)
        {
            throw new ArgumentException($"Failed to find channel from {separator + 1} to {exclamationIndex} in\n{Encoding.UTF8.GetString(span)}");
        }
        return TagHelper.GetString(newSpan);
    }

    internal static IrcTags ParseTags(ReadOnlyMemory<byte> memory)
    {
        ReadOnlySpan<byte> span = memory.Span;

        const byte at = (byte)'@';
        const byte space = (byte)' ';
        const byte colon = (byte)':';
        const byte semiColon = (byte)';';
        const byte equals = (byte)'=';

        int tagsStartIndex = span[0] is at or colon ? 1 : 0;
        int tagsEndIndex = span.IndexOf(space);
        int tagCount = 0;

        // Determine the amount of tags by counting '='
        int eqIndex;
        ReadOnlySpan<byte> tagIndexCountSpan = span;
        while ((eqIndex = tagIndexCountSpan.IndexOf(equals)) != -1)
        {
            tagCount++;
            tagIndexCountSpan = tagIndexCountSpan[(eqIndex + 1)..];
        }

        IrcTags tags = new(tagCount);
        int tagStart = tagsStartIndex;
        int tagEquals;
        int tagEnd;

        for (int i = 0; i < tagCount; i++)
        {
            if (tagStart >= tagsEndIndex)
                break;

            // Index of '=' from the start of the tag
            tagEquals = span[tagStart..tagsEndIndex].IndexOf(equals) + tagStart;
            if (tagEquals == tagStart - 1)
                break;

            // Index of ';' from the equal sign of the tag
            tagEnd = span[tagEquals..tagsEndIndex].IndexOf(semiColon) + tagEquals;
            // Account for last tag, which doesn't end with a semicolon
            if (tagEnd == tagEquals - 1)
                tagEnd = tagsEndIndex;

            // Key memory slice: from index 0 until the next equal sign
            // Value memory slice: from index 0 after the equal sign until next semicolon
            tags.Add(i, memory[tagStart..tagEquals], memory[(tagEquals + 1)..tagEnd]);
            tagStart = tagEnd + 1;
        }

        return tags;
    }

    /// <summary>
    /// Parses IRC commands from messages
    /// </summary>
    /// <param name="span">The span to parse</param>
    /// <returns>The IRC command and the index start of the next message (0 if none)</returns>
    internal static (IrcCommand cmd, int lfIndex) ParseCommand(ReadOnlySpan<byte> span)
    {
        const byte space = (byte)' ';
        const byte colon = (byte)':';
        const byte at = (byte)'@';
        const byte lf = (byte)'\n';

        int scopeStart;
        int firstSpace;
        int startIndex;
        int length;
        ReadOnlySpan<byte> command;

        if (span[0] == lf)
        {
            return (IrcCommand.Unknown, 0);
        }
        else if (span[0] is not colon and not at)
        {
            firstSpace = span.IndexOf(space);
            command = span[..firstSpace];
        }
        else
        {
            // Start looking for the command from the first space
            scopeStart = span.IndexOf(space);
            // <tags> :<sender> <command> <room>
            if (span[scopeStart + 1] == colon)
            {
                scopeStart += 2;
                // <tags> :<sender> <command> <room>
                //                 ↑
                firstSpace = span[scopeStart..].IndexOf(space) + scopeStart;
                startIndex = firstSpace + 1;
                // <tags> :<sender> <command> <room>
                //                 |_________|
                length = span[startIndex..].IndexOf(space);

                if (firstSpace == scopeStart - 1 || length == -1)
                    return (IrcCommand.Unknown, 0);

                command = span[startIndex..(startIndex + length)];
            }
            // :<sender> <command> <room>
            else
            {
                // Since there are no tags, 'scopeStart' will be 'firstSpace' here
                ++scopeStart;
                int secondSpace = span[scopeStart..].IndexOf(space) + scopeStart;
                if (secondSpace == scopeStart - 1)
                    secondSpace = span.Length;

                command = span[scopeStart..secondSpace];
            }
        }

        return ((IrcCommand)command.Sum(), span.IndexOf(lf) + 1);
    }
}
