using System.Text;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Interfaces;
using MiniTwitch.Irc.Internal.Models;
using MiniTwitch.Irc.Internal.Parsing;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents a CLEARMSG message
/// </summary>
public readonly struct Clearmsg : IUnixTimestamped
{
    /// <inheritdoc cref="IDeletedMessageAuthor"/>
    public IDeletedMessageAuthor Target { get; init; }
    /// <summary>
    /// The channel where the event occurred
    /// </summary>
    public IGazatuChannel Channel { get; init; }
    /// <summary>
    /// Unique ID identifying the deleted message
    /// </summary>
    public string MessageId { get; init; }
    /// <summary>
    /// The content of the deleted message
    /// </summary>
    public string MessageContent { get; init; }

    /// <inheritdoc/>
    public long TmiSentTs { get; init; }
    /// <inheritdoc/>
    public DateTimeOffset SentTimestamp => DateTimeOffset.FromUnixTimeMilliseconds(this.TmiSentTs);

    internal Clearmsg(ReadOnlyMemory<byte> memory)
    {
        string targetUsername = string.Empty;
        string channelName = memory.Span.FindChannel();
        string messageId = string.Empty;
        long tmiSentTs = 0;

        using IrcTags tags = IrcParsing.ParseTags(memory);
        foreach (IrcTag tag in tags)
        {
            ReadOnlySpan<byte> tagKey = tag.Key.Span;
            ReadOnlySpan<byte> tagValue = tag.Value.Span;

            switch (tagKey.Sum())
            {
                //login
                case 537:
                    targetUsername = TagHelper.GetString(tagValue);
                    break;

                //tmi-sent-ts
                case 1093:
                    tmiSentTs = TagHelper.GetLong(tagValue);
                    break;

                //target-msg-id
                case 1269:
                    messageId = TagHelper.GetString(tagValue);
                    break;

            }
        }

        this.Target = new MessageAuthor()
        {
            Name = targetUsername
        };
        this.Channel = new IrcChannel()
        {
            Name = channelName
        };
        this.MessageId = messageId;
        this.MessageContent = memory.Span.FindContent(maybeAction: true).Content;
        this.TmiSentTs = tmiSentTs;
    }

    /// <summary>
    /// Construct a "deleted message" message from a string. Useful for testing
    /// </summary>
    /// <param name="rawData">The raw IRC message <para>Example input: @login=occluder;room-id=;target-msg-id=55dc74c9-a6b2-4443-9b68-3446a5ddb7ed;tmi-sent-ts=1678798254260 :tmi.twitch.tv CLEARMSG #occluder :frozen lol! </para></param>
    /// <returns><see cref="Clearmsg"/> with the related data</returns>
    public static Clearmsg Construct(string rawData)
    {
        ReadOnlyMemory<byte> memory = new(Encoding.UTF8.GetBytes(rawData));
        return new(memory);
    }

    /// <inheritdoc/>
    public static implicit operator string(Clearmsg clearmsg) => clearmsg.MessageContent;
}