using LootEdit;
using ProjectTower;
using PepperAndChurchSaveEditor;
using System.IO;
using System.Text;

namespace SkillTreeEdit.skilltree
{
    public class SkillNode
    {
        public SkillNode(int ID)
        {
            this.name = "new_node";
            this.title = new string[13];
            this.desc = new string[13];
            this.baseDesc = new string[13];
            for (int i = 0; i < this.title.Length; i++)
            {
                this.title[i] = "";
            }
            for (int j = 0; j < this.desc.Length; j++)
            {
                this.desc[j] = "";
            }
            for (int k = 0; k < this.baseDesc.Length; k++)
            {
                this.baseDesc[k] = "";
            }
            this.title[0] = "New Skill";
            this.desc[0] = "New Description";
            this.baseDesc[0] = "";
            this.cost = 1;
            this.ID = ID;
            this.parent = new int[2];
            for (int l = 0; l < 2; l++)
            {
                this.parent[l] = -1;
            }
        }

        public SkillNode(BinaryReader reader, int ID)
        {
            this.name = reader.ReadString();
            this.title = new string[13];
            this.desc = new string[13];
            this.baseDesc = new string[13];
            for (int i = 0; i < 13; i++)
            {
                this.title[i] = reader.ReadString();
            }
            this.ID = ID;
            this.titleStr = new StringBuilder(this.title[Game1.language]);
            for (int j = 0; j < 13; j++)
            {
                this.desc[j] = reader.ReadString();
            }
            for (int k = 0; k < 13; k++)
            {
                this.baseDesc[k] = reader.ReadString();
            }
            this.type = reader.ReadInt32();
            this.value = reader.ReadInt32();
            this.cost = reader.ReadInt32();
            this.parent = new int[2];
            for (int l = 0; l < 2; l++)
            {
                this.parent[l] = reader.ReadInt32();
            }
            this.loc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            this.img = reader.ReadInt32();
            this.max = this.GetMaxTreeUnlock();
        }

        internal int GetMaxTreeUnlock()
        {
            if (this.cost > 1)
            {
                return 1;
            }
            switch (this.type)
            {
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    {
                        return 5;
                    }
                default:
                    {
                        return 1;
                    }
            }
        }

        internal void CopyFrom(SkillNode other)
        {
            this.name = other.name;
            this.title = new string[other.title.Length];
            this.desc = new string[other.desc.Length];
            this.baseDesc = new string[other.baseDesc.Length];
            for (int i = 0; i < this.title.Length; i++)
            {
                this.title[i] = other.title[i];
            }
            for (int j = 0; j < this.desc.Length; j++)
            {
                this.desc[j] = other.desc[j];
            }
            for (int k = 0; k < this.baseDesc.Length; k++)
            {
                this.baseDesc[k] = other.baseDesc[k];
            }
            this.type = other.type;
            this.value = other.value;
            this.cost = other.cost;
            for (int l = 0; l < 2; l++)
            {
                this.parent[l] = other.parent[l];
            }
            this.loc = other.loc;
            this.img = other.img;
        }

        internal void Write(BinaryWriter writer)
        {
            writer.Write(this.name);
            for (int i = 0; i < 13; i++)
            {
                if (i < this.title.Length)
                {
                    writer.Write(this.title[i]);
                }
                else
                {
                    writer.Write(this.title[0] + " - " + TranslationMgr.GetLangStrFromIdx(i));
                }
            }
            for (int j = 0; j < 13; j++)
            {
                if (j < this.desc.Length)
                {
                    writer.Write(this.desc[j]);
                }
                else
                {
                    writer.Write("Untranslated Description: " + TranslationMgr.GetLangStrFromIdx(j));
                }
            }
            for (int k = 0; k < 13; k++)
            {
                if (k < this.baseDesc.Length)
                {
                    writer.Write(this.baseDesc[k]);
                }
                else
                {
                    writer.Write("Untranslated Base Description: " + TranslationMgr.GetLangStrFromIdx(k));
                }
            }
            writer.Write(this.type);
            writer.Write(this.value);
            writer.Write(this.cost);
            for (int l = 0; l < 2; l++)
            {
                writer.Write(this.parent[l]);
            }
            writer.Write(this.loc.X);
            writer.Write(this.loc.Y);
            writer.Write(this.img);
        }

        internal string ReplaceTextWithVal(string text, int value)
        {
            string newValue = value.ToString();
            return text.Replace("[v]", newValue);
        }

        public const int TYPE_SWORD_CLASS = 0;

        public const int TYPE_AXE_CLASS_DEP = 1;

        public const int TYPE_MACE_CLASS = 2;

        public const int TYPE_DAGGER_CLASS = 3;

        public const int TYPE_SPEAR_CLASS_DEP = 4;

        public const int TYPE_SHIELD_CLASS = 5;

        public const int TYPE_GREATSWORD_CLASS_DEP = 6;

        public const int TYPE_GREATAXE_CLASS_DEP = 7;

        public const int TYPE_GREATHAMMER_CLASS = 8;

        public const int TYPE_WHIP_CLASS = 9;

        public const int TYPE_STAFF_CLASS = 10;

        public const int TYPE_BOW_CLASS = 11;

        public const int TYPE_CROSSBOW_CLASS = 12;

        public const int TYPE_PISTOL_CLASS_DEP = 13;

        public const int TYPE_POLEAXE_CLASS = 14;

        public const int TYPE_HALBERD_CLASS_DEP = 15;

        public const int TYPE_ARMOR_CLASS = 16;

        public const int TYPE_STR = 17;

        public const int TYPE_DEX = 18;

        public const int TYPE_MAG = 19;

        public const int TYPE_WIS = 20;

        public const int TYPE_END = 21;

        public const int TYPE_WILL = 22;

        public const int TYPE_HEALTH_POT = 23;

        public const int TYPE_MANA_POT = 24;

        public const int TYPE_PRAYER_CLASS = 25;

        public const int TYPE_MAGIC_CLASS = 26;

        public const int TYPE_WAND_CLASS = 27;

        public const int TYPE_LIGHT_ARMOR_CLASS = 28;

        public const int TOTAL_CLASSES = 29;

        private const int MAX_UPGRADES_PER_STAT_NODE = 5;

        public const int MAX_PARENTS = 2;

        public string name;

        public string[] title;

        public string[] desc;

        public string[] baseDesc;

        public int ID;

        public StringBuilder titleStr;

        public StringBuilder[] descStr;

        public StringBuilder[] baseDescStr;

        public int type;

        public int value;

        public int cost;

        public int[] parent;

        public int img;

        public Vector2 loc;

        public int max;
    }
}