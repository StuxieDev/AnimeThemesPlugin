# Changelog

All notable changes to AnimeThemes are documented here. The format is based on
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project
adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## v1.0.0

First release of AnimeThemes as a standalone StuxieDev project, for Jellyfin 12.x. It is based on [jellyfin-plugin-animethemes](https://github.com/EusthEnoptEron/jellyfin-plugin-animethemes) 6.0.0 by EusthEnoptEron.

### Added
- Published from [StuxieDev/AnimeThemesPlugin](https://github.com/StuxieDev/AnimeThemesPlugin), with its own plugin ID, repository manifest and banner.

### Changed
- Built for Jellyfin 12 (.NET 10, `targetAbi` 12.0.0.0).

### Fixed
- The **Search For Anime Themes** task no longer fails straight away on Jellyfin 12. The plugin depended on `System.Linq.Async`, which Jellyfin 12 no longer ships, so every run stopped with "Could not load file or assembly 'System.Linq.Async'". It now uses .NET 10's built-in `System.Linq.AsyncEnumerable`.
