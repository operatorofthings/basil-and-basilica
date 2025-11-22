using LootEdit;
using LootEdit.loot;
using ProjectTower.character;
using PepperAndChurchSaveEditor;
using System.IO;

namespace ProjectTower.player
{
    public class PlayerInv
    {
        public PlayerInv(Player p)
        {
            this.p = p;
            // this was changed in 1.09
            this.inventory = new InvLoot[10000];
            this.invEquip = new PlayerInvEquip(p);
        }

        public void Write(BinaryWriter writer)
        {
            for (int i = 0; i < this.inventory.Length; i++)
            {
                writer.Write(this.inventory[i] != null);
                if (this.inventory[i] != null)
                {
                    this.inventory[i].Write(writer);
                }
            }
        }

        public void Read(BinaryReader reader, string vers = "")
        {
            // this is now hardcoded instead of being inventory.length. 1024 for pre 1.09 saves, 10000 for post
            int num = 1024;
            if (vers == "slv|v2" || vers == "enh|v2")
            {
                num = 10000;
            }
            for (int i = 0; i < num; i++)
            {
                if (reader.ReadBoolean())
                {
                    this.inventory[i] = new InvLoot(reader);
                }
                else
                {
                    this.inventory[i] = null;
                }
            }
            this.UpdateRunes(null);
        }

        // commented out because it's unused and would not work with unknown modded items

        //public LootDef GetLootFromIdx(int idx)
        //{
        //    if (this.inventory[idx] != null)
        //    {
        //        return LootCatalog.category[this.inventory[idx].category].loot[this.inventory[idx].catalogIdx];
        //    }
        //    return null;
        //}

        internal int Add(InvLoot loot, bool autoSelect, int count)
        {
            bool flag = true;
            switch (loot.category)
            {
                case 1:
                    {
                        int num = LootCatalog.category[1].loot[loot.catalogIdx].type;
                        if (num == 4)
                        {
                            flag = false;
                        }
                        break;
                    }
                case 3:
                    {
                        int num = LootCatalog.category[3].loot[loot.catalogIdx].type;
                        if (num == 2)
                        {
                            flag = false;
                        }
                        break;
                    }
                case 4:
                    {
                        int num = LootCatalog.category[4].loot[loot.catalogIdx].flags;
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
                            case 91:
                                flag = false;
                                break;
                        }
                        break;
                    }
                case 6:
                    flag = false;
                    break;

                case 7:
                    {
                        int num = LootCatalog.category[7].loot[loot.catalogIdx].flags;
                        if (num == 14 || num == 27)
                        {
                            flag = false;
                        }
                        break;
                    }
            }
            if (loot.category == 4 || loot.category == 7)
            {
                for (int i = 0; i < this.inventory.Length; i++)
                {
                    if (this.inventory[i] != null && this.inventory[i].category == loot.category && this.inventory[i].catalogIdx == loot.catalogIdx)
                    {
                        this.inventory[i].count += count;
                        return i;
                    }
                }
            }
            if (flag)
            {
                int num2 = 0;
                for (int j = 0; j < this.inventory.Length; j++)
                {
                    if (this.inventory[j] != null)
                    {
                        num2++;
                        if (num2 >= this.inventory.Length - 50)
                        {
                            return -1;
                        }
                    }
                }
            }
            for (int k = 0; k < this.inventory.Length; k++)
            {
                if (this.inventory[k] == null)
                {
                    this.inventory[k] = new InvLoot(loot);
                    this.inventory[k].count = count;
                    Character playerCharacter = Game1.c;
                    if (playerCharacter != null)
                    {
                        if (playerCharacter.equipment.helm.invIdx == k)
                        {
                            playerCharacter.equipment.helm.catalogIdx = -1;
                        }
                        if (playerCharacter.equipment.armor.invIdx == k)
                        {
                            playerCharacter.equipment.armor.catalogIdx = -1;
                        }
                        if (playerCharacter.equipment.boots.invIdx == k)
                        {
                            playerCharacter.equipment.boots.catalogIdx = -1;
                        }
                        if (playerCharacter.equipment.gloves.invIdx == k)
                        {
                            playerCharacter.equipment.gloves.catalogIdx = -1;
                        }
                        for (int l = 0; l < 4; l++)
                        {
                            if (playerCharacter.equipment.ring[l].invIdx == k)
                            {
                                playerCharacter.equipment.ring[l].catalogIdx = -1;
                            }
                        }
                        for (int m = 0; m < 6; m++)
                        {
                            if (playerCharacter.equipment.consumable[m].invIdx == k)
                            {
                                playerCharacter.equipment.consumable[m].catalogIdx = -1;
                            }
                        }
                        for (int n = 0; n < 6; n++)
                        {
                            if (playerCharacter.equipment.incantation[n].invIdx == k)
                            {
                                playerCharacter.equipment.incantation[n].catalogIdx = -1;
                            }
                        }
                        for (int num3 = 0; num3 < 2; num3++)
                        {
                            for (int num4 = 0; num4 < 3; num4++)
                            {
                                if (playerCharacter.equipment.loadout[num3, num4].invIdx == k)
                                {
                                    playerCharacter.equipment.loadout[num3, num4].catalogIdx = -1;
                                }
                            }
                        }
                    }
                    if (loot.category == 4)
                    {
                        bool flag2 = false;
                        LootDef lootDef = LootCatalog.category[4].loot[loot.catalogIdx];
                        switch (lootDef.type)
                        {
                            case 0:
                                int flags3 = lootDef.flags;
                                if (flags3 == 68)
                                {
                                    flag2 = true;
                                }
                                break;

                            case 1:
                            case 2:
                            case 3:
                                flag2 = true;
                                break;
                        }
                        if (playerCharacter != null && autoSelect && !flag2)
                        {
                            bool flag3 = false;
                            for (int num4 = 0; num4 < playerCharacter.equipment.consumable.Length; num4++)
                            {
                                if (playerCharacter.equipment.consumable[num4].catalogIdx == this.inventory[k].catalogIdx)
                                {
                                    flag3 = true;
                                    break;
                                }
                            }
                            if (!flag3)
                            {
                                for (int num5 = 0; num5 < playerCharacter.equipment.consumable.Length; num5++)
                                {
                                    if (playerCharacter.equipment.consumable[num5].catalogIdx == -1)
                                    {
                                        playerCharacter.equipment.consumable[num5].catalogIdx = loot.catalogIdx;
                                        playerCharacter.equipment.consumable[num5].invIdx = k;
                                        break;
                                    }
                                }
                                if (playerCharacter.equipment.selConsumable < 6 && playerCharacter.equipment.consumable[playerCharacter.equipment.selConsumable].catalogIdx == -1)
                                {
                                    this.SelectNextConsumable(playerCharacter);
                                }
                            }
                        }
                    }
                    this.UpdateRunes(this.inventory[k]);
                    return k;
                }
            }
            return -1;
        }

