using System.Text.Json.Serialization;

namespace MiniTwitch.PubSub.Payloads;

/// <summary>
/// Contains information about a "moments" event
/// </summary>
public readonly struct CommunityMoments
{
    /// <summary>
    /// Event information
    /// </summary>
    [JsonPropertyName("data")]
    public MomentData Data { get; init; }

    ///
    public readonly struct MomentData
    {
        /// <summary>
        /// Unique ID for the event
        /// </summary>
        [JsonPropertyName("moment_id")]
        public string MomentId { get; init; }
        /// <summary>
        /// ID of the channel where the event took place
        /// </summary>
        [JsonPropertyName("channel_id")]
        public long ChannelId { get; init; }
        /// <summary>
        /// Slug of the clip url that happened within the "moment" event
        /// </summary>
        [JsonPropertyName("clip_slug")]
        public string ClipSlug { get; init; }
        /// <summary>
        /// Url of the "moment" event clip
        /// </summary>
        public string GetClipUrl => $"https://clips.twitch.tv/{ClipSlug}";
    }
}
