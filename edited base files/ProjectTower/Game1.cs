using DialogEdit.dialog;
using LootEdit.loot;
using MapEdit.map;
using MonsterEdit.monsters;
using ProjectTower.character;
using ProjectTower.player;
using ProjectTower.sanctuary;
using ProjectTower.texturesheet;
using SkillTreeEdit.skilltree;

namespace ProjectTower
{
    public class Game1
    {
        public static void Init(string[] args)
        {
            Game1.language = 0;

            if (args != null && args.Length > 0)
            {
                int language;
                if (int.TryParse(args[0], out language))
                {
                    if (language >= 0 && language <= 11)
                    {
                        Game1.language = language;
                    }
                }
            }

            SkillTree.Init();
            Textures.Init();
            Map.Read();
            Creeds.Init();
            SanctuaryMgr.Init();
            LootCatalog.Init();
            LootCatalog.ReadMaster();
            MonsterCatalog.ReadMaster();
            DialogMgr.Init();
            DialogMgr.ReadLocText();
            DialogMgr.ReadMaster();
            c = new Character();
            p = new Player();
        }

        public static int GetSanctIdFromName(string name)
        {
            switch (name)
            {
                case "Ashen Shore": return SANCTUARY_ASHEN_SHORE;
                case "Village of Smiles": return SANCTUARY_FORSAKEN_VILLAGE;
                case "Bandit's Pass": return SANCTUARY_BANDITS_PASS;
                case "Castle of Storms": return SANCTUARY_CASTLE_OF_STORMS;
                case "Sunken Keep": return SANCTUARY_SUNKEN_KEEP;
                case "Red Hall of Cages": return SANCTUARY_RED_DUNGEON;
                case "The Watching Woods": return SANCTUARY_LOST_WOODS;
                case "Hager's Cavern": return SANCTUARY_CAVES;
                case "Mire of Stench": return SANCTUARY_SWAMP;
                case "Dome of the Forgotten": return SANCTUARY_DOME;
                case "Mal's Floating Castle": return SANCTUARY_SKY_CASTLE;
                case "Cran's Pass": return SANCTUARY_DUNGEON_CAVE;
                case "The Far Beach": return SANCTUARY_FAR_BEACH;
                case "Fort-Beyond-The-Mire": return SANCTUARY_COASTAL_FORT;
                case "Siam Lake": return SANCTUARY_SIAM_LAKE;
                case "Pitchwoods": return SANCTUARY_DARKWOOD;
                case "Ziggurat of Dust": return SANCTUARY_ZIGGURAT;
                case "The Ruined Temple": return SANCTUARY_RUINS;
                case "Salt Alkymancy": return SANCTUARY_LAB;
                case "Crypt of Dead Gods": return SANCTUARY_TOMB;
                case "Blackest Vault": return SANCTUARY_BLACKEST_VAULT;
                case "The Festering Banquet Shrine": return SHRINE_PARTY_FORT;
                case "Sunken Keep Shrine": return SHRINE_SUNKEN_KEEP;
                case "Red Hall of Cages Shrine": return SHRINE_RED_DUNGEON;
                case "Dome of the Forgotten Shrine": return SHRINE_DOME;
                case "Mire of Stench Shrine": return SHRINE_SWAMP;
                case "Castle of Storms Shrine": return SHRINE_CASTLE_OF_STORMS;
                case "Hager's Cavern Shrine": return SHRINE_CAVES;
                case "Crypt of the Dead Gods Shrine": return SHRINE_TOMB;
                case "The Still Palace Shrine": return SHRINE_PALACE;
                case "Pitchwoods Shrine": return SHRINE_DARKWOODS;
                case "Shrine between Ziggurat and Ruined Temple": return SHRINE_UNKNOWN;

                default: return -1;
            }
        }

        public static string GetSanctNameFromId(int id)
        {
            switch (id)
            {
                case -1: return "None";
                case SANCTUARY_ASHEN_SHORE: return "Ashen Shore";
                case SANCTUARY_FORSAKEN_VILLAGE: return "Village of Smiles";
                case SANCTUARY_BANDITS_PASS: return "Bandit's Pass";
                case SANCTUARY_CASTLE_OF_STORMS: return "Castle of Storms";
                case SANCTUARY_SUNKEN_KEEP: return "Sunken Keep";
                case SANCTUARY_RED_DUNGEON: return "Red Hall of Cages";
                case SANCTUARY_LOST_WOODS: return "The Watching Woods";
                case SANCTUARY_CAVES: return "Hager's Cavern";
                case SANCTUARY_SWAMP: return "Mire of Stench";
                case SANCTUARY_DOME: return "Dome of the Forgotten";
                case SANCTUARY_SKY_CASTLE: return "Mal's Floating Castle";
                case SANCTUARY_DUNGEON_CAVE: return "Cran's Pass";
                case SANCTUARY_FAR_BEACH: return "The Far Beach";
                case SANCTUARY_COASTAL_FORT: return "Fort-Beyond-The-Mire";
                case SANCTUARY_SIAM_LAKE: return "Siam Lake";
                case SANCTUARY_DARKWOOD: return "Pitchwoods";
                case SANCTUARY_ZIGGURAT: return "Ziggurat of Dust";
                case SANCTUARY_RUINS: return "The Ruined Temple";
                case SANCTUARY_LAB: return "Salt Alkymancy";
                case SANCTUARY_TOMB: return "Crypt of Dead Gods";
                case SANCTUARY_BLACKEST_VAULT: return "Blackest Vault";
                case SHRINE_PARTY_FORT: return "The Festering Banquet Shrine";
                case SHRINE_SUNKEN_KEEP: return "Sunken Keep Shrine";
                case SHRINE_RED_DUNGEON: return "Red Hall of Cages Shrine";
                case SHRINE_DOME: return "Dome of the Forgotten Shrine";
                case SHRINE_SWAMP: return "Mire of Stench Shrine";
                case SHRINE_CASTLE_OF_STORMS: return "Castle of Storms Shrine";
                case SHRINE_CAVES: return "Hager's Cavern Shrine";
                case SHRINE_TOMB: return "Crypt of the Dead Gods Shrine";
                case SHRINE_PALACE: return "The Still Palace Shrine";
                case SHRINE_DARKWOODS: return "Pitchwoods Shrine";
                case SHRINE_UNKNOWN: return "Shrine between Ziggurat and Ruined Temple";
                default:
                    if (id >= 0)
                    {
                        return "Sanctuary #" + id;
                    }
                    return "";
            }
        }