        public void UpdateRunes(InvLoot invLoot)
        {
            int num = 0;
            for (int i = 0; i < this.p.runes.Length; i++)
            {
                this.p.runes[i] = false;
            }
            for (int j = 0; j < this.inventory.Length; j++)
            {
                InvLoot invLoot2 = this.inventory[j];
                // edited to work with new modded items
                if (invLoot2 != null && invLoot2.category == 3 && invLoot2.catalogIdx > -1)
                {
                    LootDef lootDef = LootCatalog.category[invLoot2.category].loot[invLoot2.catalogIdx];
                    if (lootDef.type == 2 && lootDef.flags < this.p.runes.Length)
                    {
                        this.p.runes[lootDef.flags] = true;
                        num++;
                    }
                }
            }
        }

        public bool RemoveConsumable(int idx, Character c, bool removeSanctuaryItems)
        {
            if (idx < 0)
            {
                return false;
            }
            this.inventory[idx].count--;
            if (this.inventory[idx].count <= 0)
            {
                if (this.inventory[idx].sanctuaryConsumableCreed <= 0 || removeSanctuaryItems)
                {
                    for (int i = 0; i < c.equipment.consumable.Length; i++)
                    {
                        if (c.equipment.consumable[i].invIdx == idx)
                        {
                            c.equipment.consumable[i].catalogIdx = -1;
                            c.equipment.consumable[i].invIdx = -1;
                            this.inventory[idx] = null;
                            return true;
                        }
                    }
                    this.inventory[idx] = null;
                    return true;
                }
                this.inventory[idx].count = 0;
            }
            return false;
        }

        public void SelectNextConsumable(Character c)
        {
            for (int i = 0; i < c.equipment.consumable.Length; i++)
            {
                c.equipment.selConsumable = (c.equipment.selConsumable + 1) % c.equipment.consumable.Length;
                if (c.equipment.consumable[c.equipment.selConsumable].catalogIdx > -1)
                {
                    break;
                }
            }
        }

