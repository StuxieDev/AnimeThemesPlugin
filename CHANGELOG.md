# Changelog

All notable changes to AnimeThemes are documented here. The format is based on
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and since v26.10.23 this
project uses [Date Versioning](https://datevers.ing) (`YY.MM.DD`, the UTC release date, with
`-1`, `-2`… for later releases the same day); earlier releases used Semantic Versioning.

## v26.10.23

### Changed
- Versions now follow [Date Versioning](https://datevers.ing): the UTC release date as `YY.MM.DD`, with `-1`, `-2`… for later releases the same day. Jellyfin shows this release as `26.10.23.0` and treats it as an update from v1.0.0, so nothing needs reinstalling. `commit.sh`/`commit.bat` now refuse to tag anything that isn't a real, non-future Date Version.

## v1.0.0

First release of AnimeThemes as a standalone StuxieDev project, for Jellyfin 12.x. It is based on [jellyfin-plugin-animethemes](https://github.com/EusthEnoptEron/jellyfin-plugin-animethemes) 6.0.0 by EusthEnoptEron.

### Added
- Published from [StuxieDev/AnimeThemesPlugin](https://github.com/StuxieDev/AnimeThemesPlugin), with its own plugin ID, repository manifest and banner.

### Changed
- Built for Jellyfin 12 (.NET 10, `targetAbi` 12.0.0.0).

### Fixed
- The **Search For Anime Themes** task no longer fails straight away on Jellyfin 12. The plugin depended on `System.Linq.Async`, which Jellyfin 12 no longer ships, so every run stopped with "Could not load file or assembly 'System.Linq.Async'". It now uses .NET 10's built-in `System.Linq.AsyncEnumerable`.
