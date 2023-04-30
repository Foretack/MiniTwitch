using System.Text;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Interfaces;
using MiniTwitch.Irc.Internal.Models;
using MiniTwitch.Irc.Internal.Parsing;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents a whispered message
/// </summary>
public readonly struct Whisper
{
    /// <summary>
    /// The author of the whisper
    /// </summary>
    public IWhisperAuthor Author { get; init; }
    /// <inheritdoc cref="Privmsg.Emotes"/>
    public string Emotes { get; init; }
    /// <inheritdoc cref="Privmsg.Id"/>
    public int Id { get; init; }
    /// <summary>
    /// The index of the message
    /// </summary>
    public string ThreadId { get; init; }
    /// <summary>
    /// The content of the message
    /// </summary>
    public string Content { get; init; }
    /// <summary>
    /// <inheritdoc cref="Privmsg.IsAction"/>
    /// </summary>
    public bool IsAction { get; init; }

    internal Whisper(ReadOnlyMemory<byte> memory)
    {
        string badges = string.Empty;
        string color = string.Empty;
        string displayName = string.Empty;
        string username = memory.Span.FindUsername();
        long uid = 0;
        UserType type = UserType.None;
        bool turbo = false;

        string emotes = string.Empty;
        int id = 0;
        string threadId = string.Empty;
        (string content, bool action) = memory.Span.FindContent(maybeAction: true);

        using IrcTags tags = IrcParsing.ParseTags(memory);
        foreach (IrcTag tag in tags)
        {
            ReadOnlySpan<byte> tagKey = tag.Key.Span;
            ReadOnlySpan<byte> tagValue = tag.Value.Span;
            switch (tagKey.Sum())
            {
                //color
                case 543:
                    color = TagHelper.GetString(tagValue, true);
                    break;

                //turbo
                case 556:
                    turbo = TagHelper.GetBool(tagValue);
                    break;

                //badges
                case 614:
                    badges = TagHelper.GetString(tagValue, true);
                    break;

                //emotes
                case 653:
                    emotes = TagHelper.GetString(tagValue);
                    break;

                //user-id
                case 697:
                    uid = TagHelper.GetLong(tagValue);
                    break;

                //thread-id
                case 882:
                    threadId = TagHelper.GetString(tagValue, true);
                    break;

                //user-type
                case 942 when tagValue.Length > 0:
                    type = (UserType)tagValue.Sum();
                    break;

                //message-id
                case 991:
                    id = TagHelper.GetInt(tagValue);
                    break;

                //display-name
                case 1220:
                    displayName = TagHelper.GetString(tagValue);
                    break;
            }
        }

        this.Author = new MessageAuthor()
        {
            Badges = badges,
            ColorCode = color,
            DisplayName = displayName,
            Name = username,
            Id = uid,
            Type = type,
            IsTurbo = turbo
        };
        this.Emotes = emotes;
        this.Id = id;
        this.ThreadId = threadId;
        this.Content = content;
        this.IsAction = action;
    }

    /// <summary>
    /// Construct a <see cref="Whisper"/> from a string. Useful for testing
    /// </summary>
    /// <param name="rawData">The raw IRC message</param>
    /// <returns><see cref="Whisper"/> with the related data</returns>
    public static Whisper Construct(string rawData)
    {
        ReadOnlyMemory<byte> memory = new(Encoding.UTF8.GetBytes(rawData));
        return new(memory);
    }

    /// <inheritdoc/>
    public static implicit operator string(Whisper whisper) => whisper.Content;
}