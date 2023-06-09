﻿using System.Text;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Interfaces;
using MiniTwitch.Irc.Internal.Models;
using MiniTwitch.Irc.Internal.Parsing;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents a CLEARCHAT message
/// </summary>
public readonly struct Clearchat : IUserTimeout, IUserBan, IChatClear
{
    /// <summary>
    /// Duration of the timeout
    /// </summary>
    public TimeSpan Duration { get; init; }
    /// <inheritdoc/>
    public IBanTarget Target { get; init; }
    /// <summary>
    /// The channel where the event occurred
    /// </summary>
    public IBasicChannel Channel { get; init; }

    /// <inheritdoc/>
    public long TmiSentTs { get; init; }
    /// <inheritdoc/>
    public DateTimeOffset SentTimestamp => DateTimeOffset.FromUnixTimeMilliseconds(this.TmiSentTs);

    internal bool IsClearChat { get; init; }
    internal bool IsBan { get; init; }

    internal Clearchat(ReadOnlyMemory<byte> memory)
    {
        int duration = 0;
        long targetId = 0;
        long channelId = 0;

        long tmiSentTs = 0;

        using IrcTags tags = IrcParsing.ParseTags(memory);
        foreach (IrcTag tag in tags)
        {
            ReadOnlySpan<byte> tagKey = tag.Key.Span;
            ReadOnlySpan<byte> tagValue = tag.Value.Span;

            switch (tagKey.Sum())
            {
                //room-id
                case 695:
                    channelId = TagHelper.GetLong(tagValue);
                    break;

                //tmi-sent-ts
                case 1093:
                    tmiSentTs = TagHelper.GetLong(tagValue);
                    break;

                //ban-duration
                case 1220:
                    duration = TagHelper.GetInt(tagValue);
                    break;

                //target-user-id
                case 1389:
                    targetId = TagHelper.GetLong(tagValue);
                    break;
            }
        }

        this.Duration = duration == 0 ? TimeSpan.Zero : TimeSpan.FromSeconds(duration);
        this.Target = new MessageAuthor()
        {
            Name = memory.Span.FindContent().Content,
            Id = targetId
        };
        this.Channel = new IrcChannel()
        {
            Name = memory.Span.FindChannel(),
            Id = channelId
        };
        this.TmiSentTs = tmiSentTs;
        this.IsClearChat = targetId == 0;
        this.IsBan = duration == 0;
    }

    /// <summary>
    /// Construct a timeout or ban from a string. Useful for testing
    /// </summary>
    /// <param name="rawData">The raw IRC message <para>Example input: <c></c>@badge-info=subscriber/10;badges=subscriber/6;color=#F2647B;display-name=occluder;emotes=;first-msg=0;flags=;id=5adf1e72-72b1-46c1-99df-eca4bf90120f;mod=0;returning-chatter=0;room-id=11148817;subscriber=1;tmi-sent-ts=1679785255155;turbo=0;user-id=783267696;user-type= :occluder!occluder@occluder.tmi.twitch.tv PRIVMSG #pajlada :!vanish</para></param>
    /// <returns><see cref="Clearchat"/> with the related data</returns>
    public static Clearchat Construct(string rawData)
    {
        ReadOnlyMemory<byte> memory = new(Encoding.UTF8.GetBytes(rawData));
        return new(memory);
    }
}
