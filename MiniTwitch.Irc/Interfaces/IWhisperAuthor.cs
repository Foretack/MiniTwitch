using System.Drawing;
using MiniTwitch.Common.Interaction;
using MiniTwitch.Irc.Enums;
using MiniTwitch.Irc.Models;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains information about the author of a whisper
/// </summary>
public interface IWhisperAuthor : IHelixUserTarget
{
    /// <inheritdoc cref="MessageAuthor.Badges"/>
    string Badges { get; }
    /// <inheritdoc cref="MessageAuthor.ChatColor"/>
    Color ChatColor { get; }
    /// <inheritdoc cref="MessageAuthor.DisplayName"/>
    string DisplayName { get; }
    /// <inheritdoc cref="MessageAuthor.Name"/>
    string Name { get; }
    /// <inheritdoc cref="MessageAuthor.Id"/>
    new long Id { get; }
    /// <inheritdoc cref="MessageAuthor.Type"/>
    UserType Type { get; }
    /// <inheritdoc cref="MessageAuthor.IsTurbo"/>
    bool IsTurbo { get; }
}
