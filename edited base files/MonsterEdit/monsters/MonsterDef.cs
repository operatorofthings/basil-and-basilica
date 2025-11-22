using LootEdit;
using System.IO;
using System.Text;

namespace MonsterEdit.monsters
{
    public class MonsterDef
    {
        public MonsterDef(BinaryReader reader)
        {
            this.Read(reader);
        }

        public void Write(BinaryWriter writer)
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
            writer.Write(this.boxWidth);
            writer.Write(this.boxHeight);
            writer.Write(this.phaseThresh);
            writer.Write(this.crazeThresh);
            writer.Write(this.def);
            writer.Write(this.texture);
            writer.Write(this.helm);
            writer.Write(this.armor);
            writer.Write(this.gloves);
            writer.Write(this.boots);
            writer.Write(this.weapon);
            writer.Write(this.shield);
            writer.Write(this.stepSnd);
            writer.Write(this.jabSnd);
            writer.Write(this.fierceSnd);
            writer.Write(this.hitSnd);
            writer.Write(this.growlSnd);
            writer.Write(this.laughSnd);
            writer.Write(this.dieSnd);
            writer.Write(this.screamSnd);
            writer.Write(this.hair);
            writer.Write(this.hairColor);
            writer.Write(this.beard);
            writer.Write(this.beardColor);
            writer.Write(this.skinIdx);
            writer.Write(this.skinClass);
            writer.Write(this.eyes);
            writer.Write(this.hp);
            writer.Write(this.attack);
            writer.Write(this.defense);
            writer.Write(this.poise);
            writer.Write(this.stamina);
            writer.Write(this.poiseAttack);
            writer.Write(this.blockReduce);
            writer.Write(this.blockDeflect);
            writer.Write(this.blockDmgReduce);
            writer.Write(this.blockMagReduce);
            writer.Write(this.runSpeed);
            writer.Write(this.fireDef);
            writer.Write(this.litDef);
            writer.Write(this.bladedDef);
            writer.Write(this.poisonDef);
            writer.Write(this.holyDef);
            writer.Write(this.darkDef);
            writer.Write(this.salt);
            writer.Write(this.ai);
            writer.Write(this.type);
            writer.Write(this.flags);
            writer.Write(this.giant);
            writer.Write(this.hover);
            writer.Write(this.creature);
            writer.Write(this.slowBack);
            writer.Write(this.bestiary);
            writer.Write(this.fadeLayer);
            writer.Write(this.attackAnim);
            writer.Write(this.strongAnim);
            writer.Write(this.specialAnim);
            writer.Write(this.attackReach);
            writer.Write(this.strongReach);
            writer.Write(this.specialReach);
            writer.Write(this.idleAnim);
            writer.Write(this.runAnim);
            writer.Write(this.runStartAnim);
            writer.Write(this.runEndAnim);
            writer.Write(this.blockAnim);
            writer.Write(this.blockInAnim);
            writer.Write(this.blockOutAnim);
            writer.Write(this.blockAdvAnim);
            writer.Write(this.blockRetAnim);
            writer.Write(this.blockAbsAnim);
            for (int k = 0; k < this.monsterDrop.Length; k++)
            {
                this.monsterDrop[k].Write(writer);
            }
        }

