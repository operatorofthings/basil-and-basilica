using System.IO;

namespace LootEdit.loot
{
    public class LootCategory
    {
        internal void Read(BinaryReader reader)
        {
            int num = reader.ReadInt32();
            this.loot = new LootDef[num];
            for (int i = 0; i < num; i++)
            {
                this.loot[i] = new LootDef();
                this.loot[i].Read(reader);
            }
        }

        public LootDef[] loot;
    }
}