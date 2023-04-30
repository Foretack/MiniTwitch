namespace MiniTwitch.Irc.Internal.Enums;

internal enum UsernoticeType
{
    None,
    Sub = 330,
    Resub = 545,
    Subgift = 756,
    SubMysteryGift = 1553,
    GiftPaidUpgrade = 1584,
    [Obsolete("Unused")] RewardGift,
    AnonGiftPaidUpgrade = 2012,
    Raid = 416,
    Unraid = 643,
    [Obsolete("Unused")] Ritual,
    BitsBadgeTier = 1369,
    Announcement = 1291,
    PrimePaidUpgrade = 1699,
    StandardPayForward = 1936
}