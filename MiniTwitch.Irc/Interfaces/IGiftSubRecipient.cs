using MiniTwitch.Common.Interaction;
using MiniTwitch.Irc.Models;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Represents a user that received a gift sub
/// </summary>
public interface IGiftSubRecipient : IHelixUserTarget
{
    /// <inheritdoc cref="MessageAuthor.Name"/>
    string Name { get; }
    /// <inheritdoc cref="MessageAuthor.DisplayName"/>
    string DisplayName { get; }
    /// <inheritdoc cref="MessageAuthor.Id"/>
    new long Id { get; }
}
