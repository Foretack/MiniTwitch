using MiniTwitch.Irc.Internal.Models;

namespace MiniTwitch.Irc.Internal.Parsing;

internal static class IrcParsing
{
    internal static string GetChannel(this IrcMessage message) => TagHelper.GetString(message.Span[message.ChannelRange], true);
    internal static string GetUsername(this IrcMessage message) => message.HasUsername
        ? TagHelper.GetString(message.Span[message.UsernameRange])
        : string.Empty;

    internal static (string Content, bool Action) GetContent(this IrcMessage message, bool maybeAction = false)
    {
        if (!message.HasMessageContent)
            return (string.Empty, false);

        string content = TagHelper.GetString(message.Span[message.MessageContentRange]);
        if (maybeAction && content.Length > 9 && content[0] == '\u0001' && content[^1] == '\u0001')
            return (content[8..^1], true);

        return (content, false);
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
}
