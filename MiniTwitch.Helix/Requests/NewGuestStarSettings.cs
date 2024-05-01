namespace MiniTwitch.Helix.Requests;

public class NewGuestStarSettings
{
    public bool? IsModeratorSendLiveEnabled { get; }
    public int? SlotCount { get; }
    public bool? IsBrowserSourceAudioEnabled { get; }
    public string? GroupLayout { get; }
    public bool? RegenerateBrowserSources { get; }

    public NewGuestStarSettings(
        bool? isModeratorSendLiveEnabled = null,
        int? slotCount = null,
        bool? isBrowserSourceAudioEnabled = null,
        string? groupLayout = null,
        bool? regenerateBrowserSources = null
    )
    {
        this.IsModeratorSendLiveEnabled = isModeratorSendLiveEnabled;
        this.SlotCount = slotCount;
        this.IsBrowserSourceAudioEnabled = isBrowserSourceAudioEnabled;
        this.GroupLayout = groupLayout;
        this.RegenerateBrowserSources = regenerateBrowserSources;
    }
}
