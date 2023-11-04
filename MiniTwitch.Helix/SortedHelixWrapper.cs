using Microsoft.Extensions.Logging;
using MiniTwitch.Common;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix;

/// <summary>
/// Wraps all Helix endpoints and exposes them as methods in categories.
/// </summary>
public sealed class SortedHelixWrapper
{
    /// <summary>
    /// The default logger for <see cref="HelixWrapper"/>, only used when <see cref="ILogger"/> is not provided in the constructor
    /// <para>Can be toggled with <see cref="DefaultMiniTwitchLogger{T}.Enabled"/></para>
    /// </summary>
    public DefaultMiniTwitchLogger<HelixWrapper> DefaultLogger => this.All.ApiClient.Logger;
    /// <summary>
    /// Gets the user ID associated with this <see cref="SortedHelixWrapper"/> instance
    /// </summary>
    public long UserId { get; }
    public AllCategories All { get; }
    public AnalyticsCategory Analytics { get; }
    public BitsCategory Bits { get; }
    public ChannelPointsCategory ChannelPoints { get; }
    public ChannelsCategory Channels { get; }
    public CharityCategory Charity { get; }
    public ChatCategory Chat { get; }
    public ClipsCategory Clips { get; }
    public EntitlementsCategory Entitlements { get; }
    public EventSubCategory EventSub { get; }
    public ExtensionsCategory Extensions { get; }
    public GamesCategory Games { get; }
    public GuestStarCategory GuestStar { get; }
    public ModerationCategory Moderation { get; }
    public PollsCategory Polls { get; }
    public PredictionsCategory Predictions { get; }
    public RaidsCategory Raids { get; }
    public ScheduleCategory Schedule { get; }
    public SearchCategory Search { get; }
    public StreamsCategory Streams { get; }
    public SubscriptionsCategory Subscriptions { get; }
    public TeamsCategory Teams { get; }
    public UsersCategory Users { get; }
    public VideosCategory Videos { get; }

    public SortedHelixWrapper(
        string bearerToken, 
        long userId, 
        ILogger? logger = null,
        string helixBaseUrl = "https://api.twitch.tv/helix", 
        string tokenValidationUrl = "https://id.twitch.tv/oauth2/validate")
    {
        this.All = new(new HelixApiClient(bearerToken, userId, logger, tokenValidationUrl), helixBaseUrl);
        this.UserId = userId;
        this.Analytics = new(this.All);
        this.Bits = new(this.All);
        this.ChannelPoints = new(this.All);
        this.Channels = new(this.All);
        this.Charity = new(this.All);
        this.Chat = new(this.All);
        this.Clips = new(this.All);
        this.Entitlements = new(this.All);
        this.EventSub = new(this.All);
        this.Extensions = new(this.All);
        this.Games = new(this.All);
        this.GuestStar = new(this.All);
        this.Moderation = new(this.All);
        this.Polls = new(this.All);
        this.Predictions = new(this.All);
        this.Raids = new(this.All);
        this.Schedule = new(this.All);
        this.Search = new(this.All);
        this.Streams = new(this.All);
        this.Subscriptions = new(this.All);
        this.Teams = new(this.All);
        this.Users = new(this.All);
        this.Videos = new(this.All);
    }
}
