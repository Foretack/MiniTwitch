This changelog is available at: https://github.com/Foretack/MiniTwitch/blob/master/MiniTwitch.Helix/CHANGELOG.md

# MiniTwitch.Helix Changelog

## Upcoming version

### Breaking changes
- `SortedHelixWrapper` has been removed

### Minor Changes
- Changing the token of `HelixWrapper` is now possible through `HelixWrapper.Client.ChangeToken()`

### Fixes
- Fixed an exception that occurs when empty strings are provided to SnakeCase.ConvertToCase

## 0.3.0-prerelease

### Minor changes
- Added `Get User Emotes` endpoint (#83)
- Added Conduit endpoints (#87)
- Added `Get Unban Requests` endpoint (#91)
- Added `Resolve Unban Requests` endpoint (#93)

### Fixes
- Fixed NullReferenceException when attempting to validate certain token types

### Development changes
- Updated naming policy used for (de)serialization

****

## 0.2.3-prerelease

### Minor changes

- Added "Send Chat Message" endpoint

****

## 0.2.2-prerelease

### Minor changes

- Added "Get Moderated Channels" endpoint
- Added a semaphore lock to token validation to ensure consistency

### Fixes

- [Updated "Get Ad Schedule" response](https://dev.twitch.tv/docs/change-log/#:~:text=2023%E2%80%9112%E2%80%9111)