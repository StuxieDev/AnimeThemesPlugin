using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// Represents a GraphQL response to the <c>filterAnimeByExternalSite</c> query.
/// </summary>
/// <param name="Data">The data, or null when the query failed.</param>
/// <param name="Errors">Errors, if any.</param>
public record AnimeResponse(
    [property: JsonPropertyName("data")] AnimeResponseData? Data,
    [property: JsonPropertyName("errors")] Collection<GraphQlError>? Errors
);