        public void Read(BinaryReader reader)
        {
            this.name = reader.ReadString();
            this.title = new string[13];
            this.desc = new string[13];
            for (int i = 0; i < this.title.Length; i++)
            {
                this.title[i] = reader.ReadString();
            }
            for (int j = 0; j < this.desc.Length; j++)
            {
                this.desc[j] = reader.ReadString();
            }
            this.boxWidth = (float)reader.ReadInt32();
            this.boxHeight = (float)reader.ReadInt32();
            this.phaseThresh = reader.ReadSingle();
            this.crazeThresh = reader.ReadSingle();
            this.def = reader.ReadString();
            this.texture = reader.ReadString();
            this.helm = reader.ReadString();
            this.armor = reader.ReadString();
            this.gloves = reader.ReadString();
            this.boots = reader.ReadString();
            this.weapon = reader.ReadString();
            this.shield = reader.ReadString();
            this.stepSnd = reader.ReadString();
            this.jabSnd = reader.ReadString();
            this.fierceSnd = reader.ReadString();
            this.hitSnd = reader.ReadString();
            this.growlSnd = reader.ReadString();
            this.laughSnd = reader.ReadString();
            this.dieSnd = reader.ReadString();
            this.screamSnd = reader.ReadString();
            this.hair = reader.ReadInt32();
            this.hairColor = reader.ReadInt32();
            this.beard = reader.ReadInt32();
            this.beardColor = reader.ReadInt32();
            this.skinIdx = reader.ReadInt32();
            this.skinClass = reader.ReadInt32();
            this.eyes = reader.ReadInt32();
            this.hp = reader.ReadSingle();
            this.attack = reader.ReadSingle();
            this.defense = reader.ReadSingle();
            this.poise = reader.ReadSingle();
            this.stamina = reader.ReadSingle();
            this.poiseAttack = reader.ReadSingle();
            this.blockReduce = reader.ReadSingle();
            this.blockDeflect = reader.ReadSingle();
            this.blockDmgReduce = reader.ReadSingle();
            this.blockMagReduce = reader.ReadSingle();
            this.runSpeed = reader.ReadSingle();
            this.fireDef = reader.ReadSingle();
            this.litDef = reader.ReadSingle();
            this.bladedDef = reader.ReadSingle();
            this.poisonDef = reader.ReadSingle();
            this.holyDef = reader.ReadSingle();
            this.darkDef = reader.ReadSingle();
            this.salt = reader.ReadInt32();
            this.ai = reader.ReadInt32();
            this.type = reader.ReadInt32();
            this.flags = reader.ReadInt32();
            this.giant = reader.ReadBoolean();
            this.hover = reader.ReadBoolean();
            this.creature = reader.ReadInt32();
            this.slowBack = reader.ReadBoolean();
            this.bestiary = reader.ReadBoolean();
            this.fadeLayer = reader.ReadBoolean();
            this.attackAnim = reader.ReadString();
            this.strongAnim = reader.ReadString();
            this.specialAnim = reader.ReadString();
            this.attackReach = reader.ReadInt32();
            this.strongReach = reader.ReadInt32();
            this.specialReach = reader.ReadInt32();
            this.idleAnim = reader.ReadString();
            this.runAnim = reader.ReadString();
            this.runStartAnim = reader.ReadString();
            this.runEndAnim = reader.ReadString();
            this.blockAnim = reader.ReadString();
            this.blockInAnim = reader.ReadString();
            this.blockOutAnim = reader.ReadString();
            this.blockAdvAnim = reader.ReadString();
            this.blockRetAnim = reader.ReadString();
            this.blockAbsAnim = reader.ReadString();
            this.monsterDrop = new MonsterDef.MonsterDrop[6];
            for (int k = 0; k < this.monsterDrop.Length; k++)
            {
                this.monsterDrop[k] = new MonsterDef.MonsterDrop(reader);
            }
        }

        public string name;

        public string[] title;

        public string[] desc;

        public StringBuilder titleStr;

        public string def;

        public string texture;

        public bool canJump;

        public bool slowBack;

        public bool bestiary;

        public string helm;

        public string armor;

        public string gloves;

        public string boots;

        public string weapon;

        public string shield;

        public int hair;

        public int hairColor;

        public int beard;

        public int beardColor;

        public int skinClass;

        public int skinIdx;

        public int eyes;

        public float hp;

        public float attack;

        public float defense;

        public float poise;

        public float stamina;

        public float poiseAttack;

        public float blockReduce;

        public float blockDeflect;

        public float blockDmgReduce;

        public float blockMagReduce;

        public float fireDef;

        public float litDef;

        public float bladedDef;

        public float poisonDef;

        public float holyDef;

        public float darkDef;

        public float phaseThresh;

        public float crazeThresh;

        public bool fadeLayer;

        public int salt;

        public int ai;

        public int type;

        public int flags;

        public int creature;

        public int bloodType;

        public float boxWidth;

        public float boxHeight;

        public string stepSnd = "";

        public string jabSnd = "";

        public string fierceSnd = "";

        public string growlSnd = "";

        public string laughSnd = "";

        public string dieSnd = "";

        public string screamSnd = "";

        public string hitSnd = "";

        public MonsterDef.MonsterDrop[] monsterDrop;

        public int defIdx;

        public float scale = 1f;

        public bool giant;

        public bool hover;

        public string attackAnim = "attack";

        public string strongAnim = "strong";

        public string specialAnim = "special";

        public string idleAnim = "idle";

        public string runStartAnim = "runstart";

        public string runEndAnim = "runend";

        public string runAnim = "run";

        public string blockAnim = "block";

        public string blockInAnim = "blockin";

        public string blockOutAnim = "blockout";

        public string blockAdvAnim = "blockadv";

        public string blockRetAnim = "blockret";

        public string blockAbsAnim = "blockabs";

        public int attackReach;

        public int strongReach;

        public int specialReach;

        public float runSpeed = 300f;

        public struct MonsterDrop
        {
            public MonsterDrop(float rate, string loot)
            {
                this.dropRate = rate;
                this.dropLoot = loot;
                this.dropCount = 1;
            }

            public MonsterDrop(BinaryReader reader)
            {
                this.dropRate = reader.ReadSingle();
                this.dropLoot = reader.ReadString();
                this.dropCount = reader.ReadInt32();
            }

            public void Write(BinaryWriter writer)
            {
                writer.Write(this.dropRate);
                writer.Write((this.dropLoot == null) ? "" : this.dropLoot);
                writer.Write(this.dropCount);
            }

            public string dropLoot;

            public float dropRate;

            public int dropCount;
        }
    }
}