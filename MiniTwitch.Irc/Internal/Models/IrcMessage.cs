using System.Runtime.CompilerServices;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Internal.Enums;
using MiniTwitch.Irc.Internal.Parsing;

namespace MiniTwitch.Irc.Internal.Models;

internal readonly ref struct IrcMessage
{
    public readonly bool HasTags { get; init; } = default;
    public readonly Range TagsRange { get; init; } = default;
    public readonly bool HasUsername { get; init; } = default;
    public readonly Range UsernameRange { get; init; } = default;
    public readonly IrcCommand Command { get; init; } = default;
    public readonly bool IsGlobalChannel { get; init; } = default;
    public readonly Range ChannelRange { get; init; } = default;
    public readonly bool HasMessageContent { get; init; } = default;
    public readonly Range MessageContentRange { get; init; } = default;
    public readonly bool IsMultipleMessages { get; init; } = default;
    public readonly int NextMessageStartIndex { get; init; } = default;
    public readonly ReadOnlyMemory<byte> Memory { get; init; } = default;

    public IrcMessage(ReadOnlyMemory<byte> memory)
    {
        const byte colon = (byte)':';
        const byte at = (byte)'@';
        const byte space = (byte)' ';
        const byte excl = (byte)'!';
        const byte asterisk = (byte)'*';
        const byte cr = (byte)'\r';

        ReadOnlySpan<byte> span = memory.Span;
        this.Memory = memory;
        switch (span[0])
        {
            case at:
                this.HasTags = true;
                // <tags> :foo!foo@foo.tmi.twitch.tv PRIVMSG #bar :asdf
                // ----->|
                this.TagsRange = 1..span.IndexOf(space);
                int usernameStart = this.TagsRange.End.Value + 2;

            AfterUsernameStart:

                // <tags> :foo!foo@foo.tmi.twitch.tv PRIVMSG #bar :asdf
                //         -->|
                int usernameEnd = span[usernameStart..].IndexOf(excl) + usernameStart;
                if (usernameEnd - usernameStart is not -1 and not > 25)
                {
                    this.HasUsername = true;
                    this.UsernameRange = usernameStart..usernameEnd;
                }

                int commandStartAddVal = this.HasUsername ? usernameEnd : usernameStart;
                int commandStart = span[commandStartAddVal..].IndexOf(space) + commandStartAddVal + 1;
                int commandEnd = span[commandStart..].IndexOf(space) + commandStart;
                if (commandEnd - commandStart == -1)
                {
                    this.Command = (IrcCommand)span[commandStart..span.Length].Sum();
                    return;
                }

                this.Command = (IrcCommand)span[commandStart..commandEnd].Sum();
                int contentStart;
                if (span[commandEnd + 1] == asterisk)
                {
                    this.IsGlobalChannel = true;
                    contentStart = commandEnd + 4;
                }
                else
                {
                    int channelStart = commandEnd + 2;
                    int channelEnd = span[channelStart..].IndexOfAny(space, cr) + channelStart;
                    if (channelEnd - channelStart == -1)
                    {
                        this.ChannelRange = channelStart..span.Length;
                        return;
                    }

                    this.ChannelRange = channelStart..channelEnd;
                    if (span[channelEnd] == cr)
                    {
                        this.IsMultipleMessages = true;
                        this.NextMessageStartIndex = channelEnd + 2;
                        return;
                    }

                    contentStart = channelEnd + 2;
                }

                // Didn't end at channel so there must be content
                this.HasMessageContent = true;
                int contentEnd = span[contentStart..].IndexOf(cr) + contentStart;
                if (contentEnd - contentStart == -1)
                {
                    this.MessageContentRange = contentStart..span.Length;
                    return;
                }

                this.MessageContentRange = contentStart..contentEnd;
                if (span.Length > contentEnd + 1)
                {
                    this.IsMultipleMessages = true;
                    this.NextMessageStartIndex = contentEnd + 2;
                }
                break;

            case colon:
                usernameStart = 1;
                goto AfterUsernameStart;

            default:
                commandStart = 0;
                commandEnd = span.IndexOf(space);
                this.Command = (IrcCommand)span[commandStart..commandEnd].Sum();
                int crIndex = span[commandEnd..].IndexOf(cr) + commandEnd;
                if (crIndex - commandEnd != -1)
                {
                    this.IsMultipleMessages = true;
                    this.NextMessageStartIndex = crIndex + 2;
                }

                break;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string GetChannel() => TagHelper.GetString(this.Memory.Span[this.ChannelRange], true);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly string GetUsername() => TagHelper.GetString(this.Memory.Span[this.UsernameRange]);

    public readonly (string Content, bool Action) GetContent(bool maybeAction = false)
    {
        if (!this.HasMessageContent)
            return (string.Empty, false);

        string content = TagHelper.GetString(this.Memory.Span[this.MessageContentRange]);
        if (maybeAction && content.Length > 9 && content[0] == '\u0001' && content[^1] == '\u0001')
            return (content[8..^1], true);

        return (content, false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly IrcTags ParseTags()
    {
        const byte semiColon = (byte)';';
        const byte equals = (byte)'=';

        ReadOnlySpan<byte> span = this.Memory.Span;
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
        Index tagsEndIndex = this.TagsRange.End;
        Index tagStart = this.TagsRange.Start;
        Index tagEquals;
        Index tagEnd;

        for (int i = 0; i < tagCount; i++)
        {
            if (tagStart.Value >= tagsEndIndex.Value)
                break;

            // Index of '=' from the start of the tag
            tagEquals = span[tagStart..tagsEndIndex].IndexOf(equals) + tagStart.Value;
            if (tagEquals.Value == tagStart.Value - 1)
                break;

            // Index of ';' from the equal sign of the tag
            tagEnd = span[tagEquals..tagsEndIndex].IndexOf(semiColon) + tagEquals.Value;
            // Account for last tag, which doesn't end with a semicolon
            if (tagEnd.Value == tagEquals.Value - 1)
                tagEnd = tagsEndIndex;

            // Key memory slice: from index 0 until the next equal sign
            // Value memory slice: from index 0 after the equal sign until next semicolon
            tags.Add(i, this.Memory[tagStart..tagEquals], this.Memory[(tagEquals.Value + 1)..tagEnd]);
            tagStart = tagEnd.Value + 1;
        }

        return tags;
    }
}
