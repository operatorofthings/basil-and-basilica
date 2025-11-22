using DialogEdit;
using SkillTreeEdit.skilltree;
using System.IO;
using System.Text;

namespace ProjectTower.player
{
    public class PlayerStats
    {
        public static void Init()
        {
            PlayerStats.strs = new StringBuilder[]
            {
                new StringBuilder(""),
                LocStrings.GetLocString(159),
                LocStrings.GetLocString(160),
                LocStrings.GetLocString(161),
                LocStrings.GetLocString(162),
                LocStrings.GetLocString(163),
                LocStrings.GetLocString(164),
                LocStrings.GetLocString(165),
                LocStrings.GetLocString(166),
                LocStrings.GetLocString(167),
                LocStrings.GetLocString(168),
                LocStrings.GetLocString(169),
                LocStrings.GetLocString(170),
                LocStrings.GetLocString(171),
                LocStrings.GetLocString(172),
                LocStrings.GetLocString(173),
                LocStrings.GetLocString(174),
                LocStrings.GetLocString(175),
                LocStrings.GetLocString(176),
                LocStrings.GetLocString(177),
                LocStrings.GetLocString(178),
                LocStrings.GetLocString(179),
                LocStrings.GetLocString(180),
                LocStrings.GetLocString(181),
                LocStrings.GetLocString(182),
                LocStrings.GetLocString(183),
                LocStrings.GetLocString(184),
                LocStrings.GetLocString(185),
                LocStrings.GetLocString(186),
                LocStrings.GetLocString(187),
                new StringBuilder("ȿ " + LocStrings.GetLocStr(188)),
                new StringBuilder("ȿ " + LocStrings.GetLocStr(189)),
                new StringBuilder("ȿ " + LocStrings.GetLocStr(190)),
                LocStrings.GetLocString(191),
                LocStrings.GetLocString(192),
                LocStrings.GetLocString(193),
                LocStrings.GetLocString(194),
                LocStrings.GetLocString(195),
                LocStrings.GetLocString(196),
                LocStrings.GetLocString(197),
                LocStrings.GetLocString(198),
                LocStrings.GetLocString(199),
                LocStrings.GetLocString(200),
                LocStrings.GetLocString(201),
                LocStrings.GetLocString(202),
                LocStrings.GetLocString(203),
                LocStrings.GetLocString(204),
                LocStrings.GetLocString(205)
            };
        }

        public PlayerStats(Player p)
        {
            this.p = p;
            this.Reset();
        }

        public void Reset()
        {
            this.level = 1;
            this.treeUnlocks = new int[500];
            this.itemClass = new int[30];
            this.classUnlocks = new int[2];
            this.stat = new int[6];
            for (int i = 0; i < this.stat.Length; i++)
            {
                this.stat[i] = 10;
            }
            this.pageAlpha = new float[3];
        }

        internal void Write(BinaryWriter writer)
        {
            writer.Write(this.level);
            for (int i = 0; i < 30; i++)
            {
                writer.Write(this.itemClass[i]);
            }
            for (int j = 0; j < 500; j++)
            {
                writer.Write(this.treeUnlocks[j]);
            }
            for (int k = 0; k < 2; k++)
            {
                writer.Write(this.classUnlocks[k]);
            }
        }

        public void UpdateStats()
        {
            for (int i = 0; i < this.stat.Length; i++)
            {
                this.stat[i] = 5;
            }
            for (int j = 0; j < this.itemClass.Length; j++)
            {
                this.itemClass[j] = 0;
            }
            for (int k = 0; k < SkillTree.nodes.Length; k++)
            {
                if (this.treeUnlocks[k] > 0 || this.classUnlocks[0] == k || this.classUnlocks[1] == k)
                {
                    SkillNode skillNode = SkillTree.nodes[k];
                    if (skillNode.img > -1)
                    {
                        switch (skillNode.type)
                        {
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 25:
                            case 26:
                            case 27:
                            case 28:
                                if (skillNode.value > this.itemClass[skillNode.type])
                                {
                                    this.itemClass[skillNode.type] = skillNode.value;
                                }
                                switch (skillNode.type)
                                {
                                    case 0:
                                    case 1:
                                    case 2:
                                    case 6:
                                    case 7:
                                    case 8:
                                        this.stat[0] += skillNode.value;
                                        break;

                                    case 3:
                                    case 4:
                                    case 5:
                                    case 9:
                                        this.stat[3] += skillNode.value;
                                        break;

                                    case 10:
                                    case 26:
                                    case 27:
                                        this.stat[4] += skillNode.value;
                                        break;

                                    case 11:
                                    case 12:
                                    case 13:
                                    case 14:
                                    case 15:
                                        this.stat[2] += skillNode.value;
                                        break;

                                    case 16:
                                    case 28:
                                        this.stat[1] += skillNode.value;
                                        break;

                                    case 25:
                                        this.stat[5] += skillNode.value;
                                        break;
                                }
                                break;

                            case 17:
                                this.stat[0] += ((skillNode.value > 1) ? skillNode.value : this.treeUnlocks[k]);
                                break;

                            case 18:
                                this.stat[2] += ((skillNode.value > 1) ? skillNode.value : this.treeUnlocks[k]);
                                break;

                            case 19:
                                this.stat[4] += ((skillNode.value > 1) ? skillNode.value : this.treeUnlocks[k]);
                                break;

                            case 20:
                                this.stat[5] += ((skillNode.value > 1) ? skillNode.value : this.treeUnlocks[k]);
                                break;

                            case 21:
                                this.stat[1] += ((skillNode.value > 1) ? skillNode.value : this.treeUnlocks[k]);
                                break;

                            case 22:
                                this.stat[3] += ((skillNode.value > 1) ? skillNode.value : this.treeUnlocks[k]);
                                break;

                            case 23:
                            case 24:
                                this.itemClass[skillNode.type] += skillNode.value;
                                break;
                        }
                    }
                }
            }
        }

