using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// A GraphQL error.
/// </summary>
/// <param name="Message">The error message.</param>
public record GraphQlError(
    [property: JsonPropertyName("message")] string Message
);