        public static string GetCreedFromId(int id)
        {
            switch (id)
            {
                case Creeds.CREED_CLERIC: return "Devara's Light";
                case Creeds.CREED_DARK: return "Order of the Betrayer";
                case Creeds.CREED_FIRE: return "Keepers of Fire and Sky";
                case Creeds.CREED_IRON: return "The Iron Ones";
                case Creeds.CREED_THREE: return "The Three";
                case Creeds.CREED_WOODS: return "The Stone Roots";
                case Creeds.CREED_SPLENDOR: return "The House of Splendor";
                default: return "None";
            }
        }

        public static int GetIdFromCreed(string creed)
        {
            switch (creed)
            {
                case "Devara's Light": return Creeds.CREED_CLERIC;
                case "Order of the Betrayer": return Creeds.CREED_DARK;
                case "Keepers of Fire and Sky": return Creeds.CREED_FIRE;
                case "The Iron Ones": return Creeds.CREED_IRON;
                case "The Three": return Creeds.CREED_THREE;
                case "The Stone Roots": return Creeds.CREED_WOODS;
                case "The House of Splendor": return Creeds.CREED_SPLENDOR;
                default: return Creeds.CREED_NONE;
            }
        }

        public static int GetMerchantIdFromName(string name)
        {
            switch (name)
            {
                case "Priest": return Sanctuary.MERCHANT_PRIEST;
                case "Sellsword": return Sanctuary.MERCHANT_SELLSWORD;
                case "Leader": return Sanctuary.MERCHANT_LEADER;
                case "Mage": return Sanctuary.MERCHANT_MAGE;
                case "Alchemist": return Sanctuary.MERCHANT_ALCHEMIST;
                case "Guide": return Sanctuary.MERCHANT_GUIDE;
                case "Blacksmith": return Sanctuary.MERCHANT_BLACKSMITH;
                case "Merchant": return Sanctuary.MERCHANT_MERCHANT;
                case "None": return Sanctuary.MERCHANT_OFF;
                default: return -1;
            }
        }

        public static string GetMerchantNameFromId(int id)
        {
            switch (id)
            {
                case Sanctuary.MERCHANT_PRIEST: return "Priest";
                case Sanctuary.MERCHANT_SELLSWORD: return "Sellsword";
                case Sanctuary.MERCHANT_LEADER: return "Leader";
                case Sanctuary.MERCHANT_MAGE: return "Mage";
                case Sanctuary.MERCHANT_ALCHEMIST: return "Alchemist";
                case Sanctuary.MERCHANT_GUIDE: return "Guide";
                case Sanctuary.MERCHANT_BLACKSMITH: return "Blacksmith";
                case Sanctuary.MERCHANT_MERCHANT: return "Merchant";
                default: return "None";
            }
        }

        public const int SANCTUARY_ASHEN_SHORE = 0;

        public const int SANCTUARY_FORSAKEN_VILLAGE = 1;

        public const int SANCTUARY_BANDITS_PASS = 2;

        public const int SANCTUARY_CASTLE_OF_STORMS = 3;

        public const int SANCTUARY_SUNKEN_KEEP = 4;

        public const int SANCTUARY_RED_DUNGEON = 5;

        public const int SANCTUARY_LOST_WOODS = 6;

        public const int SANCTUARY_CAVES = 7;

        public const int SANCTUARY_SWAMP = 8;

        public const int SANCTUARY_DOME = 9;

        public const int SANCTUARY_SKY_CASTLE = 10;

        public const int SANCTUARY_DUNGEON_CAVE = 11;

        public const int SANCTUARY_FAR_BEACH = 12;

        public const int SANCTUARY_COASTAL_FORT = 13;

        public const int SANCTUARY_SIAM_LAKE = 14;

        public const int SANCTUARY_DARKWOOD = 15;

        public const int SANCTUARY_ZIGGURAT = 16;

        public const int SANCTUARY_RUINS = 17;

        public const int SHRINE_PARTY_FORT = 18;

        public const int SHRINE_SUNKEN_KEEP = 19;

        public const int SHRINE_RED_DUNGEON = 20;

        public const int SHRINE_DOME = 21;

        public const int SANCTUARY_LAB = 22;

        public const int SHRINE_SWAMP = 23;

        public const int SHRINE_CASTLE_OF_STORMS = 24;

        public const int SHRINE_CAVES = 25;

        public const int SANCTUARY_TOMB = 26;

        public const int SHRINE_TOMB = 27;

        public const int SHRINE_PALACE = 28;

        public const int SHRINE_DARKWOODS = 29;

        public const int SHRINE_UNKNOWN = 30;

        public const int SANCTUARY_BLACKEST_VAULT = 31;

        public static int language;

        public static Character c;

        public static Player p;
    }
}
