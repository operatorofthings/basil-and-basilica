using ProjectTower;
using System.IO;
using System.Text;

namespace LootEdit
{
    public class LootDef
    {
        public LootDef()
        {
            this.values = new float[1];
            this.desc = new string[13];
            this.title = new string[13];
            for (int i = 0; i < 13; i++)
            {
                this.desc[i] = "";
                this.title[i] = "New Loot";
            }
            this.name = "new";
            this.upgradePath = new LootDef.UpgradePath[1];
        }

        public int GetUpgradeMaterial()
        {
            switch (this.upgrade)
            {
                case 0:
                    return 2;

                case 1:
                    return 4;

                case 2:
                    return 0;

                case 4:
                    return 1;

                case 5:
                    return 6;
            }
            return 2;
        }

        public static string GetWeapFlagsStrFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "None";

                case 1:
                    return "Fire";

                case 2:
                    return "Lit";

                case 3:
                    return "Poison";

                case 4:
                    return "Frost";

                case 5:
                    return "Holy";

                case 6:
                    return "Arcane";

                case 7:
                    return "HP Leech";

                case 8:
                    return "MP Leech";

                case 9:
                    return "Poise";

                case 10:
                    return "Charm Move (Hack)";

                case 11:
                    return "Charm Move2 (Hack)";

