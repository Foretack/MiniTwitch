This changelog is available at: https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Irc/CHANGELOG.md

# MiniTwitch.Irc Changelog

## 1.2.16

### Minor changes
- `IrcClient` now has the property `IsConnected` for checking whether the underlying WebSocket is connected
- Added support for gigantified emote and animated message tags
- Added `Msg_warned` to `NoticeType` enum

***

## 1.2.13

### Minor changes

- Added support for `msg-param-community-gift-id` tag for gift usernotice

***

## 1.2.11

### Minor changes

- Added `CustomRewardId` property to privmsg struct

***

## 1.2.10

### Minor changes

- Updated logging strings for joining suspended/renamed/disabled/deleted channels

### Dev

- Changed internal tag values to match `ReadOnlySpan<byte>.MSum()` rather than `.Sum()`. Usages of the latter were also switched
- Tag values of Hype Chat have been removed