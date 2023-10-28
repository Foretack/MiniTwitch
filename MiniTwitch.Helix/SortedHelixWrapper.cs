using Microsoft.Extensions.Logging;
using MiniTwitch.Helix.Internal;
using MiniTwitch.Helix.Models;

namespace MiniTwitch.Helix;

public sealed class SortedHelixWrapper
{
    public AllCategories All { get; }
    public AnalyticsCategory Analytics { get; }
    public BitsCategory Bits { get; }
    public ChannelPointsCategory ChannelPoints { get; }
    public ChannelsCategory Channels { get; }
    public CharityCategory Charity { get; }
    public ChatCategory Chat { get; }
    public ClipsCategory Clips { get; }
    public EntitlementsCategory Entitlements { get; }
    public EventsubCategory Eventsub { get; }
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

    public SortedHelixWrapper(string bearerToken, string clientId, ILogger? logger = null,
        string helixBaseUrl = "https://api.twitch.tv/helix", string tokenValidationUrl = "https://id.twitch.tv/oauth2/validate")
    {
        this.All = new(new HelixApiClient(bearerToken, clientId, logger, tokenValidationUrl), helixBaseUrl);
        this.Analytics = new(this.All);
        this.Bits = new(this.All);
        this.ChannelPoints = new(this.All);
        this.Channels = new(this.All);
        this.Charity = new(this.All);
        this.Chat = new(this.All);
        this.Clips = new(this.All);
        this.Entitlements = new(this.All);
        this.Eventsub = new(this.All);
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
