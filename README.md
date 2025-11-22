# Pepper & Church Reloaded

Modernized save editor for **Salt and Sanctuary** built on the original “Pepper and Church” tool by [inner_fears](https://www.nexusmods.com/users/39167990) and [Goldenrevolver](https://www.nexusmods.com/users/4366065).  
The upstream NexusMods release is available at https://www.nexusmods.com/saltandsanctuary/mods/68 (last updated 28 Jan 2023). This fork keeps the project alive with quality‑of‑life fixes and support for the current PC build (1.0.2.2).

## Highlights

- **Reloaded branding:** “Pepper & Church Reloaded” keeps the familiar name while signaling the refreshed codebase.
- **Salt and Sanctuary 1.0.2.2 support:** Handles the enhanced save format, new sanctuary IDs, and large inventories without throwing exceptions.
- **Graceful fallback logic:** Unknown sanctuaries or merchants are still editable thanks to placeholder rows and automatic ID handling.
- **Ready-to-ship build:** A Release configuration produces an `.exe` suitable for GitHub Releases; the repo itself stays clean of copyrighted game assets.

## Getting Started

### Requirements

- Windows with .NET Framework **4.5.2** developer pack (MSBuild 14+) or Visual Studio 2019+/Build Tools.
- A legitimate copy of Salt and Sanctuary 1.0.2.2 to provide the required resource archives.

### Preparing the data folder

The editor embeds several proprietary data archives. Copy them from your installation (default: `C:\Program Files (x86)\Steam\steamapps\common\Salt and Sanctuary`) into the repository under `data/<subfolder>/` as shown below. Do **not** commit these files.

```
data/dialog/data/dialog.zdx
data/dialog/data/strings.ztx
data/loot/data/loot.zlx
data/map/data/fortress.zax
data/monsters/data/monsters.zox
data/skilltree/data/skilltree.zsx
data/texturesheet/data/master.zcm
```

### Building

```bash
# From the repo root
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" PepperAndChurchSaveEditor.csproj /t:Build /p:Configuration=Release
```

The compiled editor is written to `bin/Release/PepperAndChurchSaveEditor.exe`.  
If you prefer Visual Studio, open `sas.sln`, select the **Release** configuration, and build normally.

### Running

1. Launch `PepperAndChurchSaveEditor.exe`.
2. Use **File → Load** and point to a save in `%USERPROFILE%\Documents\Salt and Sanctuary\savedata\dat*.slv`.
3. Edit values (inventory, sanctuaries, flags, etc.) and choose **File → Save** to write back. A `.bak` backup is automatically created.

## Publishing a GitHub Release

1. Build the Release configuration after copying the latest game data files.
2. Create a Git tag for the version you want to ship (e.g. `git tag v0.4.0-reloaded`).
3. Upload `bin/Release/PepperAndChurchSaveEditor.exe` (and its `.config` if desired) as assets to the GitHub Release page so users can download the ready-made editor without compiling.

## Credits

- Original save editor (“Pepper and Church”) by **inner_fears** & **Goldenrevolver** – https://www.nexusmods.com/saltandsanctuary/mods/68  
- Fork & maintenance (“Pepper & Church Reloaded”) by the current contributors.

Please continue to support the original authors and the Salt and Sanctuary community.
