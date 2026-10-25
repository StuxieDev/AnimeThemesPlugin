# Changelog

All notable changes to AnimeThemes are documented here. The format is based on
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/). The plugin is pre-stable, so it uses
[Semantic Versioning](https://semver.org) on `0.x.y` for now. Its first stable release will be its
first [Date Versioning](https://datevers.ing) release (`YY.MM.DD`, the UTC release date, with `-1`,
`-2`… for later releases the same day), and every release after that will be a Date Version too.
There will be no v1.0.0. Jellyfin shows each version with a fourth part: `0.2.0` is `0.2.0.0`.
Releases before v0.2.0 were first published with other numbers; each says which.

## v0.2.0

### Added
- `tests/run.sh` checks `VERSION.md`, the newest changelog heading, the version in `Directory.Build.props` and `meta.json`, and the versioning rules below. The release workflow runs it before building.

### Changed
- The plugin is pre-stable, so it's versioned with SemVer `0.x.y` until its first stable release, which will be its first [Date Versioning](https://datevers.ing) release (there will be no v1.0.0). The earlier releases have been relabelled: v1.0.0 is now v0.1.0, and v26.10.23 is now v0.1.1. Their GitHub releases and the plugin repository now use the new numbers, with each zip rebuilt from its tag to carry its new version. `commit.sh` / `commit.bat` and the release workflow accept `0.x.y` versions as well as Date Versions, and refuse `0.x.y` once a Date Version has been released.
- In Jellyfin this release is version `0.2.0.0`. If you installed v26.10.23 (shown as `26.10.23.0`) or a 1.x release, Jellyfin sees that as the newer version and won't offer this one as an update: uninstall the plugin, restart, and install it again from the catalogue. Your settings are kept.

## v0.1.1

_Released 2026-10-23 as v26.10.23._

### Changed
- Versions now follow [Date Versioning](https://datevers.ing): the UTC release date as `YY.MM.DD`, with `-1`, `-2`… for later releases the same day. Jellyfin shows this release as `26.10.23.0` and treats it as an update from v1.0.0, so nothing needs reinstalling. `commit.sh`/`commit.bat` now refuse to tag anything that isn't a real, non-future Date Version.

## v0.1.0

_Released 2026-09-29 as v1.0.0._

First release of AnimeThemes as a standalone StuxieDev project, for Jellyfin 12.x. It is based on [jellyfin-plugin-animethemes](https://github.com/EusthEnoptEron/jellyfin-plugin-animethemes) 6.0.0 by EusthEnoptEron.

### Added
- Published from [StuxieDev/AnimeThemesPlugin](https://github.com/StuxieDev/AnimeThemesPlugin), with its own plugin ID, repository manifest and banner.

### Changed
- Built for Jellyfin 12 (.NET 10, `targetAbi` 12.0.0.0).

### Fixed
- The **Search For Anime Themes** task no longer fails straight away on Jellyfin 12. The plugin depended on `System.Linq.Async`, which Jellyfin 12 no longer ships, so every run stopped with "Could not load file or assembly 'System.Linq.Async'". It now uses .NET 10's built-in `System.Linq.AsyncEnumerable`.
