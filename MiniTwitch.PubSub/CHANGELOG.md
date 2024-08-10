# MiniTwitch.PubSub Changelog

## 1.0.4

### Minor changes
- `PubSubClient` now has the property `IsConnected` for checking whether the underlying WebSocket is connected

***

## 1.0.3

### Minor changes

- Updated authentication comment for `following.{id}` topic

### Dev

- Changed internal messagetopic & topicinfo values to match `ReadOnlySpan<byte>.MSum()` rather than `.Sum()`. Usages of the latter were also switched
- Removed unused hypetrain topic from messagetopic
