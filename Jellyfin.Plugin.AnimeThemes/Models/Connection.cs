using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.AnimeThemes.Models;

/// <summary>
/// A GraphQL connection: the API wraps lists such as resources and videos in <c>nodes</c>.
/// </summary>
/// <typeparam name="T">Type of the items.</typeparam>
/// <param name="Nodes">The items.</param>
public record Connection<T>(
    [property: JsonPropertyName("nodes")] Collection<T> Nodes
);
