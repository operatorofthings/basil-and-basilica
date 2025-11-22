using BasilAndBasilica;
using ProjectTower.texturesheet;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LootEdit.loot
{
    public class LootCatalog
    {
        public static void Init()
        {
            LootCatalog.category = new LootCategory[8];
            for (int i = 0; i < LootCatalog.category.Length; i++)
            {
                LootCatalog.category[i] = new LootCategory();
            }
        }

        public static void Read(BinaryReader reader)
        {
            for (int i = 0; i < LootCatalog.category.Length; i++)
            {
                LootCatalog.category[i].Read(reader);
            }
            for (int j = 0; j < LootCatalog.category.Length; j++)
            {
                for (int k = 0; k < LootCatalog.category[j].loot.Length; k++)
                {
                    LootCatalog.category[j].loot[k].texIdx = Textures.GetTextureIdx(LootCatalog.category[j].loot[k].texture);
                    if (j == 2)
                    {
                        if (LootCatalog.category[j].loot[k].flags == 3 || LootCatalog.category[j].loot[k].flags == 16 || LootCatalog.category[j].loot[k].flags == 8 || LootCatalog.category[j].loot[k].flags == 6 || LootCatalog.category[j].loot[k].flags == 10 || LootCatalog.category[j].loot[k].flags == 15 || LootCatalog.category[j].loot[k].flags == 13)
                        {
                            LootCatalog.category[j].loot[k].texIdx2 = Textures.GetTextureIdx(LootCatalog.category[j].loot[k].texture + "2");
                        }
                        if (LootCatalog.category[j].loot[k].name == "smallclothes_boots")
                        {
                            LootCatalog.smallclothesBootsIdx = k;
                        }
                        if (LootCatalog.category[j].loot[k].name == "smallclothes_armor")
                        {
                            LootCatalog.smallclothesArmorIdx = k;
                        }
                    }
                }
            }
        }

        public static void ReadMaster()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(string.Format("{0}.loot.data.loot.zlx", Program.DATAPATH));
            BinaryReader br = new BinaryReader(_fileStream);
            LootCatalog.Read(br);
            br.Close();
        }

        // commented out because it's unused and would not work with unknown modded items

        //internal static int[] GetCategories(Player p)
        //{
        //    List<int> list = new List<int>();
        //    for (int i = 0; i < p.playerInv.inventory.Length; i++)
        //    {
        //        InvLoot invLoot = p.playerInv.inventory[i];
        //        if (invLoot != null)
        //        {
        //            LootDef lootDef = LootCatalog.category[invLoot.category].loot[invLoot.catalogIdx];
        //            if (LootCatalog.CanSell(lootDef))
        //            {
        //                switch (lootDef.category)
        //                {
        //                    case 5:
        //                    case 6:
        //                        break;

        //                    default:
        //                        if (!list.Contains(lootDef.category))
        //                        {
        //                            list.Add(lootDef.category);
        //                        }
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    return list.ToArray();
        //}

        internal static bool CanSell(LootDef lDef)
        {
            switch (lDef.category)
            {
                case 0:
                    {
                        int num = lDef.type;
                        if (num == 15)
                        {
                            return false;
                        }
                        break;
                    }
                case 1:
                    {
                        int num = lDef.type;
                        if (num == 4)
                        {
                            return false;
                        }
                        break;
                    }
                case 3:
                    {
                        int num = lDef.type;
                        if (num == 2)
                        {
                            return false;
                        }
                        break;
                    }
                case 4:
                    {
                        int num = lDef.flags;
                        switch (num)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 68:
                                return false;

                            default:
                                return true;
                        }
                    }
            }
            return true;
        }

        internal static int[] GetCategories(string[] loot)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < loot.Length; i++)
            {
                LootDef lootDef = null;
                for (int j = 0; j < LootCatalog.category.Length; j++)
                {
                    for (int k = 0; k < LootCatalog.category[j].loot.Length; k++)
                    {
                        if (LootCatalog.category[j].loot[k].name == loot[i])
                        {
                            lootDef = LootCatalog.category[j].loot[k];
                        }
                    }
                }
                if (lootDef != null && !list.Contains(lootDef.category))
                {
                    list.Add(lootDef.category);
                }
            }
            return list.ToArray();
        }

        public const int CATEGORY_WEAPON = 0;

        public const int CATEGORY_SHIELD = 1;

        public const int CATEGORY_ARMOR = 2;

        public const int CATEGORY_RING = 3;

        public const int CATEGORY_CONSUMABLE = 4;

        public const int CATEGORY_MAGIC = 5;

        public const int CATEGORY_KEYS = 6;

        public const int CATEGORY_MATERIALS = 7;

        public const int TOTAL_CATEGORIES = 8;

        public static int smallclothesBootsIdx;

        public static int smallclothesArmorIdx;

        public static LootCategory[] category;
    }
}
