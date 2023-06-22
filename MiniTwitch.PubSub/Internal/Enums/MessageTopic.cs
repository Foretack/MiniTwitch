namespace MiniTwitch.PubSub.Internal.Enums;

internal enum MessageTopic
{
    None,
    BitsEventsV1 = 99 + 104 + 97 + 110 + 110 + 101 + 108 + 45 + 98 + 105 + 116 + 115 + 45 + 101 + 118 + 101 + 110 + 116 + 115 + 45 + 118 + 49,
    BitsEventsV2 = 99 + 104 + 97 + 110 + 110 + 101 + 108 + 45 + 98 + 105 + 116 + 115 + 45 + 101 + 118 + 101 + 110 + 116 + 115 + 45 + 118 + 50,
    BitsBadgeUnlock = 99 + 104 + 97 + 110 + 110 + 101 + 108 + 45 + 98 + 105 + 116 + 115 + 45 + 98 + 97 + 100 + 103 + 101 + 45 + 117 + 110 + 108 + 111 + 99 + 107 + 115,
    ChannelPoints = 99 + 104 + 97 + 110 + 110 + 101 + 108 + 45 + 112 + 111 + 105 + 110 + 116 + 115 + 45 + 99 + 104 + 97 + 110 + 110 + 101 + 108 + 45 + 118 + 49,
    SubscribeEvents = 99 + 104 + 97 + 110 + 110 + 101 + 108 + 45 + 115 + 117 + 98 + 115 + 99 + 114 + 105 + 98 + 101 + 45 + 101 + 118 + 101 + 110 + 116 + 115 + 45 + 118 + 49,
    AutomodQueue = 1355,
    //Whispers = 853,
    LowTrustUsers = 1568,
    ChatroomsUser = 1680,
    ChannelPredictions = 2174,
    ModeratorActions = 2332,
    ModerationNotifications = 3013,
}