                default:
                    return "";
            }
        }

        public static string GetWeapSpecialStrFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "None";

                case 1:
                    return "Healing";

                case 2:
                    return "Chain whip";

                case 3:
                    return "Extra blunt";

                case 4:
                    return "Extra blades";

                case 5:
                    return "Slow Hitter";

                case 6:
                    return "Fast Hitter";

                case 7:
                    return "Slide";

                case 8:
                    return "Charm Move (hack)";

                case 9:
                    return "Wood Staff";

                default:
                    return "";
            }
        }

        public static string GetShieldTypeStrFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "Buckler";

                case 1:
                    return "Heater";

                case 2:
                    return "Kite";

                case 3:
                    return "Tower";

                case 4:
                    return "1h Hack";

                default:
                    return "";
            }
        }

        public static string GetArmorTypeStrFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "Helm";

                case 1:
                    return "Chest";

                case 2:
                    return "Gloves";

                case 3:
                    return "Boots";

                default:
                    return "";
            }
        }

        public static string GetWeapTypeStrFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "Dagger";

                case 1:
                    return "Sword";

                case 2:
                    return "Hammer";

                case 3:
                    return "Axe";

                case 4:
                    return "Spear";

                case 5:
                    return "Halberd";

                case 6:
                    return "Greatsword";

                case 7:
                    return "Greathammer";

                case 8:
                    return "Bow";

                case 9:
                    return "Crossbow";

                case 10:
                    return "Staff";

                case 11:
                    return "Whip";

                case 12:
                    return "Greataxe";

                case 13:
                    return "Poleaxe";

                case 14:
                    return "Flintlock";

                case 16:
                    return "Wand";

                case 17:
                    return "Greatscissor";

                case 18:
                    return "Gunblade";

                case 19:
                    return "Whipsword";

                case 20:
                    return "Longsword";
            }
            return "";
        }

        public void SetCategory(int category)
        {
            this.category = category;
            switch (category)
            {
                case 0:
                    this.values = new float[25];
                    this.upgradePath = new LootDef.UpgradePath[2];
                    return;

                case 1:
                    this.values = new float[13];
                    this.upgradePath = new LootDef.UpgradePath[2];
                    return;

                case 2:
                    this.values = new float[12];
                    this.upgradePath = new LootDef.UpgradePath[2];
                    return;

                case 3:
                    this.values = new float[2];
                    this.upgradePath = new LootDef.UpgradePath[2];
                    return;

                case 4:
                    this.values = new float[1];
                    this.upgradePath = new LootDef.UpgradePath[1];
                    return;

                case 5:
                    this.values = new float[3];
                    this.upgradePath = new LootDef.UpgradePath[1];
                    return;

                case 6:
                    this.values = new float[1];
                    this.upgradePath = new LootDef.UpgradePath[1];
                    return;

                case 7:
                    this.values = new float[1];
                    this.upgradePath = new LootDef.UpgradePath[1];
                    return;

                default:
                    return;
            }
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.name);
            for (int i = 0; i < 13; i++)
            {
                if (i < this.title.Length)
                {
                    writer.Write(this.title[i]);
                    writer.Write(this.desc[i]);
                }
                else
                {
                    writer.Write(this.title[0] + " - " + TranslationMgr.GetLangStrFromIdx(i));
                    writer.Write("Untranslated description: " + TranslationMgr.GetLangStrFromIdx(i));
                }
            }
            writer.Write((this.texture == null) ? "" : this.texture);
            writer.Write(this.category);
            writer.Write(this.type);
            writer.Write(this.upgrade);
            writer.Write(this.upgradeFac);
            writer.Write(this.flags);
            writer.Write(this.weight);
            writer.Write(this.special);
            writer.Write(this.img);
            writer.Write(this.value);
            writer.Write(this.durability);
            for (int j = 0; j < this.values.Length; j++)
            {
                writer.Write(this.values[j]);
            }
            for (int k = 0; k < this.upgradePath.Length; k++)
            {
                this.upgradePath[k].Write(writer);
            }
        }

        public void Read(BinaryReader reader)
        {
            this.name = reader.ReadString();
            for (int i = 0; i < 13; i++)
            {
                this.title[i] = reader.ReadString();
                this.desc[i] = reader.ReadString();
            }
            this.texture = reader.ReadString();
            this.category = reader.ReadInt32();
            this.type = reader.ReadInt32();
            this.upgrade = reader.ReadInt32();
            this.upgradeFac = reader.ReadSingle();
            this.flags = reader.ReadInt32();
            this.weight = reader.ReadSingle();
            this.special = reader.ReadInt32();
            this.img = reader.ReadInt32();
            this.value = reader.ReadSingle();
            this.durability = reader.ReadSingle();
            this.SetCategory(this.category);
            for (int j = 0; j < this.values.Length; j++)
            {
                this.values[j] = reader.ReadSingle();
            }
            for (int k = 0; k < this.upgradePath.Length; k++)
            {
                this.upgradePath[k].Read(reader);
            }
            this.titleStr = new StringBuilder(this.title[Game1.language]);
        }

        public LootDef(LootDef otherDef)
        {
            this.SetCategory(otherDef.category);
            this.type = otherDef.type;
            this.upgrade = otherDef.upgrade;
            this.name = otherDef.name;
            this.title = new string[otherDef.title.Length];
            this.desc = new string[otherDef.desc.Length];
            for (int i = 0; i < this.title.Length; i++)
            {
                this.title[i] = otherDef.title[i];
            }
            for (int j = 0; j < this.desc.Length; j++)
            {
                this.desc[j] = otherDef.desc[j];
            }
            this.texture = otherDef.texture;
            this.flags = otherDef.flags;
            this.weight = otherDef.weight;
            this.special = otherDef.special;
            this.value = otherDef.value;
            for (int k = 0; k < this.values.Length; k++)
            {
                this.values[k] = otherDef.values[k];
            }
            for (int l = 0; l < this.upgradePath.Length; l++)
            {
                this.upgradePath[l] = new LootDef.UpgradePath(otherDef.upgradePath[l].reqLoot, otherDef.upgradePath[l].outLoot, otherDef.upgradePath[l].cost, otherDef.upgradePath[l].reqCount);
            }
        }

        internal int GetUpgradeMaterialLevel(int upgrade)
        {
            switch (upgrade)
            {
                case 0:
                case 1:
                    return 0;

                case 2:
                case 3:
                    return 1;

                case 4:
                case 5:
                    return 2;

                case 6:
                    return 3;

                default:
                    return 0;
            }
        }

        internal int GetUpgradeMaterialCount(int upgrade)
        {
            switch (upgrade)
            {
                case 0:
                    return 1;

                case 1:
                    return 2;

                case 2:
                    return 1;

                case 3:
                    return 2;

                case 4:
                    return 1;

                case 5:
                    return 2;

                case 6:
                    return 1;

                default:
                    return 1;
            }
        }

        internal int GetUpgradeSaltCost(int upgrade)
        {
            switch (upgrade)
            {
                case 0:
                    return 250;

                case 1:
                    return 500;

                case 2:
                    return 1000;

                case 3:
                    return 1500;

                case 4:
                    return 2500;

                case 5:
                    return 5000;

                case 6:
                    return 10000;

                default:
                    return 500;
            }
        }

        internal static string GetMagicTypeStrFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "Elemental Spell";

                case 1:
                    return "Elemental Incantation";

                case 2:
                    return "Blood Spell";

                case 3:
                    return "Blood Incantation";

                case 4:
                    return "Holy Spell";

                case 5:
                    return "Holy Incantation";

                default:
                    return "";
            }
        }

        internal static string GetMagicFlagsStrFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "Bolt";

                case 1:
                    return "Great Bolt";

                case 2:
                    return "Missile";

                case 3:
                    return "Great Missile";

                case 4:
                    return "Heal";

                case 5:
                    return "Great Heal";

                case 6:
                    return "Regenerate";

                case 7:
                    return "Fireball";

                case 8:
                    return "Great Fireball";

                case 9:
                    return "Storm";

                case 10:
                    return "Great Storm";

                case 11:
                    return "Buff Weapon";

                case 12:
                    return "Great Buff Weapon";

                case 13:
                    return "Buff Shield";

                case 14:
                    return "Great Buff Shield";

                case 15:
                    return "Protection";

                case 16:
                    return "Great Protection";

                case 17:
                    return "Cure";

                case 18:
                    return "Great Cure";

                case 19:
                    return "Ball";

                case 20:
                    return "Great Ball";

                case 21:
                    return "Light";

                case 22:
                    return "Orbiters";

                case 23:
                    return "Satellite";

                case 24:
                    return "Ghost Wing";

                case 25:
                    return "Turret";

                case 26:
                    return "Poison Buff";

                case 27:
                    return "Vision Buff";

                case 28:
                    return "Rapid";

                case 29:
                    return "Great Rapid";

                case 30:
                    return "Dragonfire";

                case 31:
                    return "Flashfire";

                case 32:
                    return "Holy Orbiters";

                case 33:
                    return "Bandage";

                case 34:
                    return "Will Buff";

                case 35:
                    return "Phys Protect";

                case 36:
                    return "Mag Protect";

                case 37:
                    return "Cleanse";

                case 38:
                    return "Firestar";

                case 39:
                    return "Poison Gas";

                case 40:
                    return "Witch Swarm";

                case 41:
                    return "Witch Laser";

                case 42:
                    return "Revive";

                case 43:
                    return "Stars";

                case 44:
                    return "Starfall";

                case 45:
                    return "Hover blade";

                default:
                    return "";
            }
        }

        internal static string GetRingTypeStrFromInt(int p)
        {
            switch (p)
            {
                case 0:
                    return "Ring";

                case 1:
                    return "Charm";

                case 2:
                    return "Rune";

                default:
                    return "";
            }
        }

        internal static string GetCategoryFromInt(int p)
        {
            switch (p)
            {
                case 0:
                    return "Weapon";

                case 1:
                    return "Shield";

                case 2:
                    return "Armor";

                case 3:
                    return "Ring";

                case 4:
                    return "Consumable";

                case 5:
                    return "Magic";

                case 6:
                    return "Key";

                case 7:
                    return "Material";

                default:
                    return "";
            }
        }

        internal static string GetCategoriesFromInt(int p)
        {
            switch (p)
            {
                case 0:
                    return "Weapons";

                case 1:
                    return "Shields";

                case 2:
                    return "Armors";

                case 3:
                    return "Rings";

                case 4:
                    return "Consumables";

                case 5:
                    return "Magic";

                case 6:
                    return "Keys";

                case 7:
                    return "Materials";

                default:
                    return "";
            }
        }

        internal static string GetRingFlagsStrFromInt(int type, int p)
        {
            switch (type)
            {
                case 0:
                    switch (p)
                    {
                        case 0:
                            return "Phys Defense";

                        case 1:
                            return "Lit Defense";

                        case 2:
                            return "Fire Defense";

                        case 3:
                            return "Poison Defense";

                        case 4:
                            return "Bladed Def";

                        case 5:
                            return "Holy Defense";

                        case 6:
                            return "Dark Defense";

                        case 7:
                            return "Item Find";

                        case 8:
                            return "Salt Find";

                        case 9:
                            return "Gold Find";

                        case 10:
                            return "HP Regen";

                        case 11:
                            return "MP Regen";

                        case 12:
                            return "Stamina Regen";

                        case 13:
                            return "Poise";

                        case 14:
                            return "Str";

                        case 15:
                            return "Dex";

                        case 16:
                            return "Willpower";

                        case 17:
                            return "Endurance";

                        case 18:
                            return "Rolling";

                        case 19:
                            return "Dmg";

                        case 20:
                            return "HP to MP";

                        case 21:
                            return "Magic";

                        case 22:
                            return "Wisdom";

                        case 23:
                            return "Heals";

                        case 24:
                            return "Light";

                        case 25:
                            return "Fire Dmg";

                        case 26:
                            return "Cheap Magic";

                        case 27:
                            return "Cheap Prayers";

                        case 28:
                            return "Reduce Wounding";

                        case 29:
                            return "Reduce Fatigue";

                        case 30:
                            return "Salt Seek";

                        case 31:
                            return "Melee";

                        case 32:
                            return "Bloody";

                        case 33:
                            return "Mag Boost";

                        case 34:
                            return "Mag Balance";

                        case 35:
                            return "MP Moat";

                        case 36:
                            return "HP Leech";

                        case 37:
                            return "Reflect";

                        case 38:
                            return "Armor Melee";

                        case 39:
                            return "Shield - Corruption Fed";

                        case 40:
                            return "Shield - Thorns";

                        case 41:
                            return "Armor - Thorns";

                        case 42:
                            return "Armor - Torch";

                        case 44:
                            return "Throw Potion";
                    }
                    break;

                case 1:
                    switch (p)
                    {
                        case 0:
                            return "Atk";

                        case 1:
                            return "Poise";

                        case 2:
                            return "Speed";

                        case 3:
                            return "Reach";

                        case 4:
                            return "Fire";

                        case 5:
                            return "Lit";

                        case 6:
                            return "Poison";

                        case 7:
                            return "Bladed";

                        case 8:
                            return "Holy";

                        case 9:
                            return "Dark";

                        case 10:
                            return "Cursed";

                        case 11:
                            return "HP Leech";

                        case 12:
                            return "MP Leech";

                        case 13:
                            return "Dying Overkill";

                        case 14:
                            return "Heavy Poison";

                        case 15:
                            return "Salt Overload";

                        case 16:
                            return "Lantern";

                        case 17:
                            return "Ease";

                        case 18:
                            return "Blunt";

                        case 19:
                            return "Shadow";
                    }
                    break;

                case 2:
                    switch (p)
                    {
                        case 0:
                            return "Upside Down";

                        case 1:
                            return "Dash";

                        case 2:
                            return "Wall Jump";

                        case 3:
                            return "Double Jump";

                        case 4:
                            return "Red Block";

                        case 5:
                            return "Blue Ether";
                    }
                    break;
            }
            return "";
        }

        internal static string GetMaterialTypeStrFromInt(int p)
        {
            return "";
        }

        internal static string GetMaterialFlagsStrFromInt(int p)
        {
            return "";
        }

        internal static string GetConsumableTypeStrFromInt(int p)
        {
            switch (p)
            {
                case 0:
                    return "Quick Use";

                case 1:
                    return "Arrow";

                case 2:
                    return "Bolt";

                case 3:
                    return "Flint Shot";

                case 4:
                    return "SMG Bullet";

                case 5:
                    return "Revolver Bullet";

                case 6:
                    return "Shotgun Shell";

                default:
                    return "";
            }
        }

        internal static string GetShieldSpecialStrFromInt(int p)
        {
            switch (p)
            {
                case 0:
                    return "None";

                case 1:
                    return "Healing";

                case 2:
                    return "Stamina Regen";

                default:
                    return "";
            }
        }

        internal static string GetUpgradeStrFromInt(int p)
        {
            switch (p)
            {
                case 0:
                    return "Normal";

                case 1:
                    return "Drowning (Kraekan)";

                case 2:
                    return "Charred (Red)";

                case 3:
                    return "None";

                case 4:
                    return "Frozen (Blue)";

                case 5:
                    return "Beastly";

                default:
                    return "";
            }
        }

        internal static string GetConsumableFlagStrFromInt(int p)
        {
            switch (p)
            {
                case 0:
                    return "Potion";

                case 1:
                    return "Icon Iron";

                case 2:
                    return "Icon Cleric";

                case 3:
                    return "Icon Three";

                case 4:
                    return "Icon Woods";

                case 5:
                    return "Icon Dark";

                case 6:
                    return "Icon Splendor";

                case 7:
                    return "Icon Fool";

                case 8:
                    return "Icon Fire";

                case 9:
                    return "Icon Bones";

                case 10:
                    return "Arrow";

                case 11:
                    return "Big Arrow";

                case 12:
                    return "Fire Arrow";

                case 13:
                    return "Lit Arrow";

                case 14:
                    return "Poison Arrow";

                case 15:
                    return "Frost Arrow";

                case 16:
                    return "Holy Arrow";

                case 17:
                    return "Dark Arrow";

                case 18:
                    return "Bolt";

                case 19:
                    return "Big Bolt";

                case 20:
                    return "Fire Bolt";

                case 21:
                    return "Lit Bolt";

                case 22:
                    return "Poison Bolt";

                case 23:
                    return "Frost Bolt";

                case 24:
                    return "Holy Bolt";

                case 25:
                    return "Dark Bolt";

                case 26:
                    return "Potion Stamina";

                case 27:
                    return "Potion Cure";

                case 28:
                    return "Potion Thaw";

                case 29:
                    return "Salt Pouch";

                case 30:
                    return "Salt Bundle";

                case 31:
                    return "Salt Bag";

                case 32:
                    return "Salt Sack";

                case 33:
                    return "Salt Satchel";

                case 34:
                    return "Salt Pack";

                case 35:
                    return "Salt Case";

                case 36:
                    return "Salt Box";

                case 37:
                    return "Salt Crate";

                case 38:
                    return "Salt Chest";

                case 39:
                    return "Health Roll";

                case 40:
                    return "Blessed Water";

                case 41:
                    return "Mana Cloth";

                case 42:
                    return "Repair Kit";

                case 43:
                    return "Mana Crystal";

                case 44:
                    return "Healing Herbs";

                case 45:
                    return "Mana Herbs";

                case 46:
                    return "Blood Vial";

                case 47:
                    return "Black Salt";

                case 48:
                    return "Mana Mead";

                case 49:
                    return "Fire Water";

                case 50:
                    return "Bottled Sky";

                case 51:
                    return "Msg Bottle";

                case 52:
                    return "Msg Bottle Green";

                case 53:
                    return "Buff Fire";

                case 54:
                    return "Buff Lit";

                case 55:
                    return "Buff Poison";

                case 56:
                    return "Buff Frost";

                case 57:
                    return "Buff Holy";

                case 58:
                    return "Buff Dark";

                case 59:
                    return "Firepot";

                case 60:
                    return "Grenada";

                case 61:
                    return "Dagger";

                case 62:
                    return "Poison Dagger";

                case 63:
                    return "Flame Dagger";

                case 64:
                    return "Waterpot";

                case 65:
                    return "Health Shard";

                case 66:
                    return "Return Bell";

                case 67:
                    return "Vision";

                case 68:
                    return "Torch Consumable";

                case 69:
                    return "Wood Dagger";

                case 70:
                    return "Blue Shard";

                case 71:
                    return "Orange Phial";

                case 72:
                    return "Red Wine";

                case 73:
                    return "Blue Wine";

                case 74:
                    return "Horn Guide";

                case 75:
                    return "Horn Will";

                case 76:
                    return "Expunged Heart";

                case 77:
                    return "Magic Crystal";

                case 78:
                    return "Magic Urn";

                case 79:
                    return "Gold Wine";

                case 80:
                    return "Buff Sanc Fire";

                case 81:
                    return "Buff Sanc Lit";

                case 82:
                    return "Buff Sanc Poison";

                case 83:
                    return "Buff Sanc Frost";

                case 84:
                    return "Buff Sanc Holy";

                case 85:
                    return "Buff Sanc Dark";

                case 86:
                    return "Sanc Horn Will";

                case 87:
                    return "Egg Wrath";

                case 88:
                    return "Buff Focus";

                case 89:
                    return "Blood Pot";

                case 90:
                    return "Cleansing Cloth";

                case 91:
                    return "Coop Bell";

                case 92:
                    return "Antidote";

                case 93:
                    return "Crystal Sphere";

                case 94:
                    return "Potato";

                case 95:
                    return "Rock";

                default:
                    return "";
            }
        }

        internal float GetWeaponBladeFactor()
        {
            float num = 0f;
            switch (this.type)
            {
                case 0:
                case 1:
                case 4:
                case 5:
                case 11:
                case 13:
                case 18:
                case 19:
                case 20:
                    num = 1f;
                    break;

                case 2:
                case 7:
                    num = 0f;
                    break;

                case 3:
                case 12:
                    num = 0.5f;
                    break;

                case 6:
                case 17:
                    num = 0.75f;
                    break;

                case 8:
                    num = 0.8f;
                    break;

                case 9:
                    num = 0.9f;
                    break;

                case 14:
                    num = 0.5f;
                    break;
            }
            int num2 = this.special;
            if (num2 != 3)
            {
                if (num2 != 4)
                {
                    if (num2 == 9)
                    {
                        num = 0f;
                    }
                }
                else
                {
                    num += (1f - num) * 0.5f;
                }
            }
            else
            {
                num *= 0.5f;
            }
            return num;
        }

        public const int WEAP_SPECIAL_NONE = 0;

        public const int WEAP_SPECIAL_HEALING = 1;

        public const int WEAP_SPECIAL_CHAIN_WHIP = 2;

        public const int WEAP_SPECIAL_EXTRA_BLUNT = 3;

        public const int WEAP_SPECIAL_EXTRA_BLADES = 4;

        public const int WEAP_SPECIAL_SLOW_HITTER = 5;

        public const int WEAP_SPECIAL_FAST_HITTER = 6;

        public const int WEAP_SPECIAL_SLIDE = 7;

        public const int WEAP_SPECIAL_CHARM_MOVE = 8;

        public const int WEAP_SPECIAL_WOOD_STAFF = 9;

        public const int WEAP_SPECIAL_MAX = 10;

        public const int SHIELD_SPECIAL_NONE = 0;

        public const int SHIELD_SPECIAL_HEALING = 1;

        public const int SHIELD_SPECIAL_STAMINA_REGEN = 2;

        public const int SHIELD_SPECIAL_MAX = 3;

        public const int ARMOR_SPECIAL_NONE = 0;

        public const int ARMOR_SPECIAL_HEALING = 1;

        public const int ARMOR_SPECIAL_STAMINA_REGEN = 2;

        public const int ARMOR_SPECIAL_MAX = 3;

        public const int WEAP_TYPE_DAGGER = 0;

        public const int WEAP_TYPE_SWORD = 1;

        public const int WEAP_TYPE_HAMMER = 2;

        public const int WEAP_TYPE_AXE = 3;

        public const int WEAP_TYPE_SPEAR = 4;

        public const int WEAP_TYPE_HALBERD = 5;

        public const int WEAP_TYPE_GREATSWORD = 6;

        public const int WEAP_TYPE_GREATHAMMER = 7;

        public const int WEAP_TYPE_BOW = 8;

        public const int WEAP_TYPE_CROSSBOW = 9;

        public const int WEAP_TYPE_STAFF = 10;

        public const int WEAP_TYPE_WHIP = 11;

        public const int WEAP_TYPE_GREATAXE = 12;

        public const int WEAP_TYPE_POLEAXE = 13;

        public const int WEAP_TYPE_FLINTLOCK = 14;

        public const int WEAP_TYPE_TORCH = 15;

        public const int WEAP_TYPE_WAND = 16;

        public const int WEAP_TYPE_GREATSCISSOR = 17;

        public const int WEAP_TYPE_GUNBLADE = 18;

        public const int WEAP_TYPE_WHIPSWORD = 19;

        public const int WEAP_TYPE_LONGSWORD = 20;

        public const int WEAP_TYPE_MAX = 21;

        public const int EQUIPPABLE_FALSE = 0;

        public const int EQUIPPABLE_TWO_HAND = 1;

        public const int EQUIPPABLE_TRUE = 2;

        public const int SHIELD_TYPE_BUCKLER = 0;

        public const int SHIELD_TYPE_HEATER = 1;

        public const int SHIELD_TYPE_KITE = 2;

        public const int SHIELD_TYPE_TOWER = 3;

        public const int SHIELD_TYPE_1H_HACK = 4;

        public const int SHIELD_TYPE_MAX = 5;

        public const int SHIELD_REDUCT = 0;

        public const int SHIELD_DEFLECT = 1;

        public const int SHIELD_PHYS = 2;

        public const int SHIELD_FIRE = 3;

        public const int SHIELD_LIT = 4;

        public const int SHIELD_BLADED = 5;

        public const int SHIELD_POISON = 6;

        public const int SHIELD_HOLY = 7;

        public const int SHIELD_DARK = 8;

        public const int SHIELD_REQ_PRIM = 9;

        public const int SHIELD_REQ_SEC = 10;

        public const int SHIELD_REQ_UNUSED_1 = 11;

        public const int SHIELD_REQ_UNUSED_2 = 12;

        private const int SHIELD_TOTAL_VALUES = 13;

        public const int ARMOR_TYPE_HELM = 0;

        public const int ARMOR_TYPE_ARMOR = 1;

        public const int ARMOR_TYPE_GLOVES = 2;

        public const int ARMOR_TYPE_BOOTS = 3;

        public const int ARMOR_FLAGS_NONE = 0;

        public const int ARMOR_FLAGS_ROBES = 1;

        public const int ARMOR_FLAGS_MASK_HELM = 2;

        public const int ARMOR_FLAGS_FEM2 = 3;

        public const int ARMOR_FLAGS_BEARD_COVER_HELM = 4;

        public const int ARMOR_FLAGS_CAPE = 5;

        public const int ARMOR_FLAGS_CAPE_FEM2 = 6;

        public const int ARMOR_FLAGS_SCARF = 7;

        public const int ARMOR_FLAGS_SCARF_FEM2 = 8;

        public const int ARMOR_FLAGS_COAT = 9;

        public const int ARMOR_FLAGS_COAT_FEM2 = 10;

        public const int ARMOR_FLAGS_HAT = 11;

        public const int ARMOR_FLAGS_COAT_SURCOAT = 12;

        public const int ARMOR_FLAGS_COAT_SURCOAT_FEM2 = 13;

        public const int ARMOR_FLAGS_CAPE_SURCOAT = 14;

        public const int ARMOR_FLAGS_CAPE_SURCOAT_FEM2 = 15;

        public const int ARMOR_FLAGS_ROBES_FEM2 = 16;

        public const int TOTAL_UPGRADES = 2;

        public const int WEAP_ATTACK = 0;

        public const int WEAP_SCALING_STR = 1;

        public const int WEAP_SCALING_DEX = 2;

        public const int WEAP_SCALING_WIS = 3;

        public const int WEAP_SCALING_MAG = 4;

        public const int WEAP_REQ_PRIM = 5;

        public const int WEAP_REQ_SEC = 6;

        public const int WEAP_REQ_UNUSED_1 = 7;

        public const int WEAP_REQ_UNUSED_2 = 8;

        public const int WEAP_SCALING_SPECIAL = 9;

        public const int WEAP_SWOOSH_1_RED = 10;

        public const int WEAP_SWOOSH_1_GREEN = 11;

        public const int WEAP_SWOOSH_1_BLUE = 12;

        public const int WEAP_SWOOSH_1_ALPHA = 13;

        public const int WEAP_SWOOSH_1_SIZE = 14;

        public const int WEAP_SWOOSH_2_RED = 15;

        public const int WEAP_SWOOSH_2_GREEN = 16;

        public const int WEAP_SWOOSH_2_BLUE = 17;

        public const int WEAP_SWOOSH_2_ALPHA = 18;

        public const int WEAP_SWOOSH_2_SIZE = 19;

        public const int WEAP_SWOOSH_3_RED = 20;

        public const int WEAP_SWOOSH_3_GREEN = 21;

        public const int WEAP_SWOOSH_3_BLUE = 22;

        public const int WEAP_SWOOSH_3_ALPHA = 23;

        public const int WEAP_SWOOSH_3_SIZE = 24;

        public const int WEAP_TOTAL_VALUES = 25;

        public const int WEAP_ATTACK_BLADED = 25;

        public const int WEAP_DMG_SPARK = 5;

        public const int WEAP_DMG_FIRE = 6;

        public const int WEAP_DMG_LIT = 7;

        public const int WEAP_DMG_NATURAL = 8;

        public const int WEAP_DMG_POISON = 9;

        public const int WEAP_DMG_FROST = 10;

        public const int WEAP_DMG_MAGIC = 11;

        public const int WEAP_DMG_HOLY = 12;

        public const int WEAP_DMG_DARK = 13;

        public const int WEAP_FLAG_NONE = 0;

        public const int WEAP_FLAG_FIRE = 1;

        public const int WEAP_FLAG_LIT = 2;

        public const int WEAP_FLAG_POISON = 3;

        public const int WEAP_FLAG_FROST = 4;

        public const int WEAP_FLAG_HOLY = 5;

        public const int WEAP_FLAG_DARK = 6;

        public const int WEAP_FLAG_HP_LEECH = 7;

        public const int WEAP_FLAG_MP_LEECH = 8;

        public const int WEAP_FLAG_POISE = 9;

        public const int WEAP_FLAG_CHARM_MOVE = 10;

        public const int WEAP_FLAG_CHARM_MOVE2 = 11;

        public const int WEAP_FLAG_MAX = 12;

        public const int ARMOR_PHYS_DEFENSE = 0;

        public const int ARMOR_FIRE_DEFENSE = 1;

        public const int ARMOR_LIT_DEFENSE = 2;

        public const int ARMOR_BLADED_DEFENSE = 3;

        public const int ARMOR_POISON_DEFENSE = 4;

        public const int ARMOR_HOLY_DEFENSE = 5;

        public const int ARMOR_DARK_DEFENSE = 6;

        public const int ARMOR_POISE = 7;

        public const int ARMOR_REQ_PRIM = 8;

        public const int ARMOR_REQ_SEC = 9;

        public const int ARMOR_REQ_UNUSED_1 = 10;

        public const int ARMOR_REQ_UNUSED_2 = 11;

        public const int ARMOR_TOTAL_VALUES = 12;

        public const int CONSUMABLE_USE_ICON = 0;

        public const int CONSUMABLE_TOTAL_VALUES = 1;

        public const int MATERIALS_TOTAL_VALUES = 1;

        public const int RING_VALUE_IMG = 0;

        public const int RING_VALUE_UNUSED = 1;

        public const int RING_TOTAL_VALUES = 2;

        public const int KEY_TOTAL_VALUES = 1;

        public const int MAGIC_REQ_PRIM = 0;

        public const int MAGIC_REQ_SEC = 1;

        public const int MAGIC_COST = 2;

        public const int MAGIC_TOTAL_VALUES = 3;

        public const int UPGRADE_NORMAL = 0;

        public const int UPGRADE_KRAEKAN = 1;

        public const int UPGRADE_RED_CARBON = 2;

        public const int UPGRADE_NONE = 3;

        public const int UPGRADE_BLUE_DROWNED = 4;

        public const int UPGRADE_BEASTLY = 5;

        public const int UPGRADE_MAX = 6;

        public int category;

        public int type;

        public int upgrade;

        public float upgradeFac;

        public string name;

        public StringBuilder titleStr;

        public StringBuilder[] descStr;

        public string[] title;

        public string[] desc;

        public int img;

        public string texture;

        public int flags;

        public int special;

        public float weight;

        public float[] values;

        public LootDef.UpgradePath[] upgradePath;

        public float value;

        public float durability;

        public int texIdx;

        public int texIdx2;

        public struct UpgradePath
        {
            public UpgradePath(string reqLoot, string outLoot, int cost, int reqCount)
            {
                this.reqLoot = reqLoot;
                this.outLoot = outLoot;
                this.cost = cost;
                this.reqCount = reqCount;
            }

            internal void Write(BinaryWriter writer)
            {
                if (this.reqLoot == null || this.outLoot == null || this.reqLoot == "" || this.outLoot == "")
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.Write(this.reqLoot);
                writer.Write(this.reqCount);
                writer.Write(this.outLoot);
                writer.Write(this.cost);
            }

            internal void Read(BinaryReader reader)
            {
                if (reader.ReadBoolean())
                {
                    this.reqLoot = reader.ReadString();
                    this.reqCount = reader.ReadInt32();
                    this.outLoot = reader.ReadString();
                    this.cost = reader.ReadInt32();
                }
            }

            public string reqLoot;

            public string outLoot;

            public int cost;

            public int reqCount;
        }
    }
}