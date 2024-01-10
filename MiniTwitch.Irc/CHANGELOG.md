# MiniTwitch.Irc Changelog

## 1.2.10

### Minor changes

- Updated logging strings for joining suspended/renamed/disabled/deleted channels

### Dev

- Changed internal tag values to match `ReadOnlySpan<byte>.MSum()` rather than `.Sum()`. Usages of the latter were also switched
- Tag values of Hype Chat have been removed