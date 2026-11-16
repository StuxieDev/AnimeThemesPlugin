using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// Types of overlap between episode and theme (the GraphQL <c>VideoOverlap</c> enum).
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<OverlapType>))]
public enum OverlapType
{
    /// <summary>
    /// No overlap.
    /// </summary>
    [JsonStringEnumMemberName("NONE")]
    None,

    /// <summary>
    /// Some overlap.
    /// </summary>
    [JsonStringEnumMemberName("TRANS")]
    Transition,

    /// <summary>
    /// Complete overlap.
    /// </summary>
    [JsonStringEnumMemberName("OVER")]
    Over
}
