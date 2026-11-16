using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Jellyfin.Plugin.AnimeThemes.Models;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.AnimeThemes;

/// <summary>
/// Represents the AnimeThemes API.
/// </summary>
public sealed class AnimeThemesApi : IDisposable
{
    /// <summary>
    /// The GraphQL endpoint, relative to the client's base address (https://rs.animethemes.moe).
    /// The old JSON:API (https://api.animethemes.moe) is deprecated and no longer answers.
    /// </summary>
    private const string GraphQlPath = "/graphql";

    /// <summary>
    /// Finds anime by their AniDB IDs, with everything needed to pick and download themes.
    /// See https://api-docs.animethemes.moe/graphql/examples/filter-by-external-site.html.
    /// </summary>
    private const string AnimeQuery = """
        query ($site: ResourceSite!, $ids: [Int!]) {
          filterAnimeByExternalSite(site: $site, id: $ids) {
            id
            slug
            year
            title { romaji }
            resources { nodes { id externalId site } }
            themes {
              id
              type
              sequence
              slug
              group { name }
              entries {
                id
                version
                episodes
                nsfw
                spoiler
                videos {
                  nodes {
                    id
                    basename
                    filename
                    source
                    overlap
                    link
                    nc
                    audio { id path filename mimetype link }
                  }
                }
              }
            }
          }
        }
        """;

    private readonly HttpClient _client;
    private readonly ILogger<AnimeThemesDownloader> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimeThemesApi"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="clientFactory">Client factory.</param>
    public AnimeThemesApi(IHttpClientFactory clientFactory, ILogger<AnimeThemesDownloader> logger)
    {
        _logger = logger;
        _client = clientFactory.CreateClient("AnimeThemes");
    }

    /// <summary>
    /// Finds anime with all their themes by their AniDB Ids.
    /// </summary>
    /// <param name="ids">IDs on AniDB.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A dictionary with an entry for each passed <paramref name="ids"/>.</returns>
    public async ValueTask<Dictionary<int, Anime[]>> FindByAniDbId(IEnumerable<int> ids, CancellationToken cancellationToken = default)
    {
        var idList = ids.Distinct().ToArray();

        _logger.LogInformation("Looking up {Count} shows in the AnimeThemes db...", idList.Length);

        if (idList.Length > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(ids));
        }

        var request = new
        {
            query = AnimeQuery,
            variables = new { site = Sites.ANIDB, ids = idList },
        };

        _logger.LogInformation("Asking the AnimeThemes GraphQL API for AniDB IDs: {Ids}", string.Join(",", idList.Select(it => it.ToString(CultureInfo.InvariantCulture))));
        using var body = JsonContent.Create(request);
        var result = await _client.PostAsync(GraphQlPath, body, cancellationToken).ConfigureAwait(false);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        await using var contentDisposal = content.ConfigureAwait(false);

        var response = await JsonSerializer.DeserializeAsync<AnimeResponse>(content, cancellationToken: cancellationToken).ConfigureAwait(false);

        // GraphQL reports query errors in the body, with a 200 status.
        if (response?.Errors is { Count: > 0 } errors)
        {
            throw new HttpRequestException("AnimeThemes API error: " + string.Join("; ", errors.Select(e => e.Message)));
        }

        var animeByAniId = response?.Data?.Anime?.Where(a => a.AniDbId is not null).GroupBy(a => a.AniDbId!.Value).ToDictionary(a => a.Key, a => a.ToArray()) ?? new Dictionary<int, Anime[]>();

        _logger.LogInformation("Of a total of {TotalCount} shows, we were able to find entries for {FinalCount} shows", idList.Length, animeByAniId.Count);

        return idList.ToDictionary(id => id, id => animeByAniId.GetValueOrDefault(id) ?? []);
    }

    /// <summary>
    /// Disposes of the client.
    /// </summary>
    /// <param name="disposing">Whether the object is currently being disposed.</param>
    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _client.Dispose();
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
    }
}
