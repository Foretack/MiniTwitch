namespace MiniTwitch.PubSub.Internal.Enums;

internal enum MessageTopic
{
    None,
    Polls = 554,
    Following = 977,
    AutomodQueue = 1355,
    LowTrustUsers = 1568,
    ChatroomsUser = 1680,
    VideoPlayback = 1933,
    HypeTrainEvents = 1943,
    PinnedChatUpdates = 2114,
    BitsEventsV1 = 2126,
    BitsEventsV2 = 2127,
    ChannelPredictions = 2174,
    ModeratorActions = 2332,
    ChannelPoints = 2429,
    BroadcastSettingsUpdate = 2561,
    BitsBadgeUnlock = 2564,
    SubscribeEvents = 2654,
    CommunityChannelPoints = 2697,
    CommunityMoments = 2799,
    ModerationNotifications = 3013,
}
