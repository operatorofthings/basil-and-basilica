# Basil & Basilica (🌿 & 🏛️)

Modernized save editor for **Salt and Sanctuary** built on the original “Pepper and Church” tool by [inner_fears](https://next.nexusmods.com/profile/Inner_Fears?gameId=2049) and [Goldenrevolver](https://next.nexusmods.com/profile/Goldenrevolver).  
The upstream NexusMods release is available at https://www.nexusmods.com/saltandsanctuary/mods/68 (last updated 28 Jan 2023). This fork—**Basil & Basilica**—keeps the project alive with quality-of-life fixes, refreshed branding, and support for the current PC build (1.0.2.2).

## Highlights (v1.0.1)

- **Modernized UI:** Segoe UI, flat styling, and owner-drawn tabs for a cleaner feel.
- **Inventory Helper:** Filter by category/text and use bulk actions (give materials, remove duplicates); edits reflect immediately in the loaded session—save when you’re happy.
- **Backup Manager:** Browse, create, restore, and delete `.bak` files alongside your save.
- **Skill Tree Builder:** Checklist of skill nodes with orb counter, import/export of node IDs, and a randomize option to shuffle your current allocation.
- **Salt and Sanctuary 1.0.2.2 support:** Handles the enhanced save format, new sanctuary IDs, and large inventories without throwing exceptions.
- **Graceful fallback logic:** Unknown sanctuaries or merchants are still editable thanks to placeholder rows and automatic ID handling.

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
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" BasilAndBasilica.csproj /t:Build /p:Configuration=Release
```

The compiled editor is written to `bin/Release/BasilAndBasilica.exe`.  
If you prefer Visual Studio, open `BasilAndBasilica.sln`, select the **Release** configuration, and build normally.

### Running

1. Launch `BasilAndBasilica.exe`.
2. Use **File → Load** and point to a save in `%USERPROFILE%\Documents\Salt and Sanctuary\savedata\dat*.slv`.
3. Edit values (inventory, sanctuaries, flags, etc.) and choose **File → Save** to write back. A `.bak` backup is automatically created.

## Credits

- Original save editor (“Pepper and Church”) by **inner_fears** & **Goldenrevolver** – https://www.nexusmods.com/saltandsanctuary/mods/68  
- Fork & maintenance (“Basil & Basilica”) by the current contributors.

Please continue to support the original authors and the Salt and Sanctuary community.
