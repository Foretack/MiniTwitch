# MiniTwitch.PubSub Changelog

## Upcoming version

### Fixes

- Updated authentication comment for `following.{id}` topic

### Dev

- Changed internal messagetopic & topicinfo values to match `ReadOnlySpan<byte>.MSum()` rather than `.Sum()`. Usages of the latter were also switched
- Removed unused hypetrain topic from messagetopic