        internal void Reset()
        {
            for (int i = 0; i < this.inventory.Length; i++)
            {
                this.inventory[i] = null;
            }
        }

        // commented out because it's unused and would not work with unknown modded items

        //internal string GetKeyName(string key)
        //{
        //    for (int i = 0; i < this.inventory.Length; i++)
        //    {
        //        if (this.inventory[i] != null && this.inventory[i].category == 6 && this.inventory[i].name == key)
        //        {
        //            return LootCatalog.category[6].loot[this.inventory[i].catalogIdx].title[Game1.language];
        //        }
        //    }
        //    return "";
        //}

        //internal int GetMaterialDefCount(int category, int catalogIdx)
        //{
        //    for (int i = 0; i < this.inventory.Length; i++)
        //    {
        //        if (this.inventory[i] != null && this.inventory[i].category == category && this.inventory[i].catalogIdx == catalogIdx)
        //        {
        //            return this.inventory[i].count;
        //        }
        //    }
        //    return 0;
        //}

        //internal bool HasInvItem(string p)
        //{
        //    for (int i = 0; i < this.inventory.Length; i++)
        //    {
        //        if (this.inventory[i] != null && LootCatalog.category[this.inventory[i].category].loot[this.inventory[i].catalogIdx].name == p)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public const int CATEGORY_EQUIP = 0;

        public const int CATEGORY_CONSUMABLES = 1;

        public const int CATEGORY_MAGIC = 2;

        public const int CATEGORY_ARMOR = 3;

        public const int CATEGORY_WEAPONS = 4;

        public const int CATEGORY_RINGS = 5;

        public const int CATEGORY_KEYS = 6;

        public const int CATEGORY_BLACKSMITH = 7;

        public const int CATEGORY_RUNES = 8;

        public const int CATEGORY_SETTINGS = 9;

        public const int TOTAL_CATEGORIES = 10;

        public const int ITEM_HELM = 0;

        public const int ITEM_ARMOR = 1;

        public const int ITEM_GLOVES = 2;

        public const int ITEM_BOOTS = 3;

        public const int ITEM_LOADOUT_1_1 = 4;

        public const int ITEM_LOADOUT_1_2 = 5;

        public const int ITEM_LOADOUT_1_3 = 6;

        public const int ITEM_LOADOUT_2_1 = 7;

        public const int ITEM_LOADOUT_2_2 = 8;

        public const int ITEM_LOADOUT_2_3 = 9;

        public const int ITEM_CONSUMABLE_1 = 10;

        public const int ITEM_CONSUMABLE_2 = 11;

        public const int ITEM_CONSUMABLE_3 = 12;

        public const int ITEM_CONSUMABLE_4 = 13;

        public const int ITEM_CONSUMABLE_5 = 14;

        public const int ITEM_CONSUMABLE_6 = 15;

        public const int ITEM_RING_1 = 16;

        public const int ITEM_RING_2 = 17;

        public const int ITEM_RING_3 = 18;

        public const int ITEM_RING_4 = 19;

        public const int ITEM_INCANTATION_1 = 20;

        public const int ITEM_INCANTATION_2 = 21;

        public const int ITEM_INCANTATION_3 = 22;

        public const int ITEM_INCANTATION_4 = 23;

        public const int ITEM_INCANTATION_5 = 24;

        public const int ITEM_INCANTATION_6 = 25;

        public const int ITEM_MENU_INVENTORY = 26;

        public const int ITEM_MENU_BESTIARY = 27;

        public const int ITEM_MENU_SETTINGS = 28;

        public const int TOTAL_ITEMS = 29;

        public const int PICK_NONE = 0;

        public const int PICK_HELM = 1;

        public const int PICK_ARMOR = 2;

        public const int PICK_BOOTS = 3;

        public const int PICK_GLOVES = 4;

        public const int PICK_WEAPON = 5;

        public const int PICK_SHIELD = 6;

        public const int PICK_CHARM = 7;

        public const int PICK_ARROWS = 8;

        public const int PICK_SPELLS = 9;

        public const int PICK_INCANTATION = 10;

        public const int PICK_CONSUMABLE = 11;

        public const int PICK_RING = 12;

        public const int PICK_OFFHAND = 13;

        public const int PICK_LOADOUT_ITEM = 14;

        public const int invLength_v1 = 1024;

        public const int invLength_v2 = 10000;

        private Player p;

        public InvLoot[] inventory;

        public PlayerInvEquip invEquip;

        public int selCategory;

        public int selItem;

        public Vector2 selVector;
    }
}