        internal void Read(BinaryReader reader)
        {
            this.level = reader.ReadInt32();
            for (int i = 0; i < 30; i++)
            {
                this.itemClass[i] = reader.ReadInt32();
            }
            for (int j = 0; j < 500; j++)
            {
                this.treeUnlocks[j] = reader.ReadInt32();
            }
            for (int k = 0; k < 2; k++)
            {
                this.classUnlocks[k] = reader.ReadInt32();
            }
            this.UpdateStats();
        }

        public const int STAT_STR = 0;

        public const int STAT_END = 1;

        public const int STAT_DEX = 2;

        public const int STAT_WILL = 3;

        public const int STAT_MAG = 4;

        public const int STAT_WIS = 5;

        public const int TOTAL_STATS = 6;

        public const int STAT_ITEM_FIND = 99;

        public const int STR_NAME = 0;

        public const int STR_LEVEL = 1;

        public const int STR_EQUIP = 2;

        public const int STR_VITALITY = 3;

        public const int STR_STRENGTH = 4;

        public const int STR_STAMINA = 5;

        public const int STR_DEXTERITY = 6;

        public const int STR_MAGIC = 7;

        public const int STR_WISDOM = 8;

        public const int STR_EQUIP_L = 9;

        public const int STR_EQUIP_M = 10;

        public const int STR_EQUIP_H = 11;

        public const int STR_EQUIP_O = 12;

        public const int STR_PHYS_DEF = 13;

        public const int STR_FIRE_DEF = 14;

        public const int STR_LIT_DEF = 15;

        public const int STR_BLADED_DEF = 16;

        public const int STR_POISON_DEF = 17;

        public const int STR_HOLY_DEF = 18;

        public const int STR_DARK_DEF = 19;

        public const int STR_POISE = 20;

        public const int STR_ATTACK = 21;

        public const int STR_SALT_COST = 22;

        public const int STR_SALT_AVAIL = 23;

        public const int STR_MAX_HP = 24;

        public const int STR_MAX_MP = 25;

        public const int STR_MAX_SP = 26;

        public const int STR_SPIRIT = 27;

        public const int STR_ENDURANCE = 28;

        public const int STR_WILL = 29;

        public const int STR_MAIN = 30;

        public const int STR_STATS = 31;

        public const int STR_DEFENSE = 32;

        public const int STR_CREED = 33;

        public const int STR_CREED_NONE = 34;

        public const int STR_CREED_IRON = 35;

        public const int STR_CREED_CLERIC = 36;

        public const int STR_CREED_THREE = 37;

        public const int STR_CREED_WOODS = 38;

        public const int STR_CREED_DARK = 39;

        public const int STR_CREED_SPLENDOR = 40;

        public const int STR_CREED_FOOL = 41;

        public const int STR_CREED_FIRE = 42;

        public const int STR_CREED_BONES = 43;

        public const int STR_DROP_RATE = 44;

        public const int STR_ARDOR_LEVEL = 45;

        public const int STR_LV = 46;

        public const int STR_PR = 47;

        public const float STAT_CAP = 50f;

        private const int PAGE_MAIN = 0;

        private const int PAGE_STATS = 1;

        private const int PAGE_DEF = 2;

        private const int TOTAL_PAGES = 3;

        public const int MAX_TREE_UNLOCKS = 500;

        public const int TOTAL_ITEM_CLASSES = 30;

        public const int TOTAL_CLASS_UNLOCKS = 2;

        public bool active;

        public float alpha;

        public int level;

        public int[] stat;

        public float[] pageAlpha;

        public int page;

        public bool percentMode;

        public float percentAlpha;

        public static StringBuilder[] strs;

        public int[] treeUnlocks;

        public int[] classUnlocks;

        public int[] itemClass;

        private Player p;
    }
}