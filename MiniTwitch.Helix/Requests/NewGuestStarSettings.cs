namespace MiniTwitch.Helix.Requests;

public readonly struct NewGuestStarSettings
{
    public bool? IsModeratorSendLiveEnabled { get; init; }
    public int? SlotCount { get; init; }
    public bool? IsBrowserSourceAudioEnabled { get; init; }
    public string? GroupLayout { get; init; }
    public bool? RegenerateBrowserSources { get; init; }
}
