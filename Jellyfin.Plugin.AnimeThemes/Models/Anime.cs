using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// Represents an anime. Subset of the GraphQL <c>Anime</c> type (https://api-docs.animethemes.moe/graphql/).
/// </summary>
public record Anime(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("title")] AnimeTitle Title,
    [property: JsonPropertyName("slug")] string Slug,
    [property: JsonPropertyName("year")] int? Year,
    [property: JsonPropertyName("resources")]
    Connection<Resource> Resources,
    [property: JsonPropertyName("themes")]
    Collection<AnimeTheme> Themes
)
{
    /// <summary>
    /// Gets the romaji title of this anime.
    /// </summary>
    public string Name => Title.Romaji;

    /// <summary>
    /// Gets the AniDB ID of this anime if available in payload.
    /// </summary>
    public int? AniDbId => Resources.Nodes.FirstOrDefault(it => it.Site == Sites.ANIDB && it.ExternalId is not null)?.ExternalId;
}
