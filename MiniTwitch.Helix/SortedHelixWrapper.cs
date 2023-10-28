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
        Analytics = new(All);
        Bits = new(All);
        ChannelPoints = new(All);
        Channels = new(All);
        Charity = new(All);
        Chat = new(All);
        Clips = new(All);
        Entitlements = new(All);
        Eventsub = new(All);
        Extensions = new(All);
        Games = new(All);
        GuestStar = new(All);
        Moderation = new(All);
        Polls = new(All);
        Predictions = new(All);
        Raids = new(All);
        Schedule = new(All);
        Search = new(All);
        Streams = new(All);
        Subscriptions = new(All);
        Teams = new(All);
        Users = new(All);
        Videos = new(All);
    }
}
