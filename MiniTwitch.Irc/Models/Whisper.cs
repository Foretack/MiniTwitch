using System.Drawing;
using System.Text;
using MiniTwitch.Common.Extensions;
using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Interfaces;
using MiniTwitch.Irc.Internal.Enums;
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

    internal Whisper(IrcMessage message)
    {
        string badges = string.Empty;
        Color color = default;
        string displayName = string.Empty;
        string username = message.GetUsername();
        long uid = 0;
        UserType type = UserType.None;
        bool turbo = false;

        string emotes = string.Empty;
        int id = 0;
        string threadId = string.Empty;
        (string content, bool action) = message.GetContent(maybeAction: true);
        using IrcTags tags = message.ParseTags();
        foreach (IrcTag tag in tags)
        {
            ReadOnlySpan<byte> tagKey = tag.Key.Span;
            ReadOnlySpan<byte> tagValue = tag.Value.Span;
            switch (tagKey.Sum())
            {
                //color
                case (int)Tags.Color:
                    color = TagHelper.GetColor(tagValue);
                    break;

                //turbo
                case (int)Tags.Turbo:
                    turbo = TagHelper.GetBool(tagValue);
                    break;

                //badges
                case (int)Tags.Badges:
                    badges = TagHelper.GetString(tagValue, true);
                    break;

                //emotes
                case (int)Tags.Emotes:
                    emotes = TagHelper.GetString(tagValue);
                    break;

                //user-id
                case (int)Tags.UserId:
                    uid = TagHelper.GetLong(tagValue);
                    break;

                //thread-id
                case (int)Tags.ThreadId:
                    threadId = TagHelper.GetString(tagValue, true);
                    break;

                //user-type
                case (int)Tags.UserType when tagValue.Length > 0:
                    type = (UserType)tagValue.Sum();
                    break;

                //message-id
                case (int)Tags.MessageId:
                    id = TagHelper.GetInt(tagValue);
                    break;

                //display-name
                case (int)Tags.DisplayName:
                    displayName = TagHelper.GetString(tagValue);
                    break;
            }
        }

        this.Author = new MessageAuthor()
        {
            Badges = badges,
            ChatColor = color,
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
        return new(new IrcMessage(memory));
    }

    /// <inheritdoc/>
    public static implicit operator string(Whisper whisper) => whisper.Content;
}