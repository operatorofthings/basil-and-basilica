# Basil & Basilica (🌿 & 🏛️)

Modernized save editor for **Salt and Sanctuary** (🧂& 💒) built on the original “Pepper and Church” (🌶️&⛪) tool by [inner_fears](https://next.nexusmods.com/profile/Inner_Fears?gameId=2049) and [Goldenrevolver](https://next.nexusmods.com/profile/Goldenrevolver).  
The upstream NexusMods release is available at https://www.nexusmods.com/saltandsanctuary/mods/68 (last updated 28 Jan 2023). This fork—**Basil & Basilica**—keeps the project alive with quality-of-life fixes, refreshed branding, and support for the current PC build (1.0.2.2).

## 🚀 Just download and play

> 🚨 Before you move on, please make sure that you BACKUP your Salt & Sanctuary savegame files located at `%USERPROFILE%\Documents\Salt and Sanctuary\savedata\dat*.slv`

1) Go to the GitHub [Releases](https://github.com/operatorofthings/basil-and-basilica/releases) (👈 click this link or scroll a bit up and look to the right 👉)
2) Download the latest `BasilAndBasilica.exe`.   
3) Double-click `BasilAndBasilica.exe` (allow Windows to run it if prompted).  
4) In the app choose **File → Load** and select your save at `%USERPROFILE%\Documents\Salt and Sanctuary\savedata\dat*.slv`.  
5) Make edits, then **File → Save**. A `.bak` backup is created automatically next to your save.

## 📣 Highlights (v1.0.1)

- **Modernized UI:** Segoe UI, flat styling, owner-drawn tabs, and fresher spacing.
- **Inventory Helper:** Filter/search, quick-add (+1/+10/+50/+100), bulk “give materials” and “remove duplicates,” clearer status text, and selection is preserved after actions. Save to commit changes.
- **Backup Manager:** Browse, create, restore, and delete `.bak` files alongside your save.
- **Skill Tree Builder:** Checklist of skill nodes with orb counter, import/export of node IDs, randomize current allocation, and an in-app legend explaining node type codes.
- **Language toggle (EN/DE):** Top-bar switch updates in-app item names where German strings exist; falls back to English otherwise.
- **Salt and Sanctuary 1.0.2.2 support:** Handles the enhanced save format, new sanctuary IDs, and large inventories without throwing exceptions.
- **Graceful fallback logic:** Unknown sanctuaries or merchants are still editable thanks to placeholder rows and automatic ID handling.

## ⚙️ Development setup

### Requirements

- Windows with .NET Framework **4.5.2** developer pack (MSBuild 14+) or Visual Studio 2019+/Build Tools.
- Salt and Sanctuary 1.0.2.2 (to supply proprietary data archives).

### Prepare the data folder (required to build)

Copy the game data into `data/` from your install (default: `C:\Program Files (x86)\Steam\steamapps\common\Salt and Sanctuary`). 
> 🚨 Do **never** commit Salt & Sancturay game files! 🚨

```
data/dialog/data/dialog.zdx
data/dialog/data/strings.ztx
data/loot/data/loot.zlx
data/map/data/fortress.zax
data/monsters/data/monsters.zox
data/skilltree/data/skilltree.zsx
data/texturesheet/data/master.zcm
```

### Build

```bash
# From repo root on Windows
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" BasilAndBasilica.csproj /t:Build /p:Configuration=Release

# From WSL (uses the same Windows MSBuild)
/mnt/c/Windows/Microsoft.NET/Framework64/v4.0.30319/MSBuild.exe BasilAndBasilica.csproj /t:Build /p:Configuration=Release
```

Artifacts land in `bin/Release/` (`BasilAndBasilica.exe`, `.config`, `.pdb`). Visual Studio users can open `BasilAndBasilica.sln`, select **Release**, and build normally.

### Run (after building yourself)

1. Launch `bin/Release/BasilAndBasilica.exe`.
2. **File → Load** your save from `%USERPROFILE%\Documents\Salt and Sanctuary\savedata\dat*.slv`.
3. Edit and **File → Save** (auto `.bak` created).

## Credits

- Original save editor (“Pepper and Church”) by **inner_fears** & **Goldenrevolver** – https://www.nexusmods.com/saltandsanctuary/mods/68  
- Fork & maintenance (“Basil & Basilica”) by the current contributors.

Please continue to support the original authors and the Salt and Sanctuary community.
