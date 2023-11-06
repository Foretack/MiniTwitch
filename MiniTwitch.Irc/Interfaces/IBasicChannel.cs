using MiniTwitch.Common.Interaction;

namespace MiniTwitch.Irc.Interfaces;

/// <summary>
/// Contains the name and ID of a channel
/// </summary>
public interface IBasicChannel : IHelixChannelTarget
{
    /// <summary>
    /// The channel's username
    /// </summary>
    string Name { get; }
    /// <summary>
    /// The channel's ID
    /// </summary>
    new long Id { get; }
}
