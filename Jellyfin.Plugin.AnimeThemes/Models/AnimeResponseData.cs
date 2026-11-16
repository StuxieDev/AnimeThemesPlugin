using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// The data of an <see cref="AnimeResponse"/>.
/// </summary>
/// <param name="Anime">List of found anime.</param>
public record AnimeResponseData(
    [property: JsonPropertyName("filterAnimeByExternalSite")] Collection<Anime>? Anime
);
