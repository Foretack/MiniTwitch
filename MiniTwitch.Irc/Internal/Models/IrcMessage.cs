using System;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Internal.Enums;

namespace MiniTwitch.Irc.Internal.Models;

internal ref struct IrcMessage
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
    public readonly ReadOnlySpan<byte> Span { get; init; } = default;
    public readonly ReadOnlyMemory<byte> Memory { get; init; } = default;

    private static readonly Range _zeroRange = Range.EndAt(0);

    public IrcMessage(ReadOnlyMemory<byte> memory)
    {
        const byte colon = (byte)':';
        const byte at = (byte)'@';
        const byte space = (byte)' ';
        const byte excl = (byte)'!';
        const byte asterisk = (byte)'*';
        const byte cr = (byte)'\r';

        this.Span = memory.Span;
        this.Memory = memory;
        switch (Span[0])
        {
            case at:
                this.HasTags = true;
                // <tags> :foo!foo@foo.tmi.twitch.tv PRIVMSG #bar :asdf
                // ----->|
                this.TagsRange = 1..this.Span.IndexOf(space);
                int usernameStart = this.TagsRange.End.Value + 2;

            AfterUsernameStart:

                // <tags> :foo!foo@foo.tmi.twitch.tv PRIVMSG #bar :asdf
                //         -->|
                int usernameEnd = this.Span[usernameStart..].IndexOf(excl) + usernameStart;
                if (usernameEnd - usernameStart is -1 or > 25)
                {
                    this.UsernameRange = _zeroRange;
                }
                else
                {
                    this.HasUsername = true;
                    this.UsernameRange = usernameStart..usernameEnd;
                }

                int commandStartAddVal = this.HasUsername ? usernameEnd : usernameStart;
                int commandStart = this.Span[commandStartAddVal++..].IndexOf(space) + commandStartAddVal;
                int commandEnd = this.Span[commandStart..].IndexOf(space) + commandStart;
                if (commandEnd - commandStart == -1)
                {
                    this.Command = (IrcCommand)this.Span[commandStart..this.Span.Length].Sum();
                    return;
                }

                this.Command = (IrcCommand)this.Span[commandStart..commandEnd].Sum();
                int contentStart;
                if (this.Span[commandEnd + 1] == asterisk)
                {
                    this.IsGlobalChannel = true;
                    this.ChannelRange = _zeroRange;
                    contentStart = commandEnd + 4;
                }
                else
                {
                    int channelStart = commandEnd + 2;
                    int channelEnd = this.Span[channelStart..].IndexOfAny(stackalloc byte[] { space, cr }) + channelStart;
                    if (channelEnd - channelStart == -1)
                    {
                        this.ChannelRange = channelStart..this.Span.Length;
                        return;
                    }

                    this.ChannelRange = channelStart..channelEnd;
                    contentStart = channelEnd + 2;
                }

                // Didn't end at channel so there must be content
                this.HasMessageContent = true;
                int contentEnd = this.Span[contentStart..].IndexOf(cr) + contentStart;
                if (contentEnd - contentStart == -1)
                {
                    this.MessageContentRange = contentStart..this.Span.Length;
                    return;
                }

                this.MessageContentRange = contentStart..contentEnd;
                if (this.Span.Length > contentEnd + 1)
                {
                    this.IsMultipleMessages = true;
                    this.NextMessageStartIndex = contentEnd + 3;
                }
                break;

            case colon:
                this.TagsRange = _zeroRange;
                usernameStart = 1;
                goto AfterUsernameStart;

            default:
                commandStart = 0;
                commandEnd = this.Span.IndexOf(space);
                this.Command = (IrcCommand)this.Span[commandStart..commandEnd].Sum();
                break;
        }
    }
}
