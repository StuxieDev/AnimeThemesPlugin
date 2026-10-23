<p align="center">
  <img src="assets/logo.svg" alt="AnimeThemes logo" width="128">
</p>

# AnimeThemes – Jellyfin Plugin

Fetches anime openings and endings (OPs and EDs) from [animethemes.moe](https://animethemes.moe) and saves them as theme songs or theme videos, so they play in the background while you browse a show in [Jellyfin](https://jellyfin.org/).

Built for **Jellyfin 12**.

**Themes are matched by AniDB ID, so you need the AniDB metadata plugin. Items without an AniDB ID are skipped.**

## Installation

Add the plugin repository in Jellyfin under **Dashboard → Plugins → Repositories → +** :

```
https://github.com/StuxieDev/AnimeThemesPlugin/releases/latest/download/manifest.json
```

Then install **AnimeThemes** from the plugin catalogue and restart Jellyfin.

**Moving from EusthEnoptEron's AnimeThemes plugin:** uninstall it first, then install this one and restart. Both use the same settings file, so your settings carry over. This plugin has its own plugin ID, so the other plugin's repository can't "update" over it.

### Requirements

- Jellyfin 12.0 or newer
- The [AniDB](https://github.com/jellyfin/jellyfin-plugin-anidb) metadata plugin

## How to use

The plugin adds a **Search For Anime Themes** scheduled task, which runs every 6 hours by default. Make sure theme music and theme videos are turned on in your display settings.

## Configuration

| Configuration                           | Description                                                                                               |
|-----------------------------------------|-----------------------------------------------------------------------------------------------------------|
| Degree of parallelism                   | How many items should be downloaded in parallel. Default is set to 1 to go easy on the servers.           |
| Ignore themes that overlap with episode | Some shows transition into their themes. Use this setting to filter those themes out.                     |
| Ignore themes with credits              | Whether to skip themes with credits in them. Useful for video downloads.                                  |
| Ignore OP themes                        | Use this to control whether OPs are considered.                                                           |
| Ignore ED themes                        | Use this to control whether EDs are considered.                                                           |
| Fetch type                              | Determines if you want all distinct themes, only the best match, or none at all.                          |
| Volume                                  | The desired volume, which will be baked in. For videos, 0 will result in the audio channel being removed. |

## Other notes

If you want the videos to cover the whole screen, try the following CSS:

```css
body:not(.hide-scroll) > .videoPlayerContainer > video {
    object-fit: cover;
}
```

## Build from source

```bash
dotnet build Jellyfin.Plugin.AnimeThemes/Jellyfin.Plugin.AnimeThemes.csproj -c Release
```

See [CONTRIBUTING.md](CONTRIBUTING.md) for development and release details.

## Credits

Based on [jellyfin-plugin-animethemes](https://github.com/EusthEnoptEron/jellyfin-plugin-animethemes) by EusthEnoptEron. Maintained by [StuxieDev](https://github.com/StuxieDev) as a standalone project, ported to Jellyfin 12. Themes come from [animethemes.moe](https://animethemes.moe).

© Leo Ridgwell (StuxieDev) for changes made since the original. Licensed under the [GNU General Public License v3.0](LICENSE.md), like the code it's based on.
