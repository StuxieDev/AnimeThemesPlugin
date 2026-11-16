using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// Represents an external resource (the GraphQL <c>ExternalResource</c> type).
///
/// For site types, see <see cref="Sites"/>.
/// </summary>
public record Resource(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("externalId")]
    int? ExternalId,
    [property: JsonPropertyName("site")] string Site
);
