using LootEdit;
using LootEdit.loot;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectTower.player
{
    public class InvLoot
    {
        public InvLoot()
        {
        }

        public InvLoot(BinaryReader reader)
        {
            this.Read(reader);
        }

        public InvLoot(InvLoot loot)
        {
            this.CopyFrom(loot);
        }

        public void InitFromName(string name)
        {
            this.SetIndex(name);

            if (this.catalogIdx > -1)
            {
                this.upgrade = 0;
                LootDef lootDef = LootCatalog.category[this.category].loot[this.catalogIdx];
                this.durability = lootDef.durability;
                this.count = 1;
            }
        }

        public void CopyFrom(InvLoot other)
        {
            // added to support modded items where SetIndex fails
            this.category = other.category;

            // this sets this.name, this.category and this.catalogIdx
            SetIndex(other.name);
            this.durability = other.durability;
            this.count = other.count;
            this.sanctuaryConsumableCreed = other.sanctuaryConsumableCreed;
            this.upgrade = other.upgrade;
            this.elemental = other.elemental;
            this.equipped = other.equipped;
        }

        public void SetIndex(string name)
        {
            this.name = name;
            this.catalogIdx = -1;

            for (int i = 0; i < LootCatalog.category.Length; i++)
            {
                for (int j = 0; j < LootCatalog.category[i].loot.Length; j++)
                {
                    if (LootCatalog.category[i].loot[j].name == name)
                    {
                        this.category = i;
                        this.catalogIdx = j;
                        return;
                    }
                }
            }
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.name);
            writer.Write(this.durability);
            writer.Write(this.count);
            writer.Write(this.category);
            writer.Write(this.upgrade);
            writer.Write(this.elemental);
            writer.Write(this.sanctuaryConsumableCreed);
        }

        public void Read(BinaryReader reader)
        {
            this.name = reader.ReadString();
            this.SetIndex(this.name);
            this.durability = reader.ReadSingle();
            this.count = reader.ReadInt32();
            this.category = reader.ReadInt32();
            this.upgrade = reader.ReadInt32();
            this.elemental = reader.ReadInt32();
            this.sanctuaryConsumableCreed = reader.ReadInt32();
        }

        // this is a property instead of a field to make it more obvious that it's not a part of the base game class
        private string DisplayNameBackingField { get; set; }

        public string DisplayName
        {
            get
            {
                if (this.DisplayNameBackingField == null)
                {
                    if (catalogIdx > -1)
                    {
                        this.DisplayNameBackingField = LootCatalog.category[this.category].loot[this.catalogIdx].title[Game1.language];
                    }
                    else
                    {
                        this.DisplayNameBackingField = "Unknown Item: " + this.name;
                    }
                }

                return DisplayNameBackingField;
            }
        }

        public void ResetDisplayName()
        {
            this.DisplayNameBackingField = null;
        }

        public class SortInvLootByName : Comparer<InvLoot>
        {
            public override int Compare(InvLoot a, InvLoot b)
            {
                return a.DisplayName.CompareTo(b.DisplayName);
            }
        }

        // this variable contains valid data in the save game, but it gets overriden by SetIndex if it's not a modded item
        public int category;

        public string name;

        // this variable does not actually contain valid data in the save game
        public StringBuilder title;

        // this variable does not contain serialized valid data in the save game, but gets assigned through SetIndex, it stays -1 for modded items
        public int catalogIdx;

        public int count;

        public float durability;

        public int upgrade;

        public int elemental;

        public bool equipped;

        public int sanctuaryConsumableCreed;
    }
}
