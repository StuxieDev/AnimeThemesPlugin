using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// A theme group, used to tell apart sequences for dubs, rebroadcasts and so on.
/// </summary>
/// <param name="Name">The name of the group.</param>
public record ThemeGroup(
    [property: JsonPropertyName("name")] string Name
);
