using MiniTwitch.Helix.Internal.Interfaces;

namespace MiniTwitch.Helix.Requests;

public readonly struct UpdateChannelGuestStarSettingsBody : IJsonObject
{
    public bool IsModeratorSendLiveEnabled { get; init; }
    public int SlotCount { get; init; }
    public bool IsBrowserSourceAudioEnabled { get; init; }
    public string GroupLayout { get; init; }
    public bool RegenerateBrowserSources { get; init; }

    object IJsonObject.ToJsonObject() => new
    {
        is_moderator_send_live_enabled = IsModeratorSendLiveEnabled,
        slot_count = SlotCount,
        is_browser_source_audio_enabled = IsBrowserSourceAudioEnabled,
        group_layout = GroupLayout,
        regenerate_browser_sources = RegenerateBrowserSources
    };
}
