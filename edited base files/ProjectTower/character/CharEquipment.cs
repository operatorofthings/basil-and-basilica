using System.IO;

namespace ProjectTower.character
{
    public class CharEquipment
    {
        public CharEquipment()
        {
            this.helm.Reset();
            this.armor.Reset();
            this.gloves.Reset();
            this.boots.Reset();
            this.loadout = new CharEquipment.EquippedLoot[2, 3];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.loadout[i, j].Reset();
                }
            }
            this.twoHanded = new bool[2];
            this.consumable = new CharEquipment.EquippedLoot[6];
            for (int k = 0; k < this.consumable.Length; k++)
            {
                this.consumable[k].Reset();
            }
            this.incantation = new CharEquipment.EquippedLoot[6];
            for (int l = 0; l < this.incantation.Length; l++)
            {
                this.incantation[l].Reset();
            }
            this.ring = new CharEquipment.EquippedLoot[4];
            for (int m = 0; m < this.ring.Length; m++)
            {
                this.ring[m].Reset();
            }
        }

        internal void Write(BinaryWriter writer)
        {
            this.helm.Write(writer);
            this.armor.Write(writer);
            this.gloves.Write(writer);
            this.boots.Write(writer);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.loadout[i, j].Write(writer);
                }
            }
            for (int k = 0; k < this.consumable.Length; k++)
            {
                this.consumable[k].Write(writer);
            }
            for (int l = 0; l < this.incantation.Length; l++)
            {
                this.incantation[l].Write(writer);
            }
            for (int m = 0; m < this.ring.Length; m++)
            {
                this.ring[m].Write(writer);
            }
            for (int n = 0; n < 2; n++)
            {
                writer.Write(this.twoHanded[n]);
            }
            writer.Write(this.selConsumable);
            writer.Write(this.selIncantation);
            writer.Write(this.selectedUseRow);
            writer.Write(this.loadoutIdx);
        }

        internal void Read(BinaryReader reader)
        {
            this.helm.Read(reader);
            this.armor.Read(reader);
            this.gloves.Read(reader);
            this.boots.Read(reader);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.loadout[i, j].Read(reader);
                }
            }
            for (int k = 0; k < this.consumable.Length; k++)
            {
                this.consumable[k].Read(reader);
            }
            for (int l = 0; l < this.incantation.Length; l++)
            {
                this.incantation[l].Read(reader);
            }
            for (int m = 0; m < this.ring.Length; m++)
            {
                this.ring[m].Read(reader);
            }
            for (int n = 0; n < 2; n++)
            {
                this.twoHanded[n] = reader.ReadBoolean();
            }
            this.selConsumable = reader.ReadInt32();
            this.selIncantation = reader.ReadInt32();
            this.selectedUseRow = reader.ReadInt32();
            this.loadoutIdx = reader.ReadInt32();
            this.usePickerConsumableInvIdx = -1;
        }

        public CharEquipment.EquippedLoot helm;

        public CharEquipment.EquippedLoot armor;

        public CharEquipment.EquippedLoot gloves;

        public CharEquipment.EquippedLoot boots;

        public CharEquipment.EquippedLoot[,] loadout;

        public CharEquipment.EquippedLoot[] consumable;

        public CharEquipment.EquippedLoot[] ring;

        public CharEquipment.EquippedLoot[] incantation;

        public int loadoutIdx;

        public bool[] twoHanded;

        public int selConsumable;

        public int selIncantation;

        public int selectedUseRow;

        public int useConsumable;

        public int useIncantation;

        public int useUseRow;

        public int usePickerConsumableInvIdx;

        public int hair;

        public int hairColor;

        public int beard;

        public int beardColor;

        public int skinIdx;

        public int skinClass;

        public int eyeColor;

        public bool active;

        public int propCreed;

        public struct EquippedLoot
        {
            public void Reset()
            {
                this.catalogIdx = -1;
                this.category = -1;
                this.invIdx = -1;
            }

            internal void Write(BinaryWriter writer)
            {
                writer.Write(this.catalogIdx);
                writer.Write(this.category);
                writer.Write(this.invIdx);
            }

            internal void Read(BinaryReader reader)
            {
                this.catalogIdx = reader.ReadInt32();
                this.category = reader.ReadInt32();
                this.invIdx = reader.ReadInt32();
            }

            internal void CopyFrom(CharEquipment.EquippedLoot equippedLoot)
            {
                this.invIdx = equippedLoot.invIdx;
                this.catalogIdx = equippedLoot.catalogIdx;
                this.category = equippedLoot.category;
            }

            public int catalogIdx;

            public int category;

            public int invIdx;
        }
    }
}