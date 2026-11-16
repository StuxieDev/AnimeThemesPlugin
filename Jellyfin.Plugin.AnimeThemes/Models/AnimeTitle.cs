using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// The titles of an anime.
/// </summary>
/// <param name="Romaji">The romaji title, which the old JSON:API called <c>name</c>.</param>
public record AnimeTitle(
    [property: JsonPropertyName("romaji")] string Romaji
);
